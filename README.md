# Messing around with micro benchmarks

Repository with some micro benchmarks, using BenchmarkDotNet, to play around trying to optimize things

## Repository structure

- Benchmarks - contains the benchmark application
- Starting - contains the starting solutions needing optimization
- Session - initially contains the solutions needing optimization, later the solutions developed during a learning mob programming session
- Reference - contains ideas of possible solutions

## Running benchmarks

Benchmarks can be run in two ways:

- If you don't know which benchmark you want to run, in the CLI do `dotnet run -c Release -- benchmark`, which will prompt you to select the benchmark
- If you know which benchmark you want to run, in the CLI do `dotnet run -c Release -- benchmark -b NameOfTheBenchmarkClass`, which will execute the benchmark immediately, without any prompt