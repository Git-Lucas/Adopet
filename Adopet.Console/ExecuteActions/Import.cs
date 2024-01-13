using Adopet.Console.Attributes;
using Adopet.Console.Services;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.ExecuteActions;

[Command(command: "import", documentation: "adopet import <ARQUIVO> comando que realiza a importação do arquivo de pets.")]
public class Import : IAction
{
    private readonly HttpClient _client;
    private readonly FileReader _fileReader;

    public Import()
    {
        _client = ConfiguraHttpClient("http://localhost:5057");
        _fileReader = new FileReader();
    }

    public async Task ExecuteAsync(string[] args)
    {
        string pathFileToImport = args[1];
        List<Pet> pets = _fileReader.Execute(pathFileToImport);

        foreach (Pet pet in pets)
        {
            System.Console.WriteLine(pet);

            try
            {
                HttpResponseMessage resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }

    private async Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        using HttpResponseMessage response = new();
        return await _client.PostAsJsonAsync("pet/add", pet);
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new();

        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        
        return _client;
    }
}
