using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models
{
    public class Point : FigureBase
    {
        [TypeIndicator]
        public string FigureType => "Point";
        [TypeIndicator(ComparingOptions.UnknownValue | ComparingOptions.AllowNotExist)]
        public double? PositionX { get; set; }
        public override string Draw()
        {
            return $"Point with position {PositionX}";
        }
    }
}
