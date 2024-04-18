using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace pokemonApi.Models
{
    public class PokemonElement
    {
        public int Id { get; set; }
        public string ElementType { get; set; }
        public string Strength { get; set; }
        public string Weakness { get; set; }

        [ForeignKey("PokemonId")]
        [JsonIgnore]
        public Guid PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        [NotMapped]
        public string PokemonName => Pokemon?.Name;
    }
}
