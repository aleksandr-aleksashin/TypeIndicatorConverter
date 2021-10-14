using DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models;
using Newtonsoft.Json;
using Xunit;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator
{
    public class CalculatorTest
    {
        [Theory]
        [InlineData("{\"Type\":\"Addition\",\"LeftOperand\":{\"Type\":\"Const\",\"Value\":1.0},\"RightOperand\":{\"Type\":\"Multiplication\",\"LeftOperand\":{\"Type\":\"Division\",\"LeftOperand\":{\"Type\":\"Const\",\"Value\":6.0},\"RightOperand\":{\"Type\":\"Const\",\"Value\":2.0}},\"RightOperand\":{\"Type\":\"Const\",\"Value\":6.0}}}",
                    "((1) + (((((6) / (2))) * (6))))",
                    19)]
        [InlineData("{\"Type\":\"Const\",\"ConstantName\":\"PI\"}",
                    "3,141592653589793",
                    3.141592653589793)]
        [InlineData("{\"ConstantName\":\"PI\"}",
                    "3,141592653589793",
                    3.141592653589793)]
        [InlineData("{\"Type\":\"Const\",\"Value\":2}",
                    "2",
                    2)]
        [InlineData("{\"Type\":\"ZeroFunction\"}",
                    "UnknownExpression",
                    double.NaN)]
        public void ArticleTest(string json, string expectedToString, double expectedEvalValue)
        {
            var newtonSoftJson = JsonConvert.DeserializeObject<BaseExpression>(json);
            var systemTextJson = JsonSerializer.Deserialize<BaseExpression>(json);
            Assert.Equal(expectedToString, newtonSoftJson.ToString());
            Assert.Equal(expectedToString, systemTextJson.ToString());
            Assert.Equal(expectedEvalValue, newtonSoftJson.Eval());
            Assert.Equal(expectedEvalValue, systemTextJson.Eval());
        }
    }
}
