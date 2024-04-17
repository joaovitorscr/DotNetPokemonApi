using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pokemonApi.Models;

namespace pokemonApi.Config
{
    public class PokemonConfig : IEntityTypeConfiguration<Pokemon>
    {
        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemons");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Property(p => p.PokedexId).IsRequired().HasMaxLength(4);
        }
    }
}
