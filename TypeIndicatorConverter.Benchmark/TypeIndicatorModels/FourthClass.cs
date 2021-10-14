using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels
{
    public class FourthClass : BaseTypeIndicatorAbstract
    {
        [TypeIndicator]
        public override string Type { get; } = nameof(FourthClass);
    }
}
