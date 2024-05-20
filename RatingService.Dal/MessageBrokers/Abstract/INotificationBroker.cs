using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingService.Dal.MessageBrokers.Abstract
{
    public interface INotificationBroker
    {
        Task SendToQueue(string notificationMessage, int providerId);
    }
}
