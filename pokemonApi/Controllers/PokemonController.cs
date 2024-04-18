using Microsoft.AspNetCore.Mvc;
using pokemonApi.Dto;
using pokemonApi.Models;
using pokemonApi.Services;

namespace pokemonApi.Controllers
{
    [Route("api/pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET All /api/pokemon
        [HttpGet]
        public ActionResult<List<PokemonDto>> GetAll() => _pokemonService.GetAll();

        // Get by Id /api/pokemon/{id}
        [HttpGet("{id}")]
        public ActionResult<PokemonDto> Get(Guid id)
        {
            var pokemon = _pokemonService.Get(id);

            if (pokemon == null)
            {
                return NotFound();
            }

            return pokemon;
        }

        [HttpPost]
        public IActionResult Create(PokemonDto pokemon)
        {
            _pokemonService.Add(pokemon);
            return CreatedAtAction(nameof(Get), new { id = pokemon.Id }, pokemon);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, PokemonDto pokemon)
        {
            if (id != pokemon.Id)
            {
                return BadRequest();
            }

            try
            {
                _pokemonService.Update(id, pokemon);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _pokemonService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
