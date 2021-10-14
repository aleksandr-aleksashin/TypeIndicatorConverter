#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TypeIndicatorConverter.Core.AssertionsAbstraction;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;
using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Core
{
    public class DispatchList<T, TElement, TSettings>
    {
        private List<IAggregatedAssertionCondition<TElement, TSettings>> TypeIndicatorConditions { get; }
        private List<IAggregatedAssertionCondition<TElement, TSettings>> FallbackConditions { get; }
        private bool AllowedMultiplySelection { get; }

        private DispatchList(List<IAggregatedAssertionCondition<TElement, TSettings>> typeIndicatorConditions,
                             List<IAggregatedAssertionCondition<TElement, TSettings>> fallbackConditions,
                             bool allowedMultiplySelection)
        {
            TypeIndicatorConditions = typeIndicatorConditions;
            FallbackConditions = fallbackConditions;
            AllowedMultiplySelection = allowedMultiplySelection;
        }

        public Type GetMatchedType(TElement element, TSettings settings) =>
            GetMatchedTypeInternal(TypeIndicatorConditions, element, settings) ??
            GetMatchedTypeInternal(FallbackConditions, element, settings) ??
            throw new TypeIndicatorConverterException($"Invalid type {element}. Does not match any of: " +
                                                      $"{string.Join(", ", TypeIndicatorConditions.Union(FallbackConditions).Select(x => x.AssertionBaseType.ToString()))}");

        private Type? GetMatchedTypeInternal(List<IAggregatedAssertionCondition<TElement, TSettings>> checkingList,
                                             TElement element, TSettings settings)
        {
            Type? resultType = null;

            foreach (var condition in checkingList.OrderByDescending(x => x.Count)
                                                  .ThenBy(x => x.AssertionBaseType.Name))
            {
                if (!condition.Assert(element, settings))
                {
                    continue;
                }

                if (resultType is not null)
                {
                    if (AllowedMultiplySelection)
                    {
                        return resultType;
                    }

                    throw new TypeIndicatorConverterException($"Ambiguous discriminated type inference not allowed. '{resultType}' and '{condition.AssertionBaseType}'");
                }

                resultType = condition.AssertionBaseType;
            }

            return resultType;
        }

        public static DispatchList<T, TElement, TSettings> Create(IUnificationHelper<TElement, TSettings> unificationHelper)
        {
            var type = typeof(T);

            var types = AppDomain.CurrentDomain
                                 .GetAssemblies()
                                 .SelectMany(x => x.GetTypes()
                                                   .Where(p => !p.IsAbstract)
                                                   .Where(p => !p.IsInterface)
                                                   .Where(p => type.IsAssignableFrom(p))
                                                   .Where(p => p.GetCustomAttribute<IgnoreIndicatorsAttribute>() is null))
                                 .ToList();

            var typeIndicators = types.Where(x => x.GetCustomAttribute<FallbackIndicatorAttribute>() is null)
                                      .Select(x => (AssertionFabric.CreateTypeIndicatorAssert(unificationHelper, x)))
                                      .OrderByDescending(x => x.Count)
                                      .ThenBy(x => x.AssertionBaseType.Name)
                                      .ToList();
            // TODO: may be support indicators for fallbacks
            var fallBacks = types.Where(x => x.GetCustomAttribute<FallbackIndicatorAttribute>() is not null)
                                 .Select(x => (IAggregatedAssertionCondition<TElement, TSettings>)new AggregatedAssertionCondition<TElement, TSettings>(x))
                                 .ToList();

            var TypeIndicatorIndicatorsAttribute = type.GetCustomAttribute<AmbiguousMatchingAttribute>();

            return new DispatchList<T, TElement, TSettings>(typeIndicators,
                                                            fallBacks,
                                                            TypeIndicatorIndicatorsAttribute is { AllowMultiplySelection: true });
        }
    }
}
