using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models;

[FallbackIndicator]
public class UnknownExpression : BaseExpression
{
    public string Type { get; set; }
    public override double Eval() => double.NaN;
    public override string ToString() => "UnknownExpression";
}