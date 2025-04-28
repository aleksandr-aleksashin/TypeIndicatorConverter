using JsonKnownTypes;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.JsonKnownTypes;

[JsonConverter(typeof(JsonKnownTypesConverter<BaseKnownTypesAbstract>))]
[JsonDiscriminator(Name = "Type")]
public abstract class BaseKnownTypesAbstract
{
    public abstract string Type { get; }
}