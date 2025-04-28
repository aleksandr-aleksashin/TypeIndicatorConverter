using System.Text.Json.Serialization;
using TypeIndicatorConverter.Core.Attribute;
using Newtonsoft.Json;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NamingAttributes;

public class NamingAttributesTest1 : NamingAttributesBaseTest
{
    [TypeIndicator]
    public string Type7 => "Type7";
    [TypeIndicator]
    public string Type8 => null;
    [TypeIndicator(comparingOptions: ComparingOptions.UnknownValue)]
    public string Type9 => null;
    [TypeIndicator(comparingOptions: ComparingOptions.UnknownValue)]
    [JsonProperty(PropertyName = "Type_10")]
    [JsonPropertyName("Type_10")]
    public string Type10 => null;
}