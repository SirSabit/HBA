using Microsoft.Extensions.Caching.Memory;
using RatingService.Bll.Exceptions;
using RatingService.Bll.Globals;
using RatingService.Bll.Services.Abstracts;
using RatingService.Dtos;

namespace RatingService.Bll.Services.Implementations
{
    public class NotificationServices(IMemoryCache memoryCache, IProviderServices providerServices) : INotificationServices
    {
        private readonly IMemoryCache memoryCache = memoryCache;
        private readonly IProviderServices providerServices = providerServices;

        public async Task<List<RatingDto>> GetProviderNotificationsAsync(int providerId)
        {
            var checkProvider = await providerServices.CheckProvider(providerId);

            if (!checkProvider)
                throw new NotFoundException(ExceptionMessages.ProviderNotFound);


            string key = $"{Constants.RatingCacheKey}{providerId}";

            var notifications = new List<RatingDto>();
            memoryCache.TryGetValue(key, out notifications);

            if (notifications is null)
                throw new NotFoundException(ExceptionMessages.NoNewNotification);

            memoryCache.Remove(key);

            return notifications;
        }
    }
}
