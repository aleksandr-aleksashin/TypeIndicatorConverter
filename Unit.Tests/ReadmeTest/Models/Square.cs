using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models;

public class Square : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double Side { get; set; }
    public override string Draw()
    {
        return $"Square with side {Side}";
    }
}