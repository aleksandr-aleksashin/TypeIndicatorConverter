using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.TwoDescendant
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseTwoIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseTwoIndicatorTypeIndicatorAbstract
    {
    }
}
