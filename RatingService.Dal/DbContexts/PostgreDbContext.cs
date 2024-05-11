using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RatingService.Entities;

namespace RatingService.Dal.DbContexts
{
    public class PostgreDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options)
    {
        private readonly IConfiguration configuration = configuration;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //Configure Db Connection
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreCs"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Seed Data
            #region Ratings Seed Data
            modelBuilder.Entity<RatingEntity>().HasData(
                new RatingEntity { Id = 1, UserId = 1, ProviderId = 1, Point = 4.5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 2, UserId = 2, ProviderId = 1, Point = 5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 3, UserId = 3, ProviderId = 1, Point = 3, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 4, UserId = 4, ProviderId = 1, Point = 3.5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 5, UserId = 5, ProviderId = 1, Point = 2.5, CreatedAt = DateTime.UtcNow },

                new RatingEntity { Id = 6, UserId = 1, ProviderId = 2, Point = 4.5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 7, UserId = 2, ProviderId = 2, Point = 5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 8, UserId = 3, ProviderId = 2, Point = 3, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 9, UserId = 4, ProviderId = 2, Point = 3.5, CreatedAt = DateTime.UtcNow },
                new RatingEntity { Id = 10, UserId = 5, ProviderId = 2, Point = 2.5, CreatedAt = DateTime.UtcNow }
                );
            #endregion

            #region User Seed Data
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity { Id = 1, Name = "Abuzer", Surname = "Kadayif", CreatedAt = DateTime.UtcNow },
                new UserEntity { Id = 2, Name = "Temel", Surname = "Reis", CreatedAt = DateTime.UtcNow }
                );
            #endregion

            #region Provider Seed Data
            modelBuilder.Entity<ProviderEntity>().HasData(
                new ProviderEntity { Id = 1, Name = "Ilyas", Surname = "Salman", CreatedAt = DateTime.UtcNow },
                new ProviderEntity { Id = 2, Name = "Adile", Surname = "Nasit", CreatedAt = DateTime.UtcNow }
                );
            #endregion
        }

        //Set Tables
        public DbSet<RatingEntity> Ratings { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProviderEntity> Providers { get; set; }
    }
}
