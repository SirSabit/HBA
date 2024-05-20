using Microsoft.Extensions.DependencyInjection;
using RatingService.Dal.DbContexts;
using RatingService.Dal.MessageBrokers.Abstract;
using RatingService.Dal.MessageBrokers.Implementations;

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
            services.AddScoped<INotificationBroker, NotificationBroker>();
        }
    }
}
