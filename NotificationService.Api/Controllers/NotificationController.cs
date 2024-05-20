using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Api.ExceptionManagement.Exceptions;
using NotificationService.Api.Services.Abstract;

namespace NotificationService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController(INotificationServices notificationServices) : ControllerBase
    {
        private readonly INotificationServices notificationServices = notificationServices;

        [HttpGet("{providerId}")]
        public IActionResult GetNotifications(int providerId)
        {
            try
            {
                var notifications = notificationServices.GetNotifications(providerId);
                return Ok(notifications);
            }
            catch
            {
                throw;
            }
        }
    }
}
