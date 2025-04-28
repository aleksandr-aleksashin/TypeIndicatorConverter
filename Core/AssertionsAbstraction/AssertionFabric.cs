#nullable enable
using System;
using System.Linq;
using System.Reflection;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;
using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Core.AssertionsAbstraction;

internal static class AssertionFabric
{
    public static IAggregatedAssertionCondition<TElement, TSettings> CreateTypeIndicatorAssert<TElement, TSettings>(IUnificationHelper<TElement, TSettings> unificationHelper,
                                                                                                                    Type type)
    {
        var propertyInfos = type.GetProperties()
                                .Where(y => y.GetCustomAttributes<TypeIndicatorAttribute>().Any())
                                .ToList();

        if (!propertyInfos.Any())
        {
            throw new TypeIndicatorConverterException($"No type indicators for type '{type}'");
        }

        //TODO: support defaults value from attribute.
        //TODO: support attributes defined fields.
        //TODO: respect access to constant or static fields.
        object? constructedObject;

        try
        {
            constructedObject = Activator.CreateInstance(type, BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, null, null);
        }
        catch (MissingMethodException)
        {
            throw new TypeIndicatorConverterException($"Type '{type}' must have a parameterless constructor");
        }

        // need to respect constant value and default value handler
        if (constructedObject == null)
        {
            throw new TypeIndicatorConverterException($"Type '{type}' must have a parameterless constructor");
        }

        var aggregatedAssertionCondition = new AggregatedAssertionCondition<TElement, TSettings>(type);

        foreach (var propertyInfo in propertyInfos)
        {
            var expectedValue = propertyInfo.GetGetMethod()?.Invoke(constructedObject, null);

            aggregatedAssertionCondition.AddAssert(new AssertionCondition<TElement, TSettings>(propertyInfo,
                                                                                               propertyInfo.GetCustomAttribute<TypeIndicatorAttribute>()!,
                                                                                               expectedValue,
                                                                                               type,
                                                                                               unificationHelper));
        }

        return aggregatedAssertionCondition;
    }
}