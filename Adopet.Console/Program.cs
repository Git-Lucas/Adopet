using Adopet.Console.ExecuteActions;

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string initialCommand = args[0].Trim();
    switch (initialCommand)
    {
        case "import":
            Import import = new();
            await import.ExecuteAsync(pathFileToImport: args[1]);

            break;

        case "help":
            Help help = new();
            help.Execute(args);

            break;

        case "show":
            Show show = new();
            show.Execute(pathFileToDisplay: args[1]);
            
            break;

        case "list":
            ListAction list = new();
            await list.ExecuteAsync();
            
            break;

        default:
            Console.WriteLine("Comando inválido!");

            break;
    }
}
catch (Exception ex)
{
    // mostra a exceção em vermelho
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
