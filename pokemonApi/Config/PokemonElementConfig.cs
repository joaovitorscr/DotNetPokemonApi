using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pokemonApi.Models;

namespace pokemonApi.Config
{
    public class PokemonElementConfig : IEntityTypeConfiguration<PokemonElement>
    {
        public void Configure(EntityTypeBuilder<PokemonElement> builder)
        {
            builder.ToTable("PokemonElements");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Element).IsRequired().HasMaxLength(40);
            builder.Property(p => p.Strength).IsRequired();
            builder.Property(p => p.Weakness).IsRequired();


            builder.HasOne(p => p.Pokemon)
                .WithMany(p => p.PokemonElements)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
