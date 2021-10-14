using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyDeallowed
{
    [ExcludeFromCodeCoverage]
    [AmbiguousMatching()]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<MultiplyDeAllowedBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<MultiplyDeAllowedBaseTest>))]
    public abstract class MultiplyDeAllowedBaseTest
    {
    }
}
