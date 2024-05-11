using RatingService.Dtos;

namespace RatingService.Bll.Services.Abstracts
{
    public interface IRatingServices
    {
        /// <summary>
        /// Saves the users rate point
        /// </summary>
        /// <param name="rate">
        /// int userId, int providerId, double rate
        /// </param>
        Task<int> RateAsync(RatingDto rate);

        /// <summary>
        /// Returns avarage point for the specified provider
        /// </summary>
        /// <param name="providerId"></param>
        /// <returns>double</returns>
        Task<double> AvarageAsync(int providerId);
    }
}
