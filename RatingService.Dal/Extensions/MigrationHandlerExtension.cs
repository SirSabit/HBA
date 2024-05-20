using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RatingService.Dal.DbContexts;

namespace RatingService.Dal.Extensions
{
    public static class MigrationHandlerExtension
    {
        /// <summary>
        /// This extension ensures that the database is created
        /// </summary>
        public static void HandleMigration(this WebApplication app)
        {
            using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var db = serviceScope.ServiceProvider.GetRequiredService<PostgreDbContext>().Database;

            //Create db for the first time
            if (!db.CanConnect())
                db.Migrate();

            //Checks new migrations. If new migration exist then executes it
            var appliedMigrations = db.GetAppliedMigrations();
            if (db.GetMigrations().Except(appliedMigrations).Any())
                db.Migrate();
        }
    }
}
