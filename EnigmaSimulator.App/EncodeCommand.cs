using EnigmaSimulator.Domain;
using Spectre.Console;
using Spectre.Console.Cli;

namespace EnigmaSimulator.App;

public class EncodeCommand(EnigmaMachine enigma) : Command<EncodeCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[input]")]
        public required string Input { get; init; }
    }

    protected override int Execute(CommandContext context, Settings settings, CancellationToken cancellationToken)
    {
        string output = enigma.Encode(settings.Input);
        AnsiConsole.MarkupLine($"Output [yellow]{output}[/]");
        return 0;
    }

    protected override ValidationResult Validate(CommandContext context, Settings settings)
    {
        if(string.IsNullOrWhiteSpace(settings.Input))
        {
            return ValidationResult.Error("Input is required.");
        }
        return base.Validate(context, settings);
    }
}