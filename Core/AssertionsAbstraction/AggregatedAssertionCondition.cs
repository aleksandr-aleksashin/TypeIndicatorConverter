using System;
using System.Collections.Generic;
using System.Linq;
using TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;

namespace TypeIndicatorConverter.Core.AssertionsAbstraction
{
    internal class AggregatedAssertionCondition<TElement, TSettings> : IAggregatedAssertionCondition<TElement, TSettings>
    {
        private readonly List<IAssertionCondition<TElement, TSettings>> _assertionConditions = new();
        public Type AssertionBaseType { get; }

        public AggregatedAssertionCondition(Type assertionBaseType)
        {
            AssertionBaseType = assertionBaseType;
        }

        public int Count => _assertionConditions.Count;

        public void AddAssert(IAssertionCondition<TElement, TSettings> assertionCondition)
        {
            _assertionConditions.Add(assertionCondition);
        }

        public bool Assert(TElement actualValue, TSettings actualSettings) =>
            _assertionConditions.Select(x => x.Assert(actualValue, actualSettings))
                                .Aggregate(true, (p, c) => p & c);
    }
}
