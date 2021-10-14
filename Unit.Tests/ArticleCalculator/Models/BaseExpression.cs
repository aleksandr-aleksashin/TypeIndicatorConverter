using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models
{
    [System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<BaseExpression>))]
    [Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<BaseExpression>))]
    public abstract class BaseExpression
    {
        public abstract double Eval();
    }
}
