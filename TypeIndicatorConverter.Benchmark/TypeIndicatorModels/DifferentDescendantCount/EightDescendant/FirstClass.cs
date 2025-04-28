using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant;

public class FirstClass : BaseEightIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(FirstClass);
}