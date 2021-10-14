using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TypeIndicatorConverter.Core.Attribute;
using Newtonsoft.Json;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.JsonPropertyName
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class JsonPropertyNameTest2 : JsonPropertyNameBaseTest
    {
        [TypeIndicator]
        [DataMember(Name = "Type_1")]
        [JsonProperty(PropertyName = "Type_")]
        [JsonPropertyName("Type_")]
        public string Type => "Type2";
    }
}
