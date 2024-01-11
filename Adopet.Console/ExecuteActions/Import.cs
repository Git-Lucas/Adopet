using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.ExecuteActions;
internal class Import
{
    private readonly HttpClient _client;

    public Import()
    {
        _client = ConfiguraHttpClient("http://localhost:5057");
    }

    internal async Task ExecuteAsync(string pathFileToImport)
    {
        List<Pet> listaDePet = [];

        using (StreamReader sr = new(pathFileToImport))
        {
            System.Console.WriteLine("----- Dados importados -----");
            while (!sr.EndOfStream)
            {
                // separa linha usando ponto e vírgula
                string[]? propriedades = sr.ReadLine()!.Split(';');
                // cria objeto Pet a partir da separação
                Pet pet = new(Guid.Parse(propriedades[0]),
                  propriedades[1],
                  int.Parse(propriedades[2]) == 1 ? TipoPet.Gato : TipoPet.Cachorro
                 );

                System.Console.WriteLine(pet);
                listaDePet.Add(pet);
            }
        }
        foreach (var pet in listaDePet)
        {
            try
            {
                var resposta = await CreatePetAsync(pet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        System.Console.WriteLine("Importação concluída!");
    }

    Task<HttpResponseMessage> CreatePetAsync(Pet pet)
    {
        using HttpResponseMessage response = new();
        return _client.PostAsJsonAsync("pet/add", pet);
    }

    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }
}
