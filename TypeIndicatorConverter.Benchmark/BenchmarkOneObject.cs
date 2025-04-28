using BenchmarkDotNet.Attributes;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels;
using TypeIndicatorConverter.Benchmark.JsonKnownTypes;
using TypeIndicatorConverter.Benchmark.JsonSubTypesModels;
using Newtonsoft.Json;
using FirstClass = TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.FirstClass;

namespace TypeIndicatorConverter.Benchmark;

[ShortRunJob]
[MediumRunJob]
[KeepBenchmarkFiles]
[AsciiDocExporter]
[CsvExporter]
[CsvMeasurementsExporter]
[HtmlExporter]
[PlainExporter]
[RPlotExporter]
[JsonExporterAttribute.Brief]
[JsonExporterAttribute.BriefCompressed]
[JsonExporterAttribute.Full]
[JsonExporterAttribute.FullCompressed]
[MarkdownExporterAttribute.Default]
[MarkdownExporterAttribute.GitHub]
[MarkdownExporterAttribute.StackOverflow]
[MarkdownExporterAttribute.Atlassian]
[XmlExporterAttribute.Brief]
[XmlExporterAttribute.BriefCompressed]
[XmlExporterAttribute.Full]
[XmlExporterAttribute.FullCompressed]
public class BenchmarkOneObject
{
    private string OneObjectString { get; }

    public BenchmarkOneObject()
    {
        OneObjectString = JsonConvert.SerializeObject(new FirstClass());
    }

    [Benchmark(Description = "TypeIndicatorConverter 1 indicators field 4 descendants")]
    public void TypeIndicatorConverterOneObject()
    {
        JsonConvert.DeserializeObject<BaseTypeIndicatorAbstract>(OneObjectString);
    }

    [Benchmark(Description = "JsonKnownTypes 1 indicators field 4 descendants")]
    public void JsonKnownTypesConverterOneObject()
    {
        JsonConvert.DeserializeObject<BaseKnownTypesAbstract>(OneObjectString);
    }

    [Benchmark(Description = "JsonSubTypesConverter 1 indicators field 4 descendants")]
    public void JsonSubTypesConverterOneObject()
    {
        JsonConvert.DeserializeObject<BaseSubTypesAbstract>(OneObjectString);
    }

    [Benchmark(Description = "Direct type deserialization 1 indicators field 4 descendants")]
    public void DirectTypeDeserializationOneObject()
    {
        JsonConvert.DeserializeObject<FirstClass>(OneObjectString);
    }
}