using Microsoft.Extensions.DependencyInjection;
using RatingService.Bll.Services.Abstracts;
using RatingService.Bll.Services.Implementations;
using RatingService.Dal.Extensions;

namespace RatingService.Bll.Extensions
{
    public static class BllServiceCollectionExtensions
    {
        /// <summary>
        /// Bussiness logic layer service registrator
        /// </summary>       
        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddDalServices();
            services.AddMemoryCache();
            services.AddScoped<IRatingServices, RatingServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProviderServices, ProviderServices>();
            services.AddScoped<INotificationServices, NotificationServices>();
        }
    }
}
