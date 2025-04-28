using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.JsonPropertyName;

[ExcludeFromCodeCoverage]
[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<JsonPropertyNameBaseTest>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<JsonPropertyNameBaseTest>))]
public abstract class JsonPropertyNameBaseTest
{
}