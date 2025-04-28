using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.AnyNullHandle;

[ExcludeFromCodeCoverage]
[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<AnyNullHandleBaseTest>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<AnyNullHandleBaseTest>))]
public abstract class AnyNullHandleBaseTest
{
}