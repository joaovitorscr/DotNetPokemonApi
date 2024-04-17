using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pokemonApi.Models;

namespace pokemonApi.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonElement> PokemonElements { get; set; }

        public void SeedData()
        {
            if (!Pokemons.Any())
            {
                var pokemonData = File.ReadAllText("data/pokemonSeedData.json");
                var pokemons = JsonConvert.DeserializeObject<List<Pokemon>>(pokemonData);
                Pokemons.AddRange(pokemons);
                SaveChanges();
            }
        }
    }
}
