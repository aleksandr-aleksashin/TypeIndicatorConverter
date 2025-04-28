using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyAllowed;

[ExcludeFromCodeCoverage]
[AmbiguousMatching(true)]
[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<MultiplyAllowedBaseTest>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<MultiplyAllowedBaseTest>))]
public abstract class MultiplyAllowedBaseTest
{
}