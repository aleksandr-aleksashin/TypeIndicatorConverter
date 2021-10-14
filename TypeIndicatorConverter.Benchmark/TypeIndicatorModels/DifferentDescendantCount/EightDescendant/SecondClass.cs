using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant
{
    public class SecondClass : BaseEightIndicatorTypeIndicatorAbstract
    {
        [TypeIndicator]
        public string Type { get; } = nameof(SecondClass);
    }
}
