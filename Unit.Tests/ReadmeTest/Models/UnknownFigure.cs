using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models
{
    [FallbackIndicator]
    public class UnknownFigure : FigureBase
    {
        public override string Draw()
        {
            return $"UnknownFigure";
        }
    }
}
