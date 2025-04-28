using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models;

public class Rectangle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double OneSide { get; set; }
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double OtherSide { get; set; }
    public override string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}