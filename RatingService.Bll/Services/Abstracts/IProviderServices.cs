namespace RatingService.Bll.Services.Abstracts
{
    public interface IProviderServices
    {
        /// <summary>
        ///  Checks if the provider exist
        /// </summary>
        /// <param name="providerId">id number of the provider</param>
        /// <returns></returns>
        Task<bool> CheckProvider(int providerId);
    }
}