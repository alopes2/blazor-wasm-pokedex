using System.Net.Http.Json;
using Pokedex.Models;

namespace Pokedex.Clients;

public class PokeClient
{
    private readonly HttpClient _client;

    public PokeClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<GetPokemonListResponse> GetPokemons(int offset)
    {
        return await _client.GetFromJsonAsync<GetPokemonListResponse>($"pokemon?offset={offset}");
    }

    public async Task<Pokemon> GetPokemon(string url)
    {
        return await _client.GetFromJsonAsync<Pokemon>(url);
    }

    public async Task<Pokemon> GetPokemonByNameOrId(string identificator)
    {
        try
        {
            return await _client.GetFromJsonAsync<Pokemon>($"pokemon/{identificator.ToLower()}");
        }
        catch
        {
            return null;
        }
    }
}