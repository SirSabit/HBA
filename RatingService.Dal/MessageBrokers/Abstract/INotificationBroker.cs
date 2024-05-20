namespace RatingService.Dal.MessageBrokers.Abstract
{
    public interface INotificationBroker
    {
        Task SendToQueue(string notificationMessage, int providerId);
    }
}
