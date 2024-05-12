using NotificationService.Api.Models;
using NotificationService.Api.Services.Abstract;
using System.Text.Json;
using System;
using Microsoft.EntityFrameworkCore;
using NotificationService.Api.ExceptionManagement.Exceptions;

namespace NotificationService.Api.Services.Implementation
{
    public class NotificationServices : INotificationServices
    {
        public async Task<List<RatingModel>> GetNotifications(int providerId)
        {
            using (HttpClient client = new HttpClient())
            {
                //TODO : relocate url
                string url = $"http://host.docker.internal:5050/api/rating/{providerId}/notify";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    List<RatingModel>? data = JsonSerializer.Deserialize<List<RatingModel>>(result, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                    return data ?? new List<RatingModel>();
                }
                else
                {
                    ErrorModel? data = JsonSerializer.Deserialize<ErrorModel>(result, new JsonSerializerOptions(JsonSerializerDefaults.Web));
                    throw new GlobalException(data?.Detail);
                }
            }
        }
    }
}
