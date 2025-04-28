using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.FallBackIndicator;

[FallbackIndicator]
public class FallBackIndicatorTest1 : FallBackIndicatorBaseTest
{
    public string Type => "Type";
}