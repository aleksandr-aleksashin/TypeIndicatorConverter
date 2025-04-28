using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.FallBackIndicator;

public class FallBackIndicatorTest2 : FallBackIndicatorBaseTest
{
    [TypeIndicator]
    public string Type1 => "Type1";
}