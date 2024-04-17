using Microsoft.EntityFrameworkCore;
using pokemonApi.Data;

namespace pokemonApi.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            using AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            dbContext.SeedData();
        }
    }
}
