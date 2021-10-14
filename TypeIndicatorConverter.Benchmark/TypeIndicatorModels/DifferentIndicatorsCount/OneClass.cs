using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    public class OneClass : BaseOneIndicatorTypeIndicatorAbstract
    {
        [TypeIndicator]
        public string Type { get; } = nameof(FirstClass);
    }
}
