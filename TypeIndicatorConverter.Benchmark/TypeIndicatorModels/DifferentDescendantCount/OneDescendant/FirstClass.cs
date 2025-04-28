using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.OneDescendant;

public class FirstClass : BaseOneIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(FirstClass);
}