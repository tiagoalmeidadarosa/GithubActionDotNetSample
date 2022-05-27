using IHost host = Host.CreateDefaultBuilder(args).Build();

var parser = Default.ParseArguments<ActionInputs>(() => new(), args);
parser.WithNotParsed(
    errors =>
    {
        //A logger could be used here
        Console.WriteLine(
            string.Join(Environment.NewLine, errors.Select(error => error.ToString())));

        Environment.Exit(2);
    });

await parser.WithParsedAsync(options => StartAnalysisAsync(options));
await host.RunAsync();

static async Task StartAnalysisAsync(ActionInputs inputs)
{
    var operation = inputs.Operation;
    var value = inputs.Value;

    switch (operation)
    {
        case "CelsiusToFahrenheit":
            var fahrenheitResult = value * 1.8 + 32;
            Console.WriteLine($"{value}ºC is {fahrenheitResult}ºF");
            break;

        case "FahrenheitToCelsius":
            var celsiusResult = (value - 32) / 1.8;
            Console.WriteLine($"{value}ºF is {celsiusResult}ºC");
            break;

        default:
            break;
    }

    await Task.CompletedTask;

    Environment.Exit(0);
}