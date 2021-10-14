using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
    [JsonConverter(typeof(TypeIndicatorConverter<BaseEightIndicatorTypeIndicatorAbstract>))]
    public abstract class BaseEightIndicatorTypeIndicatorAbstract
    {
    }
}
