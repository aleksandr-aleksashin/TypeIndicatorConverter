using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models
{
    public class Circle : FigureBase
    {
        [TypeIndicator]
        public string FigureType => "Circle";
        public double Radius { get; set; }
        public override string Draw()
        {
            return $"Circle with radius {Radius}";
        }
    }
}
