using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.AnyNullHandle
{
    public class AnyNullHandleTest2 : AnyNullHandleBaseTest
    {
        [TypeIndicator]
        public string Type1 => null;
        [TypeIndicator(comparingOptions: ComparingOptions.UnknownValue)]
        public string Type2 => null;
    }
}
