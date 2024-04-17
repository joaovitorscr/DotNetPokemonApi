namespace pokemonApi.Models
{
    public class Pokemon
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public int PokedexId { get; set; }


        private readonly List<PokemonElement> _pokemonElement = new List<PokemonElement>();
        public IReadOnlyCollection<PokemonElement> PokemonElements => _pokemonElement;
    }
}