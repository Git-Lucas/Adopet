using Adopet.Console.Attributes;
using System.Reflection;

namespace Adopet.Console.ExecuteActions;

[Command(
    command: "help", 
    documentation: "adopet help comando que exibe informações da ajuda.\n" +
                   "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
public class Help : IAction
{
    private readonly Dictionary<string, CommandAttribute> _commands;

    public Help()
    {
        _commands = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.GetCustomAttributes<CommandAttribute>().Any())
            .Select(x => x.GetCustomAttribute<CommandAttribute>()!)
            .ToDictionary(x => x.Command);
    }

    public Task ExecuteAsync(string[] args)
    {
        if (args.Length == 1)
        {
            System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine($"Comando possíveis: ");

            foreach (CommandAttribute command in _commands.Values)
            {
                System.Console.WriteLine(command.Documentation);
            }
        }
        else if (args.Length == 2)
        {
            string command = args[1];

            if (_commands.TryGetValue(command, out CommandAttribute? value))
            {
                System.Console.WriteLine(value.Documentation);
            }
        }

        return Task.CompletedTask;
    }
}
