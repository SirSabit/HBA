using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RatingService.Bll.Services.Abstracts;
using RatingService.Dal.DbContexts;

namespace RatingService.Bll.Services.Implementations
{
    public class ProviderServices(PostgreDbContext dbContext, ILogger<ProviderServices> logger) : IProviderServices
    {
        private readonly ILogger<ProviderServices> logger = logger;
        private readonly PostgreDbContext dbContext = dbContext;
        public async Task<bool> CheckProvider(int providerId)
            => await dbContext.Providers.AnyAsync(provider => provider.Id == providerId);
    }
}

