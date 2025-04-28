using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NamingAttributes;

public class NamingAttributesTest2 : NamingAttributesBaseTest
{
    [TypeIndicator(comparingOptions: ComparingOptions.UnknownValue)]
    public string Type11 => "Type11";
}