using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NotParameterLessConstructor
{
    [ExcludeFromCodeCoverage]
    [AmbiguousMatching()]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<NotParameterLessConstructorBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<NotParameterLessConstructorBaseTest>))]
    public abstract class NotParameterLessConstructorBaseTest
    {
    }
}
