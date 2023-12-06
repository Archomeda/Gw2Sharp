
## BenchmarkDotNet good practices

BenchmarkDotNet good practices for running and writing benchmarks:
https://benchmarkdotnet.org/articles/guides/good-practices.html

## Running benchmarks

Run benchmarks via dotnet cli:
```
dotnet run -f net5.0 -c Release --project .\Gw2Sharp.Benchmarks.csproj
```

* Target framework (e.g. `net5.0`) must be present in `Gw2Sharp.Benchmarks.csproj`
* After running follow instructions on the terminal to run a specific benchmark.
* Benchmark results will appear in a directory `BenchmarkDotNet.Artifacts` under
the current working directory.

## Writing new benchmarks

* When writing a microbenchmark have in mind that single benchmark
should run for `200ms` or more
  * To achieve this threshold use [OperationsPerInvoke](https://benchmarkdotnet.org/api/BenchmarkDotNet.Attributes.BenchmarkAttribute.html#BenchmarkDotNet_Attributes_BenchmarkAttribute_OperationsPerInvoke)
property of the `BenchmarkDotNet.Attributes.BenchmarkAttribute`
