using System.Text.Json.Serialization;

namespace pokemonApi.Models
{
    public class PokemonElement
    {
        public Guid Id { get; set; }
        public string Element { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }
        [JsonIgnore]
        public Pokemon Pokemon { get; set; }
    }
}
