using Adopet.Console.Attributes;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Adopet.Console.ExecuteActions;

[Command(command: "list", documentation: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
public class ListAction : IAction
{
    private readonly HttpClient _client;

    public ListAction()
    {
        _client = ConfiguraHttpClient("http://localhost:5057");
    }

    public async Task ExecuteAsync(string[] args)
    {
        Task<IEnumerable<Pet>?> getPetsTask = ListPetsAsync();
        
        System.Console.WriteLine("----- Lista de Pets importados no sistema -----");
        
        IEnumerable<Pet>? pets = await getPetsTask;
        foreach (var pet in pets!)
        {
            System.Console.WriteLine(pet);
        }
    }

    private HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

    private async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await _client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }
}
