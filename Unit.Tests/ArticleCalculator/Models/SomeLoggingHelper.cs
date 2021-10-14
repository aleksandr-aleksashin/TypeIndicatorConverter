using System;
using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models
{
    [IgnoreIndicators]
    public class SomeLoggingHelper : BaseExpression
    {
        private readonly BaseExpression _expression;

        public SomeLoggingHelper(BaseExpression expression)
        {
            _expression = expression;
        }
        public override double Eval()
        {
            var value = _expression.Eval();
            Console.WriteLine($"Expression: {_expression} Result: {value}");
            return value;
        }

        public override string ToString() => _expression.ToString();
    }
}
