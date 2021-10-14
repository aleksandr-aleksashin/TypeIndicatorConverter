using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    public class FourClass : BaseFourIndicatorTypeIndicatorAbstract
    {
        [TypeIndicator]
        public string Type { get; } = nameof(FirstClass);
        [TypeIndicator]
        public string Type1 { get; } = nameof(FirstClass);
        [TypeIndicator]
        public string Type2 { get; } = nameof(FirstClass);
        [TypeIndicator]
        public string Type3 { get; } = nameof(FirstClass);
    }
}
