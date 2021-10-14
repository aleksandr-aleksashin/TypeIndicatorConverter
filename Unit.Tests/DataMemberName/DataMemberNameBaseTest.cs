using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.DataMemberName
{
    [ExcludeFromCodeCoverage]
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<DataMemberNameBaseTest>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<DataMemberNameBaseTest>))]
    public abstract class DataMemberNameBaseTest
    {
    }
}
