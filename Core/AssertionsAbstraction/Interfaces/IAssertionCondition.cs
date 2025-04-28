namespace TypeIndicatorConverter.Core.AssertionsAbstraction.Interfaces;

internal interface IAssertionCondition<in TElement, in TSettings>
{
    bool Assert(TElement actualValue, TSettings actualSettings);
}