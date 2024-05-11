using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RatingService.Bll.Exceptions;

namespace RatingService.Api.ExceptionHandlers
{
    internal sealed class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
    {
        private readonly ILogger<NotFoundExceptionHandler> logger = logger;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            if (exception is not NotFoundException notFoundException)
            {
                return false;
            }

            logger.LogError(
                notFoundException,
                "Exception occurred: {Message}",
                notFoundException.Message);

            var problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Not Found",
                Detail = notFoundException.Message
            };

            httpContext.Response.StatusCode = problemDetails.Status.Value;

            await httpContext.Response
                .WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }

}
