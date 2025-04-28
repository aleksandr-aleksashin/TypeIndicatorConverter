using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant;

public class ThirdClass : BaseEightIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(ThirdClass);
}