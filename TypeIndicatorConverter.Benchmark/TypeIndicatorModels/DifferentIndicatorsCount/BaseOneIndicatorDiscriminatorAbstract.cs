using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseOneIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseOneIndicatorTypeIndicatorAbstract
    {
    }
}
