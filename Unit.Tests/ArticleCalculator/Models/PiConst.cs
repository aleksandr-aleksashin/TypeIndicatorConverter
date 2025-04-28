using System;
using TypeIndicatorConverter.Core.Attribute;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ArticleCalculator.Models;

public class PiConst : BaseExpression
{
    // [JsonProperty(NullValueHandling = NullValueHandling.Ignore)] // for Newtonsoft.Json
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)] // for System.Text.Json
    [TypeIndicator(ComparingOptions.AllowNotExist)]
    public string Type => "Const";
    [TypeIndicator]
    public string ConstantName => "PI";
    public override double Eval() => Math.PI;
    public override string ToString() => Math.PI.ToString();
}