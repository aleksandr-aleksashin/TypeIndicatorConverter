using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.FourDescendant
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseFourIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseFourIndicatorTypeIndicatorAbstract
    {
    }
}
