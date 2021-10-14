using TypeIndicatorConverter.Core.Attribute;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.TwoDescendant
{
    public class SecondClass : BaseTwoIndicatorTypeIndicatorAbstract
    {
        [TypeIndicator]
        public string Type { get; } = nameof(SecondClass);
    }
}
