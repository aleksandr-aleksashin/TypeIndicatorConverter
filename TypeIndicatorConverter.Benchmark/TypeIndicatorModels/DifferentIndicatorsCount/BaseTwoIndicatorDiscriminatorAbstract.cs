using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseTwoIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseTwoIndicatorTypeIndicatorAbstract
    {
    }
}
