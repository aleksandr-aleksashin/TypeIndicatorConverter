using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models;

public class Division : BaseExpression
{
    [TypeIndicator]
    public string Type => "Division";
    public BaseExpression LeftOperand { get; set; }
    public BaseExpression RightOperand { get; set; }
    public override double Eval() => LeftOperand.Eval() / RightOperand.Eval();
    public override string ToString() => $"(({LeftOperand}) / ({RightOperand}))";
}