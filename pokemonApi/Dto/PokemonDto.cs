namespace pokemonApi.Dto
{
    public class PokemonDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int PokedexId { get; set; }
        public ICollection<PokemonElementDto> PokemonElements { get; set; }
    }
}
