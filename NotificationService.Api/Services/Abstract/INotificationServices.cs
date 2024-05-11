using NotificationService.Api.Models;

namespace NotificationService.Api.Services.Abstract
{
    public interface INotificationServices
    {
        Task<List<RatingModel>> GetNotifications(int providerId);
    }
}
