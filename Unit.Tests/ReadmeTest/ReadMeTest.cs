using System;
using DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest.Models;
using TypeIndicatorConverter.Core;
using Newtonsoft.Json;
using Xunit;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest;

public class ReadMeTest
{
    [Theory]
    [InlineData("{\"FigureType\":\"Circle\",\"Radius\":2}",
                "Circle with radius 2",
                typeof(Circle))]
    [InlineData("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"OtherSide\":3}",
                "Rectangle with one side 2 and other side 3",
                typeof(Rectangle))]
    [InlineData("{\"FigureType\":\"Point\",\"PositionX\":2}",
                "Point with position 2",
                typeof(Point))]
    [InlineData("{\"FigureType\":\"Point\"}",
                "Point with position ",
                typeof(Point))]
    [InlineData("{}",
                "UnknownFigure",
                typeof(UnknownFigure))]
    [InlineData("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"Side\":3}",
                "Square with side 3",
                typeof(Square))]
    public void Test(string actualJson, string expectedDraw, Type expectedType, bool isException = false)
    {
        if (isException)
        {
            Assert.Throws<TypeIndicatorConverterException>(() => JsonConvert.DeserializeObject<FigureBase>(actualJson));
            return;
        }
        Assert.Equal(expectedDraw, JsonConvert.DeserializeObject<FigureBase>(actualJson).Draw());
        Assert.IsType(expectedType, JsonConvert.DeserializeObject<FigureBase>(actualJson));
    }
}