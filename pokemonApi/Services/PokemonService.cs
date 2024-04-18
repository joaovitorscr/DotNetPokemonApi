using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pokemonApi.Data;
using pokemonApi.Dto;
using pokemonApi.Models;

namespace pokemonApi.Services
{
    public class PokemonService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public PokemonService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<PokemonDto> GetAll()
        {
            var pokemons = _context.Pokemons.Include(p => p.PokemonElements).ToList();

            return _mapper.Map<List<PokemonDto>>(pokemons);
        }
        public PokemonDto? Get(Guid id)
        {
            var pokemon = _context.Pokemons.Include(p => p.PokemonElements).FirstOrDefault(p => p.Id == id);

            if (pokemon == null)
            {
                return null;
            }

            return _mapper.Map<PokemonDto>(pokemon);
        }
        public void Add(PokemonDto pokemon)
        {
            var newPokemon = _mapper.Map<Pokemon>(pokemon);

            _context.Pokemons.Add(newPokemon);
            _context.SaveChangesAsync();
        }

        public void Update(Guid id, PokemonDto pokemon)
        {
            var existingPokemon = _context.Pokemons.Include(p => p.PokemonElements).FirstOrDefault(p => p.Id == id);
            if (existingPokemon == null)
            {
                return;
            }

            _mapper.Map(pokemon, existingPokemon);

            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var pokemon = _context.Pokemons.FirstOrDefault(p => p.Id == id);
            if (pokemon == null)
            {
                return;
            }

            _context.Pokemons.Remove(pokemon);
            _context.SaveChanges();
        }
    }
}
