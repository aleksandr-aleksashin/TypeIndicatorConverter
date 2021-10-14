using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using TypeIndicatorConverter.Core.Attribute;
using Newtonsoft.Json;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NamingAttributes
{
    [DataContract]
    [ExcludeFromCodeCoverage]
    public class NamingAttributesTest : NamingAttributesBaseTest
    {
        [TypeIndicator]
        public string Type => "Type";

        [TypeIndicator]
        [DataMember(Name = "Type_0")]
        public string Type0 => "Type0";

        [JsonProperty(PropertyName = "Type_1")]
        [JsonPropertyName("Type_1")]
        public string Type1 => "Type1";

        [DataMember(Name = "Type_3")]
        [JsonProperty(PropertyName = "Type_2")]
        [JsonPropertyName("Type_2")]
        public string Type2 => "Type2";
    }
}
