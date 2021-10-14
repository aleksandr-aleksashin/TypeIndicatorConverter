using System;
using BenchmarkDotNet.Running;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentDescendantCount;
using TypeIndicatorConverter.Benchmark.TypeIndicatorConverterModels.DifferentIndicatorsCount;

namespace TypeIndicatorConverter.Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BenchmarkRunner.Run<BenchmarkOneObject>());
            Console.WriteLine(BenchmarkRunner.Run<BenchmarkDifferentDescendantObject>());
            Console.WriteLine(BenchmarkRunner.Run<BenchmarkDifferentIndicatorsCountObject>());
        }
    }
}
