# TypeIndicator converter
 - [![lisence](https://img.shields.io/badge/lisence-MIT-green?style=flat-square)](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/blob/master/LICENSE)
- Core library:
[![nuget core](https://img.shields.io/nuget/v/TypeIndicatorConverter.Core)](https://www.nuget.org/packages/TypeIndicatorConverter.Core)
[![downloads core](https://img.shields.io/nuget/dt/TypeIndicatorConverter.Core)](https://www.nuget.org/packages/TypeIndicatorConverter.Core)
- Newtonsoft.Json implimentation
[![nuget NewtonsoftJson](https://img.shields.io/nuget/v/TypeIndicatorConverter.NewtonsoftJson)](https://www.nuget.org/packages/TypeIndicatorConverter.NewtonsoftJson)
[![downloads NewtonsoftJson](https://img.shields.io/nuget/dt/TypeIndicatorConverter.NewtonsoftJson)](https://www.nuget.org/packages/TypeIndicatorConverter.NewtonsoftJson)
- System.Text.Json implementation
[![nuget Text.Json](https://img.shields.io/nuget/v/TypeIndicatorConverter.TextJson)](https://www.nuget.org/packages/TypeIndicatorConverter.TextJson)
[![downloads Text.Json](https://img.shields.io/nuget/dt/TypeIndicatorConverter.TextJson)](https://www.nuget.org/packages/TypeIndicatorConverter.TextJson)

These packages help you to serialize and deserialize polymorphic types. Choosing type by indicator(discriminator) fields describing in C# classes.

- [Advantages](#Advantages)
- [Requirements](#Requirements)
- [Documentation](#Documentation)
  - [Getting started](#getting-started)
  - [Using with interfaces or abstract class or non-abstract class](#using-with-interfaces-or-abstract-class-or-non-abstract-class)
  - [TypeIndicatorAttribute](#TypeIndicatorAttribute)
  - [AmbiguousMatchingAttribute](#AmbiguousMatchingAttribute)
  - [Support non-basic type](#support-non-basic-type)
  - [FallbackIndicatorAttribute](#FallbackIndicatorAttribute)
  - [IgnoreIndicatorsAttribute](#IgnoreIndicatorsAttribute)
  - [Supports Attributes](#supports-attributes)
- [Suggestions and Reports](#suggestions-and-reports)
- [Benchmarks](#benchmarks)
- [License](#License)

## Requirements
- For [Json.NET](https://github.com/JamesNK/Newtonsoft.Json) you can use [this project](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/tree/master/Json.Net) which have compitability with net5.0; net45; net46; net47; net48; netcoreapp3.1; netcoreapp3.0; netstandard2.0; netstandard2.1
- For [System.Text.Json](https://docs.microsoft.com/ru-ru/dotnet/api/system.text.json) you can use [this project](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/tree/master/Text.Json) which have compitability with net5.0; net47; net48; netcoreapp3.1; netcoreapp3.0; netstandard2.0; netstandard2.1

## Advantages
### Extendable for other serializers
[TypeIndicatorConverter.Core](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/tree/master/Core) contains main logic and abstractions which can be used for adding support to another serializer. If you need another serializer with logic like in this package then you can add your implementation.

### Count of indicator(discriminator) fields
- Many solutions allow only one indicator(discriminator) field for the type. For example, the packages [JsonKnownTypes](https://github.com/dmitry-bym/JsonKnownTypes) and [JsonSubTypes](https://github.com/manuc66/JsonSubTypes). [See usage in TypeIndicatorAttribute examples](#TypeIndicatorAttribute)
- Also, many solutions support only string or basic types of indicator(discriminator) fields. [Support non-basic type](#support-non-basic-type).
- Additionally, many solutions ignore the overriding names of properties by specialized attributes and settings of serializers. [Example of respecting specialized attributes](#supports-attributes).

In this solution, many indicator(discriminator) fields can be used for the type. In addition, this solution respects some settings of the serializer for working with the field name.

## Documentation
Below are examples of using mostly a package working with `Newtonsoft.Json`, but with some notes for `System.Text.Json` package.

### Getting started
The simplest way to use this package is by adding one attribute to the base class or interface and one attribute for descendant classes:
```C#
[JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
public abstract class FigureBase
{
    public abstract string Draw();
}
public class Circle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Circle";
    public double Radius { get; set; }
    public override string Draw()
    {
        return $"Circle with radius {Radius}";
    }
}
public class Rectangle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    public double OneSide { get; set; }
    public double OtherSide { get; set; }
    public override string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}
```
Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Circle\",\"Radius\":2}").Draw()); // Circle with radius 2
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"OtherSide\":3}").Draw()); // Rectangle with one side 2 and other side 3
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{}").Draw()); // throws TypeIndicatorConverterException
```
### Using with interfaces or abstract class or non-abstract class
You can use interfaces, non-abstract or abstract classes as the base type.   
Every class that derives from a base type must have at least one `[TypeIndicator]` or only one `[FallbackIndicator]` attribute.  
Restriction: each class that derives from a base type must have an at least one parameterless constructor.

```C#
[JsonConverter(typeof(TypeIndicatorConverter<IFigureBase>))]
public interface IFigureBase
{
    string Draw();
}
public class Circle : IFigureBase
{
    [TypeIndicator]
    public string FigureType => "Circle";
    public double Radius { get; set; }
    public override string Draw()
    {
        return $"Circle with radius {Radius}";
    }
}
public class Rectangle : IFigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    public double OneSide { get; set; }
    public double OtherSide { get; set; }
    public string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}
```
Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<IFigureBase>("{\"FigureType\":\"Circle\",\"Radius\":2}").Draw()); // Circle with radius 2
Console.WriteLine(JsonConvert.DeserializeObject<IFigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"OtherSide\":3}").Draw()); // Rectangle with one side 2 and other side 3
Console.WriteLine(JsonConvert.DeserializeObject<IFigureBase>("{}").Draw()); // throws TypeIndicatorConverterException
```
### TypeIndicatorAttribute
You can add an indicators to your class using `[TypeIndicator]`. You can use many indicator(discriminator) fields in the class.

`TypeIndicatorAttribute` has enum flag options which strategy must be used for compare.
```C#
[Flags]
public enum ComparingOptions
{
    Default = 0, // Default behavior. Comparison of the field value and the expected value.
    UnknownValue = 1, // Do not compare actual and expected values. Checks only for the presence of a field in an object.
    AllowNotExist = 2, // The absence of a field in the input data is allowed.
}
```

```C#
[JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
public abstract class FigureBase
{
    public abstract string Draw();
}
public class Rectangle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double OneSide { get; set; }
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double OtherSide { get; set; }
    public override string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}
public class Square : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double Side { get; set; }
    public override string Draw()
    {
        return $"Square with side {Side}";
    }
}
public class Point : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Point";
    [TypeIndicator(ComparingOptions.UnknownValue | ComparingOptions.AllowNotExist)]
    public double? PositionX { get; set; }
    public override string Draw()
    {
        return $"Point with position {PositionX}";
    }
}
```

Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<IFigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"OtherSide\":3}").Draw()); // Rectangle with one side 2 and other side 3
Console.WriteLine(JsonConvert.DeserializeObject<IFigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2,\"Side\":3}").Draw()); // Square with side 3
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Point\"}").Draw()); // Point with position 
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Point\",\"PositionX\":2}")).Draw()); // Point with position 2
```

More examples of usage `TypeIndicatorAttribute` can be find in [Tests](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/tree/master/Unit.Tests)
### AmbiguousMatchingAttribute
If you have ambiguous type matching and want exception-free behavior you can use `AmbiguousMatchingAttribute` for the base class.
By default, multiply matching is disabled but you can pass an argument into the attribute `[AmbiguousMatching(true)]` (defaults `[AmbiguousMatching(false)]`).
The behavior with this parameter is as follows:
- If many classes are suitable, then the one with more indicator fields is selected;
- If the number of indicator fields is the same, then the first class is selected from the list of the class name sorted in descending order.

See example of amiguous behavior:

```C#
[JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
public abstract class FigureBase
{
    public abstract string Draw();
}
public class Rectangle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    public double OneSide { get; set; }
    public double OtherSide { get; set; }
    public override string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}
public class Square : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double Side { get; set; }
    public override string Draw()
    {
        return $"Square with side {Side}";
    }
}
```

Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2.0,\"OtherSide\":3.0}").Draw()); // throws TypeIndicatorException
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2.0,\"Side\":3.0}").Draw()); // throws TypeIndicatorException
```

```C#
[JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
[AmbiguousMatching(true)]
public abstract class FigureBase
{
    public abstract string Draw();
}
public class Rectangle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    public double OneSide { get; set; }
    public double OtherSide { get; set; }
    public override string Draw()
    {
        return $"Rectangle with one side {OneSide} and other side {OtherSide}";
    }
}
public class Square : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Rectangle";
    [TypeIndicator(ComparingOptions.UnknownValue)]
    public double Side { get; set; }
    public override string Draw()
    {
        return $"Square with side {Side}";
    }
}
```
Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2.0,\"OtherSide\":3.0}").Draw()); // Rectangle with one side 2 and other side 3
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Rectangle\",\"OneSide\":2.0,\"Side\":3.0}").Draw()); // Square with side 3
```
### Support non-basic type
At the moment, the library has partial support for non-basic types as indicators fields with some restrictions. Non-basic types compare by [Equals](https://docs.microsoft.com/ru-ru/dotnet/api/system.object.equals) method.

```C#
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
        if (obj == null)
        {
            return false;
        }
        if (!(obj is Cartesian2DPoint point))
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
        if (obj == null)
        {
            return false;
        }
        if (!(obj is RadialPoint point))
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
```

Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Circle\",\"Point\":{\"X\":0.0,\"Y\":0.0},\"Radius\":0.0}").Draw()); // Circle in cartesian point (0,0) with radius 0
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Circle\",\"Point\":{\"R\":0.0,\"Phi\":0.0},\"Radius\":0.0}").Draw()); // Circle in radial point (0,0) with radius 0
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Circle\",\"Point\":{},\"Radius\":0.0}").Draw()); // throws TypeIndicatorException
```
### FallbackIndicatorAttribute
By default, you will get an exception if none of the types are selected during deserialization.

If you need an exception-free way you can use `FallbackIndicatorAttribute` attribute. In that case, entities marked with unknown or missing types will be deserialized to specified fallback type.

Example of usage `FallbackIndicatorAttribute`:
```C#
[JsonConverter(typeof(TypeIndicatorConverter<FigureBase>))]
public abstract class FigureBase
{
    public abstract string Draw();
}
public class Circle : FigureBase
{
    [TypeIndicator]
    public string FigureType => "Circle";
    public double Radius { get; set; }
    public override string Draw()
    {
        return $"Circle with radius {Radius}";
    }
}

[FallbackIndicator]
public class UnknownFigure : FigureBase
{
    public override string Draw()
    {
        return $"UnknownFigure";
    }
}
```

Serialization and Deserialization:
```C#
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{\"FigureType\":\"Circle\",\"Radius\":2.0}").Draw()); // Circle with radius 2
Console.WriteLine(JsonConvert.DeserializeObject<FigureBase>("{}").Draw()); // UnknownFigure
```
### IgnoreIndicatorsAttribute
You can remove from the list of types for deserialization using the attribute `IgnoreIndicatorsAttribute`.

```C#
[IgnoreIndicators]
public class UnifiedRectangle : Rectangle
{
    public UnifiedRectangle(Square square)
    {
        OneSide = square.Side;
        SecondSide = square.Side;
    }
    public UnifiedRectangle(Rectangle rectangle)
    {
        OneSide = rectangle.OneSide;
        SecondSide = rectangle.SecondSide;
    }
}
```
### Supports Attributes
By default, the field name is the class property name.  

For `Newtonsoft.Json` supports `JsonPropertyAttribute` and `DataMemberAttribute` for overriding property name. If both attributes exist on the property then used `JsonPropertyAttribute`. Also, this package respecting settings for the naming case and `NamingStrategy`.  

For `System.Text.Json` supports `JsonPropertyNameAttribute`. Also, this package respecting `PropertyNamingPolicy` and `PropertyNameCaseInsensitive` settings.
## Benchmarks
You can find code of benchmarks [here](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/tree/master/TypeIndicatorConverter.Benchmark);
We compare this solution, [JsonKnownTypes](https://github.com/dmitry-bym/JsonKnownTypes) and [JsonSubTypes](https://github.com/manuc66/JsonSubTypes) in two case:
- Base class have four heirs and deserialize one object and direct deserialize;

Also, benchmarking dependence on different indicators count in class (1,2,4,8);
And benchmarking on the classes have one typeIndicator field by different count of descendent(1,2,4,8);  

``` ini
BenchmarkDotNet=v0.13.1, OS=Windows 10.0.19043.1237 (21H1/May2021Update)
11th Gen Intel Core i7-11700K 3.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=5.0.400
  [Host]    : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  MediumRun : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
  ShortRun  : .NET 5.0.9 (5.0.921.35908), X64 RyuJIT
```
### First case
Base class have four heirs and deserialize one object;

|                                                         Method |        Mean |       Error |   StdDev |
|--------------------------------------------------------------- |------------:|------------:|---------:|
|      &#39;TypeIndicatorConverter 1 indicators field 4 descendants&#39; |  3,369.2 ns |    32.69 ns | 46.88 ns |
|              &#39;JsonKnownTypes 1 indicators field 4 descendants&#39; |  1,876.4 ns |    39.04 ns | 57.23 ns |
|       &#39;JsonSubTypesConverter 1 indicators field 4 descendants&#39; | 11,538.7 ns |    41.90 ns | 60.08 ns |
| &#39;Direct type deserialization 1 indicators field 4 descendants&#39; |    523.3 ns |     4.05 ns |  5.68 ns |

### Second case
Benchmarking cost dependence on different indicators count in class (1,2,4,8).

|                                Method |     Mean |     Error |    StdDev |
|-------------------------------------- |---------:|----------:|----------:|
|  &#39;Object with 1 indicator field&#39; | 1.916 μs | 0.0193 μs | 0.0276 μs |
| &#39;Object with 2 indicator fields&#39; | 2.623 μs | 0.0300 μs | 0.0440 μs |
| &#39;Object with 4 indicator fields&#39; | 3.972 μs | 0.0635 μs | 0.0950 μs |
| &#39;Object with 8 indicator fields&#39; | 6.443 μs | 0.0351 μs | 0.0503 μs |

### Third case
Benchmarking on the classes having one typeIndicator field by different count of descendent(1,2,4,8).

|                                                Method |     Mean |     Error |    StdDev |
|------------------------------------------------------ |---------:|----------:|----------:|
| &#39;Object has 1 indicator fields and 1 descendants&#39; | 1.850 μs | 0.0139 μs | 0.0207 μs |
| &#39;Object has 1 indicator fields and 2 descendants&#39; | 2.507 μs | 0.0215 μs | 0.0314 μs |
| &#39;Object has 1 indicator fields and 4 descendants&#39; | 3.218 μs | 0.0598 μs | 0.0819 μs |
| &#39;Object has 1 indicator fields and 8 descendants&#39; | 4.638 μs | 0.0396 μs | 0.0581 μs |

## Suggestions and Reports

If you have a suggestion or some troubles then create an issue and describe it. Also, you can create PR to enhance the project.

## License

Authored by: Aleksashin Aleksandr (aleksandr-aleksashin)

Developed in [Dasha.AI Inc](https://dasha.ai/) (Human-like conversational AI for developers)

This project is under MIT license. You can obtain the license copy [here](https://github.com/aleksandr-aleksashin/TypeIndicatorConverter/blob/master/LICENSE).

This work using [Json.NET](https://www.newtonsoft.com/json), James Newton-King.  
This work using [System.Text.Json](https://docs.microsoft.com/ru-ru/dotnet/api/system.text.json), Microsoft Corporation.