using System;

namespace TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;

internal interface IAggregatedAssertionCondition<in TElement, in TSettings> : IAssertionCondition<TElement, TSettings>
{
    int Count { get; }
    Type AssertionBaseType { get; }
}