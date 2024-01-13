using Adopet.Console.ExecuteActions;

Dictionary<string, IAction> actionsSystem = new()
{
    { "help", new Help() },
    { "import", new Import() },
    { "list", new ListAction() },
    { "show", new Show() },
};

Console.ForegroundColor = ConsoleColor.Green;
try
{
    string initialCommandByUser = args[0].Trim();

    if (actionsSystem.TryGetValue(initialCommandByUser, out IAction? action))
    {
        await action.ExecuteAsync(args);
    }
    else
    {
        Console.WriteLine("Comando inválido.");
    }
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"Aconteceu um exceção: {ex.Message}");
}
finally
{
    Console.ForegroundColor = ConsoleColor.White;
}
