
namespace Adopet.Console.ExecuteActions;
public class Help
{
    public void Execute(string[] args)
    {
        if (args.Length == 1)
        {
            System.Console.WriteLine($"Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            System.Console.WriteLine($"Realiza a importação em lote de um arquivos de pets.");
            System.Console.WriteLine($"Comando possíveis: ");
            System.Console.WriteLine($" adopet help comando que exibe informações da ajuda.");
            System.Console.WriteLine($" adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.");
            System.Console.WriteLine($" adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.");
            System.Console.WriteLine($" adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.");
            System.Console.WriteLine($" adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet." + "\n");
        }
        // exibe o help daquele comando específico
        else if (args.Length == 2)
        {
            string command = args[1];
            if (command.Equals("import"))
            {
                System.Console.WriteLine($"adopet import <arquivo> " +
                    "comando que realiza a importação do arquivo de pets.");
            }
            if (command.Equals("show"))
            {
                System.Console.WriteLine($"adopet show <arquivo>  comando que " +
                    "exibe no terminal o conteúdo do arquivo importado.");
            }
            if (command.Equals("list"))
            {
                System.Console.WriteLine($"adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.");
            }
        }
    }
}
