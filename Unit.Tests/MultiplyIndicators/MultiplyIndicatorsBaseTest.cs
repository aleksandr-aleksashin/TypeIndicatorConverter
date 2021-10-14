using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.MultiplyIndicators
{
    [ExcludeFromCodeCoverage]
    [AmbiguousMatching(allowMultiplySelection: true)]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<MultiplyIndicatorsBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<MultiplyIndicatorsBaseTest>))]
    public abstract class MultiplyIndicatorsBaseTest
    {
    }
}
