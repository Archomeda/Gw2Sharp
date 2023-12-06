using System;
using System.IO;
using System.Text.Json;
using BenchmarkDotNet.Attributes;
using Gw2Sharp.WebApi.V2;
using Gw2Sharp.WebApi.V2.Models;

namespace Gw2Sharp.Benchmarks
{
    [MedianColumn]
    [MemoryDiagnoser]
    public class ItemsPageDeserializeBenchmark
    {
        private const int OPERATIONS_PER_INVOKE = 50;
        private byte[] jsonBytes = Array.Empty<byte>();
        private JsonSerializerOptions? jsonSerializerOptions = null;
        private object? dump;

        [GlobalSetup]
        public void GlobalSetup()
        {
            string path = Path.Combine("TestFiles", "Items", "Items.max_page_size.json");
            this.jsonBytes = System.IO.File.ReadAllBytes(path);
            this.jsonSerializerOptions = SerializationHelpers.GetJsonSerializerOptions();
        }

        [Benchmark(OperationsPerInvoke=OPERATIONS_PER_INVOKE)]
        public object DeserializeItemsPage()
        {
            for (int i = 0; i < OPERATIONS_PER_INVOKE; ++i)
            {
                this.dump = JsonSerializer.Deserialize<IApiV2ObjectList<Item>>(this.jsonBytes, this.jsonSerializerOptions);
            }

            return this.dump!;
        }
    }
}

