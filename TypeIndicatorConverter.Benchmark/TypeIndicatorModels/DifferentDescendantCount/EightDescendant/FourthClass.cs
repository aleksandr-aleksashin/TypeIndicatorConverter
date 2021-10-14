using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant
{
    public class FourthClass : BaseEightIndicatorTypeIndicatorAbstract
    {
        [TypeIndicator]
        public string Type { get; } = nameof(FourthClass);
    }
}
