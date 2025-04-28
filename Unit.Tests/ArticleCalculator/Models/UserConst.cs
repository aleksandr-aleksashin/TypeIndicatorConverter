using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models;

public class UserConst : BaseExpression
{
    [TypeIndicator]
    public string Type => "Const";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double Value { get; set; }
    public override double Eval() => Value;
    public override string ToString() => Value.ToString();
}