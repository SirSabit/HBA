namespace NotificationService.Api.Services.Abstract
{
    public interface INotificationServices
    {
        List<string> GetNotifications(int providerId);
    }
}
