using JsonSubTypes;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.JsonSubTypesModels
{
    [JsonConverter(typeof(JsonSubtypes), "Type")]
    [JsonSubtypes.KnownSubType(typeof(FirstClass), nameof(FirstClass))]
    [JsonSubtypes.KnownSubType(typeof(SecondClass), nameof(SecondClass))]
    [JsonSubtypes.KnownSubType(typeof(ThirdClass), nameof(ThirdClass))]
    [JsonSubtypes.KnownSubType(typeof(FourthClass), nameof(FourthClass))]
    public abstract class BaseSubTypesAbstract
    {
        public abstract string Type { get; }
    }
}
