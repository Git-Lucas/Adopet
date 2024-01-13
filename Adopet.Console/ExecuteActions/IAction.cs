namespace Adopet.Console.ExecuteActions;

public interface IAction
{
    Task ExecuteAsync(string[] args);
}
