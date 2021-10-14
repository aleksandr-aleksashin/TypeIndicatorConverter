using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models
{
    [IgnoreIndicators]
    public class UnifiedRectangle : Rectangle
    {
        public UnifiedRectangle(Square square)
        {
            OneSide = square.Side;
            OtherSide = square.Side;
        }
        public UnifiedRectangle(Rectangle rectangle)
        {
            OneSide = rectangle.OneSide;
            OtherSide = rectangle.OtherSide;
        }
    }
}
