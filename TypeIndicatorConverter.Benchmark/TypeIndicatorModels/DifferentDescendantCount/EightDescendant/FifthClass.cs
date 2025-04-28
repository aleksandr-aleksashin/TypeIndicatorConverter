using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant;

public class FifthClass : BaseEightIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(FifthClass);
}