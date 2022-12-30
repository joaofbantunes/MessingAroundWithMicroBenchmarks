using System.ComponentModel;
using System.Reflection;
using BenchmarkDotNet.Running;
using Benchmarks;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp();
app.Configure(config => { config.AddCommand<BenchmarkCommand>("benchmark"); });
return await app.RunAsync(args);

public class BenchmarkCommand : Command<BenchmarkCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandOption("-b|--benchmark")]
        [Description("The benchmark to run")]
        public string? Benchmark { get; init; }
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var benchmarks =
            Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false } &&
                            t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBenchmark<>)));

        var benchmark = ParseProvidedBenchmarkIfAny(settings.Benchmark, benchmarks)
                        ?? AnsiConsole.Prompt(new SelectionPrompt<Type> { Converter = t => t.Name }
                            .Title("What benchmark to run?")
                            .AddChoices(benchmarks));

        var returnType = benchmark.GetInterfaces()
            .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBenchmark<>)).GenericTypeArguments
            .Single();

        _ = BenchmarkRunner.Run(typeof(BenchmarkContainer<,>).MakeGenericType(benchmark, returnType));

        return 0;

        static Type? ParseProvidedBenchmarkIfAny(string? benchmarkName, IEnumerable<Type> benchmarks)
            => string.IsNullOrWhiteSpace(benchmarkName)
                ? null
                : benchmarks.FirstOrDefault(t => t.Name == benchmarkName);
    }
}