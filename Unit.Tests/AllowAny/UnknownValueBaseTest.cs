using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.AllowAny
{
    [ExcludeFromCodeCoverage]
    [AmbiguousMatching()]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<UnknownValueBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<UnknownValueBaseTest>))]
    public abstract class UnknownValueBaseTest
    {
    }
}
