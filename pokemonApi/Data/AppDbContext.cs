using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using pokemonApi.Models;

namespace pokemonApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Database.sqlite");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

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
