using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NoTypeIndicators;

[ExcludeFromCodeCoverage]
[AmbiguousMatching()]
[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<NoTypeIndicatorsBaseTest>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<NoTypeIndicatorsBaseTest>))]
public abstract class NoTypeIndicatorsBaseTest
{
}