using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels
{
    public class ThirdClass : BaseTypeIndicatorAbstract
    {
        [TypeIndicator]
        public override string Type { get; } = nameof(ThirdClass);
    }
}
