using TypeIndicatorConverter.Core.Attribute;
using Newtonsoft.Json;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models
{
    public class Subtraction : BaseExpression
    {
        [TypeIndicator]
        public string Type => "Subtraction";
        public BaseExpression LeftOperand { get; set; }
        public BaseExpression RightOperand { get; set; }
        public override double Eval() => LeftOperand.Eval() - RightOperand.Eval();
        public override string ToString() => $"(({LeftOperand}) - ({RightOperand}))";
    }
}
