using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseFourIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseFourIndicatorTypeIndicatorAbstract
    {
    }
}
