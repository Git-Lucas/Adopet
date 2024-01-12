using Adopet.Console.Attributes;
using Adopet.Console.Services;

namespace Adopet.Console.ExecuteActions;

[Command(command: "show", documentation: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
public class Show
{
    private readonly FileReader _fileReader;

    public Show()
    {
        _fileReader = new FileReader();
    }

    public void Execute(string pathFileToDisplay)
    {
        List<Pet> pets = _fileReader.Execute(pathFileToDisplay);

        pets.ForEach(System.Console.WriteLine);
    }
}
