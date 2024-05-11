namespace RatingService.Bll.Services.Abstracts
{
    public interface IUserServices
    {
        /// <summary>
        /// Checks if the user exist
        /// </summary>
        /// <param name="userId">id number of the user</param>
        /// <returns></returns>
        Task<bool> CheckUser(int userId);
    }
}
