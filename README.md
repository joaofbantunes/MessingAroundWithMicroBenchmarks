# Messing around with micro benchmarks

Repository with some micro benchmarks, using BenchmarkDotNet, to play around trying to optimize things

## Repository structure

- Benchmarks - contains the benchmark application (it's over-engineered, just to try to make things simpler for the presentation)
- Starting - contains the starting solutions needing optimization
- Session - contains ideas of possible solutions we looked into during the presentation

## Running benchmarks

Benchmarks can be run in two ways:

- If you don't know which benchmark you want to run, in the CLI do `dotnet run -c Release -- benchmark`, which will prompt you to select the benchmark
- If you know which benchmark you want to run, in the CLI do `dotnet run -c Release -- benchmark -b NameOfTheBenchmarkClass`, which will execute the benchmark immediately, without any prompt

## Results

### FirstBenchmark (case insensitive string comparison)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |     Mean |    Error |   StdDev |      Min |      Max | Ratio | Rank |   Gen0 | Allocated | Alloc Ratio |
|--------- |---------:|---------:|---------:|---------:|---------:|------:|-----:|-------:|----------:|------------:|
| Original | 41.90 ns | 0.401 ns | 0.375 ns | 41.16 ns | 42.73 ns |  1.00 |    2 | 0.0153 |      96 B |        1.00 |
|      New | 19.14 ns | 0.074 ns | 0.066 ns | 19.07 ns | 19.25 ns |  0.46 |    1 |      - |         - |        0.00 |

### SecondBenchmark (List vs HashSet to keep a unique collection)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |      Mean |    Error |   StdDev |       Min |       Max | Ratio | Rank |   Gen0 |   Gen1 | Allocated | Alloc Ratio |
|--------- |----------:|---------:|---------:|----------:|----------:|------:|-----:|-------:|-------:|----------:|------------:|
| Original | 125.98 μs | 2.267 μs | 2.120 μs | 123.49 μs | 130.10 μs |  1.00 |    2 | 1.2207 |      - |   8.23 KB |        1.00 |
|      New |  18.59 μs | 0.180 μs | 0.168 μs |  18.31 μs |  18.83 μs |  0.15 |    1 | 9.3384 | 2.3193 |  57.29 KB |        6.96 |

### ThirdBenchmark (local collection reference when iterating)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |     Mean |   Error |   StdDev |   Median |      Min |      Max | Ratio | RatioSD | Rank | Allocated | Alloc Ratio |
|--------- |---------:|--------:|---------:|---------:|---------:|---------:|------:|--------:|-----:|----------:|------------:|
| Original | 378.8 μs | 7.58 μs | 11.11 μs | 376.4 μs | 364.7 μs | 403.0 μs |  1.00 |    0.00 |    2 |         - |          NA |
|      New | 295.6 μs | 5.57 μs | 12.80 μs | 290.8 μs | 280.0 μs | 330.3 μs |  0.78 |    0.06 |    1 |         - |          NA |

### FourthBenchmark (iterating an interface reference vs concrete type reference)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |       Mean |   Error |  StdDev |        Min |        Max | Ratio | Rank | Allocated | Alloc Ratio |
|--------- |-----------:|--------:|--------:|-----------:|-----------:|------:|-----:|----------:|------------:|
| Original | 3,330.2 μs | 7.69 μs | 6.42 μs | 3,321.6 μs | 3,341.0 μs |  1.00 |    2 |      34 B |        1.00 |
|      New |   297.1 μs | 5.80 μs | 5.70 μs |   291.0 μs |   308.5 μs |  0.09 |    1 |         - |        0.00 |

### FifthBenchmark (closure allocations)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |     Mean |     Error |    StdDev |      Min |      Max | Ratio | Rank |       Gen0 |  Allocated | Alloc Ratio |
|--------- |---------:|----------:|----------:|---------:|---------:|------:|-----:|-----------:|-----------:|------------:|
| Original | 7.600 ms | 0.1181 ms | 0.1047 ms | 7.491 ms | 7.821 ms |  1.00 |    2 | 10195.3125 | 64000028 B |       1.000 |
|      New | 2.847 ms | 0.0239 ms | 0.0224 ms | 2.822 ms | 2.893 ms |  0.37 |    1 |          - |        2 B |       0.000 |

### SixthBenchmark (structs, boxing and generics)

``` ini

BenchmarkDotNet=v0.13.2, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-9700K CPU 3.60GHz (Coffee Lake), 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```
|   Method |     Mean |     Error |    StdDev |      Min |      Max | Ratio | Rank |   Gen0 | Allocated | Alloc Ratio |
|--------- |---------:|----------:|----------:|---------:|---------:|------:|-----:|-------:|----------:|------------:|
| Original | 7.505 ns | 0.0684 ns | 0.0640 ns | 7.412 ns | 7.600 ns |  1.00 |    2 | 0.0038 |      24 B |        1.00 |
|      New | 2.624 ns | 0.0028 ns | 0.0024 ns | 2.618 ns | 2.627 ns |  0.35 |    1 |      - |         - |        0.00 |