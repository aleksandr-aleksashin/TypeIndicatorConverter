using BenchmarkDotNet.Attributes;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount
{
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
    public class BenchmarkDifferentIndicatorsCountObject
    {
        private string OneTypeIndicatorField { get; }
        private string TwoTypeIndicatorFields { get; }
        private string FourthTypeIndicatorFields { get; }
        private string EightTypeIndicatorFields { get; }

        public BenchmarkDifferentIndicatorsCountObject()
        {
            OneTypeIndicatorField = JsonConvert.SerializeObject(new OneClass());
            TwoTypeIndicatorFields = JsonConvert.SerializeObject(new TwoClass());
            FourthTypeIndicatorFields = JsonConvert.SerializeObject(new FourClass());
            EightTypeIndicatorFields = JsonConvert.SerializeObject(new EightClass());
        }

        [Benchmark(Description = "Object with 1 discriminating field")]
        public void TypeIndicatorConverterOneField()
        {
            JsonConvert.DeserializeObject<BaseOneIndicatorTypeIndicatorAbstract>(OneTypeIndicatorField);
        }

        [Benchmark(Description = "Object with 2 discriminating fields")]
        public void TypeIndicatorConverterTwoField()
        {
            JsonConvert.DeserializeObject<BaseTwoIndicatorTypeIndicatorAbstract>(TwoTypeIndicatorFields);
        }

        [Benchmark(Description = "Object with 4 discriminating fields")]
        public void TypeIndicatorConverterFourField()
        {
            JsonConvert.DeserializeObject<BaseFourIndicatorTypeIndicatorAbstract>(FourthTypeIndicatorFields);
        }

        [Benchmark(Description = "Object with 8 discriminating fields")]
        public void TypeIndicatorConverterEightField()
        {
            JsonConvert.DeserializeObject<BaseEightIndicatorTypeIndicatorAbstract>(EightTypeIndicatorFields);
        }
    }
}
