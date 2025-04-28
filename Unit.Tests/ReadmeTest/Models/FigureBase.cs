using TypeIndicatorConverter.TextJson;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models;

[System.Text.Json.Serialization.JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
[Newtonsoft.Json.JsonConverter(typeof(global::TypeIndicatorConverter.NewtonsoftJson.TypeIndicatorConverter<FigureBase>))]
public abstract class FigureBase
{
    public abstract string Draw();
}