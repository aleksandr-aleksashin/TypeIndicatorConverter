using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.MultiplyIndicators;

public class MultiplyIndicatorsTest1 : MultiplyIndicatorsBaseTest
{
    [TypeIndicator]
    public string Type1 => "Type1";
}