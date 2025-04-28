using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels;

public class SecondClass : BaseTypeIndicatorAbstract
{
    [TypeIndicator]
    public override string Type { get; } = nameof(SecondClass);
}