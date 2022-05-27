namespace GithubActionDotNetSample;

public class ActionInputs
{
    [Option('v', "value",
    Required = true,
    HelpText = "The value to be converted.")]
    public double Value { get; set; }

    [Option('o', "operation",
    Required = true,
    HelpText = "The operation to which the value will be converted.")]
    public string Operation { get; set; } = null!;
}
