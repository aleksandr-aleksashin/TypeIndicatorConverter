using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseEightIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseEightIndicatorTypeIndicatorAbstract
    {
    }
}
