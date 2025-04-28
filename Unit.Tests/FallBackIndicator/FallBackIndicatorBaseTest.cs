using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.FallBackIndicator;

[ExcludeFromCodeCoverage]
[AmbiguousMatching()]
[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<FallBackIndicatorBaseTest>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<FallBackIndicatorBaseTest>))]
public abstract class FallBackIndicatorBaseTest
{
}