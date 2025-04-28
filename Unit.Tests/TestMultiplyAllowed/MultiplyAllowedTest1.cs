using System.Diagnostics.CodeAnalysis;
using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.TestMultiplyAllowed;

[ExcludeFromCodeCoverage]
public class MultiplyAllowedTest1 : MultiplyAllowedBaseTest
{
    [TypeIndicator]
    public string Test => "Test";
}