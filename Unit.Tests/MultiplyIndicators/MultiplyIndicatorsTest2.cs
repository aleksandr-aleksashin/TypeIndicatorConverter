using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.MultiplyIndicators;

public class MultiplyIndicatorsTest2 : MultiplyIndicatorsBaseTest
{
    [TypeIndicator]
    public string Type1 => "Type1";
    [TypeIndicator]
    public int Type2 => 2;
}