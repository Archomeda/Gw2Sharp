using BenchmarkDotNet.Attributes;
using Gw2Sharp.Json;

namespace Gw2Sharp.Benchmarks
{
    [MedianColumn]
    [MemoryDiagnoser]
    public class SnakeCaseJsonNamingPolicyBenchmark
    {
        private const int OPERATIONS_PER_INVOKE = 1_000_000;
        private static readonly SnakeCaseNamingPolicy policy = SnakeCaseNamingPolicy.SnakeCase;
        private const string CONVENTIONAL_PROPERTY_NAME = "HypotheticalPropertyNameWithUnrealisticlyManyWords";
        private const string UNCONVENTIONAL_PROPERTY_NAME = "HyPOThETicAl_PRopeRtYnAmE_wiThUNReAlisTicLyMaNy_wOrDs";
        private object? dump;

        [Benchmark(OperationsPerInvoke=OPERATIONS_PER_INVOKE)]
        public object? ConvertConventionalPropertyNameFast()
        {
            for (int i = 0; i < OPERATIONS_PER_INVOKE; ++i)
            {
                this.dump = policy.ConvertName(CONVENTIONAL_PROPERTY_NAME);
            }

            return this.dump;
        }

        [Benchmark(OperationsPerInvoke=OPERATIONS_PER_INVOKE)]
        public object? ConvertUnconventionalPropertyNameFast()
        {
            for (int i = 0; i < OPERATIONS_PER_INVOKE; ++i)
            {
                this.dump = policy.ConvertName(UNCONVENTIONAL_PROPERTY_NAME);
            }

            return this.dump;
        }
    }
}
