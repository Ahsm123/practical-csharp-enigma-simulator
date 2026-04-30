using EnigmaSimulator.Domain;
using Spectre.Console.Cli;
using Spectre.Console;

namespace EnigmaSimulator.App;

public class InteractiveEnigmaCommand(EnigmaMachine enigma) : Command
{
    protected override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        AnsiConsole.MarkupLine("Enigma will encode until you press [cyan]Enter[/]");
        AnsiConsole.WriteLine();

        char output;
        do
        {
            ConsoleKeyInfo? keyInfo = AnsiConsole.Console.Input.ReadKey(intercept: true);

            char input = keyInfo.GetValueOrDefault().KeyChar;
            output = enigma.Encode(input);

            AnsiConsole.Write(output);

        } while (!Environment.NewLine.Contains(output));

        return 0;
    }
}