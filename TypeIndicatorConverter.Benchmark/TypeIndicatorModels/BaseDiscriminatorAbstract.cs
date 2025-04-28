using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels;

[JsonConverter(typeof(TypeIndicatorConverter<BaseTypeIndicatorAbstract>))]
public abstract class BaseTypeIndicatorAbstract
{
    public abstract string Type { get; }
}