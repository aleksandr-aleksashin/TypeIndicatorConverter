using System;
using TypeIndicatorConverter.Core;
using TypeIndicatorConverter.Core.Attribute;
using TypeIndicatorConverter.NewtonsoftJson;
using Newtonsoft.Json;
using Xunit;

namespace DashaAI.TypeIndicatorConverter.Unit.Tests.ReadmeTest;

public class ReadMeCustomFieldTest
{
    [JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
    private abstract class FigureBase
    {
        public abstract string Draw();
    }
    private class Cartesian2DPoint
    {
        public double? X { get; set; }
        public double? Y { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is not Cartesian2DPoint point)
            {
                return false;
            }
            return (this.X == point.X) && (this.Y == point.Y);
        }
    }
    private class RadialPoint
    {
        public double? R { get; set; }
        public double? Phi { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is not RadialPoint point)
            {
                return false;
            }
            return (this.R == point.R) && (this.Phi == point.Phi);
        }
    }
    private class CircleCartesian : FigureBase
    {
        [TypeIndicator]
        public string FigureType => "Circle";
        [TypeIndicator]
        public Cartesian2DPoint Point { get; } = new() { X = 0, Y = 0 };
        public double Radius { get; set; }
        public override string Draw()
        {
            return $"Circle in cartesian point ({Point.X},{Point.Y}) with radius {Radius}";
        }
    }
    private class CircleRadial : FigureBase
    {
        [TypeIndicator]
        public string FigureType => "Circle";
        [TypeIndicator]
        public RadialPoint Point { get; } = new() { R = 0, Phi = 0 };
        public double Radius { get; set; }
        public override string Draw()
        {
            return $"Circle in radial point ({Point.R},{Point.Phi}) with radius {Radius}";
        }
    }
    [Theory]
    [InlineData("{\"FigureType\":\"Circle\",\"Point\":{\"X\":0.0,\"Y\":0.0},\"Radius\":0.0}",
                "Circle in cartesian point (0,0) with radius 0",
                typeof(CircleCartesian))]
    [InlineData("{\"FigureType\":\"Circle\",\"Point\":{\"R\":0.0,\"Phi\":0.0},\"Radius\":0.0}",
                "Circle in radial point (0,0) with radius 0",
                typeof(CircleRadial))]
    [InlineData("{\"FigureType\":\"Circle\",\"Point\":{},\"Radius\":0.0}",
                "Circle in radial point (0,0) with radius 0",
                typeof(CircleCartesian), true)]
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