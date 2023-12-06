using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Gw2Sharp.Benchmarks
{
    /// <summary>
    /// This benchmark essentially checks how much time
    /// it takes to retrieve items page from the cache.
    /// The page is initially loaded in <see cref="GlobalSetupAsync"/>
    /// via <see cref="Gw2Client"/> once and retrieved from the same
    /// instance during the benchmark.
    /// </summary>
    [MedianColumn]
    [MemoryDiagnoser]
    public class ItemsPageGetCachedBenchmark
    {
        private const int OPERATIONS_PER_INVOKE = 10;
        private Connection? connection;
        private Gw2Client? gw2Client;
        private object? dump;

        [GlobalSetup]
        public async Task GlobalSetupAsync()
        {
            this.connection = new Connection();
            this.gw2Client = new Gw2Client(this.connection);
            await this.gw2Client.WebApi.V2.Items.PageAsync(1).ConfigureAwait(false);
        }

        [GlobalCleanup]
        public void GlobalCleanup() => this.gw2Client!.Dispose();

        [Benchmark(OperationsPerInvoke=OPERATIONS_PER_INVOKE)]
        public async Task<object?> DeserializeItemsBulkFastestAsync()
        {
            for (int i = 0; i < OPERATIONS_PER_INVOKE; ++i)
            {
                this.dump = await this.gw2Client!.WebApi.V2.Items.PageAsync(1).ConfigureAwait(false);
            }

            return this.dump;
        }
    }
}

