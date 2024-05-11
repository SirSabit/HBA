namespace NotificationService.Api.ExceptionManagement.Exceptions
{
    public class GlobalException: Exception
    {
        public GlobalException() : base("Unhandled Error!")
        {
        }

        public GlobalException(string? message) : base(message)
        {
        }
    }
}
