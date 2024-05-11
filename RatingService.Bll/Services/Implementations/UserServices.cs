using Microsoft.EntityFrameworkCore;
using RatingService.Bll.Services.Abstracts;
using RatingService.Dal.DbContexts;

namespace RatingService.Bll.Services.Implementations
{
    public class UserServices(PostgreDbContext dbContext) : IUserServices
    {
        private readonly PostgreDbContext dbContext = dbContext;

        public async Task<bool> CheckUser(int userId)
            => await dbContext.Users.AnyAsync(user => user.Id == userId);
    }
}
