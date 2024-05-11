using Microsoft.Extensions.DependencyInjection;
using RatingService.Dal.DbContexts;

namespace RatingService.Dal.Extensions
{
    public static class DalServiceCollectionExtensions
    {
        /// <summary>
        /// Data access layer service registrator
        /// </summary>
        public static void AddDalServices(this IServiceCollection services)
        {
            services.AddDbContext<PostgreDbContext>();
        }
    }
}
