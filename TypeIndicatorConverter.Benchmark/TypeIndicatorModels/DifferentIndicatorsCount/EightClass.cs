using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount;

public class EightClass : BaseEightIndicatorTypeIndicatorAbstract
{
    [TypeIndicator]
    public string Type { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type1 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type2 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type3 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type4 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type5 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type6 { get; } = nameof(FirstClass);
    [TypeIndicator]
    public string Type7 { get; } = nameof(FirstClass);
}