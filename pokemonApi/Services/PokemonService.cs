using pokemonApi.Data;
using pokemonApi.Models;

namespace pokemonApi.Services
{
    public class PokemonService
    {
        private readonly AppDbContext _context;
        public PokemonService(AppDbContext context)
        {
            _context = context;
        }

        public List<Pokemon> GetAll() => _context.Pokemons.ToList();
        public Pokemon? Get(Guid id) => _context.Pokemons.FirstOrDefault(p => p.Id == id);
        public void Add(Pokemon pokemon)
        {
            _context.Pokemons.Add(pokemon);
            _context.SaveChangesAsync();
        }

        public void Delete(Guid id)
        {
            var pokemon = Get(id);
            if (pokemon != null)
            {
                _context.Pokemons.Remove(pokemon);
                _context.SaveChangesAsync();
            }
        }

        public void Update(Pokemon pokemon)
        {
            if (pokemon != null)
            {
                _context.Pokemons.Update(pokemon);
                _context.SaveChangesAsync();
            }
        }
    }
}
