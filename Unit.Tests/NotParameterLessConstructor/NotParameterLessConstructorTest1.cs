using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.NotParameterLessConstructor
{
    public class NotParameterLessConstructorTest1 : NotParameterLessConstructorBaseTest
    {
        [TypeIndicator]
        public string Type1 => "Type1";

        public NotParameterLessConstructorTest1(string a)
        {
        }
    }
}
