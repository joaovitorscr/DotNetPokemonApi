using System.Text.Json.Serialization;

namespace pokemonApi.Models
{
    public class Pokemon
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int PokedexId { get; set; }
        [JsonIgnore]
        public ICollection<PokemonElement> PokemonElements { get; set; }
    }
}