namespace Adopet.Console.Services;
public class FileReader
{
    public List<Pet> Execute(string pathFileToDisplay)
    {
        List<Pet> pets = [];

        using StreamReader sr = new(pathFileToDisplay);

        System.Console.WriteLine("----- Dados a serem importados -----");

        while (!sr.EndOfStream)
        {
            string[] propriedades = sr.ReadLine()!.Split(';');

            Pet pet = new(
                id: Guid.Parse(propriedades[0]),
                nome: propriedades[1],
                tipo: int.Parse(propriedades[2]) == 1 ? PetType.Gato : PetType.Cachorro);

            pets.Add(pet);
        }

        return pets;
    }
}
