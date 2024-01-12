using Adopet.Console.Services;

namespace Adopet.Console.ExecuteActions;

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
