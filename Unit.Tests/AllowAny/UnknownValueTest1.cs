using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.AllowAny
{
    public class UnknownValueTest1 : UnknownValueBaseTest
    {
        [TypeIndicator]
        public string Type1 => "Type1";
        [TypeIndicator(comparingOptions: ComparingOptions.UnknownValue | ComparingOptions.AllowNotExist)]
        public int Type2 => 2;
    }
}
