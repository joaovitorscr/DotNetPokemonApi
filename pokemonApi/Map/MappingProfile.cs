using AutoMapper;
using pokemonApi.Dto;
using pokemonApi.Models;

namespace pokemonApi.Map
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {

            CreateMap<Pokemon, PokemonDto>();
            CreateMap<PokemonDto, Pokemon>();

            CreateMap<PokemonElement, PokemonElementDto>();
            CreateMap<PokemonElementDto, PokemonElement>();
        }
    }
}
