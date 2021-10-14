using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyDeallowed
{
    [ExcludeFromCodeCoverage]
    public class MultiplyDeAllowedTest1 : MultiplyDeAllowedBaseTest
    {
        [TypeIndicator]
        public string Test => "Test";
    }
}
