using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using TypeIndicatorConverter.Core.Attribute;
using Newtonsoft.Json;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.JsonPropertyName;

[ExcludeFromCodeCoverage]
public class JsonPropertyNameTest1 : JsonPropertyNameBaseTest
{
    [TypeIndicator]
    [JsonProperty(PropertyName = "Type_")]
    [JsonPropertyName("Type_")]
    public string Type => "Type";
}