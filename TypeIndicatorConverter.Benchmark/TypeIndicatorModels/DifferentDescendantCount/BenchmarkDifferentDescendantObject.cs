using BenchmarkDotNet.Attributes;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.EightDescendant;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.FourDescendant;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.OneDescendant;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount.TwoDescendant;
using Newtonsoft.Json;

namespace TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount
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
    public class BenchmarkDifferentDescendantObject
    {
        private string OneObject { get; }
        private string TwoObject { get; }
        private string FourObject { get; }
        private string EigthObject { get; }


        public BenchmarkDifferentDescendantObject()
        {
            OneObject = JsonConvert.SerializeObject(new OneDescendant.FirstClass());
            TwoObject = JsonConvert.SerializeObject(new TwoDescendant.FirstClass());
            FourObject = JsonConvert.SerializeObject(new FourDescendant.FirstClass());
            EigthObject = JsonConvert.SerializeObject(new EightDescendant.FirstClass());
        }

        [Benchmark(Description = "Object has 1 TypeIndicator fields and 1 descendants")]
        public void TypeIndicatorConverterOneObject()
        {
            JsonConvert.DeserializeObject<BaseOneIndicatorTypeIndicatorAbstract>(OneObject);
        }
        [Benchmark(Description = "Object has 1 TypeIndicator fields and 2 descendants")]
        public void TypeIndicatorConverterTwoObject()
        {
            JsonConvert.DeserializeObject<BaseTwoIndicatorTypeIndicatorAbstract>(TwoObject);
        }
        [Benchmark(Description = "Object has 1 TypeIndicator fields and 4 descendants")]
        public void TypeIndicatorConverterFourObject()
        {
            JsonConvert.DeserializeObject<BaseFourIndicatorTypeIndicatorAbstract>(FourObject);
        }
        [Benchmark(Description = "Object has 1 TypeIndicator fields and 8 descendants")]
        public void TypeIndicatorConverterEightObject()
        {
            JsonConvert.DeserializeObject<BaseEightIndicatorTypeIndicatorAbstract>(EigthObject);
        }
    }
}
