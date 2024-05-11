using RatingService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingService.Bll.Services.Abstracts
{
    public interface INotificationServices
    {
        Task<List<RatingDto>> GetProviderNotificationsAsync(int providerId);
    }
}
