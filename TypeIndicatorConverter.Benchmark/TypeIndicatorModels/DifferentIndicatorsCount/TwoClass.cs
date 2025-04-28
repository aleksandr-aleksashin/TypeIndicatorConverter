using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount;

public class TwoClass : BaseTwoIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type1 { get; } = nameof(FirstClass);
}