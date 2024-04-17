namespace pokemonApi.Models
{
    public class Pokemon
    {
        public Guid Id { get; init; }
        public string? Name { get; set; }
        public int PokedexId { get; set; }
        public string? ElementalType { get; set; }
    }
}