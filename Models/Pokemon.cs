using System.Text.Json.Serialization;

namespace Pokedex.Models;

public record Pokemon : NamedModel
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("sprites")]
    public Sprites Sprites { get; init; }

    [JsonPropertyName("types")]
    public PokemonType[] Types { get; init; }

    [JsonPropertyName("base_experience")]
    public int BaseExperience { get; init; }

    [JsonPropertyName("height")]
    public int Height { get; init; }

    [JsonPropertyName("weight")]
    public int Weight { get; init; }
}