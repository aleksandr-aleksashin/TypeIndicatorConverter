using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.OneDescendant
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseOneIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseOneIndicatorTypeIndicatorAbstract
    {
    }
}
