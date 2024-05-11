﻿using Microsoft.EntityFrameworkCore;
using RatingService.Bll.Exceptions;
using RatingService.Bll.Globals;
using RatingService.Bll.Services.Abstracts;
using RatingService.Dal.DbContexts;
using RatingService.Dtos;
using RatingService.Entities;

namespace RatingService.Bll.Services.Implementations
{
    public class RatingServices(
        PostgreDbContext dbContext,
        IUserServices userServices,
        IProviderServices providerServices) : IRatingServices
    {

        #region fields        
        private readonly PostgreDbContext dbContext = dbContext;
        private readonly IUserServices userServices = userServices;
        private readonly IProviderServices providerServices = providerServices;
        #endregion

        public async Task<double> AvarageAsync(int providerId)
        {
            var checkProvider = await providerServices.CheckProvider(providerId);

            if (!checkProvider)
                throw new NotFoundException(ExceptionMessages.ProviderNotFound);

            var avaragePoint = await dbContext.Ratings
                .Where(provider => provider.ProviderId == providerId)
                .AverageAsync(rate => rate.Point);

            return avaragePoint;
        }

        public async Task<int> RateAsync(RatingDto rate)
        {
            var checkUser = await userServices.CheckUser(rate.UserId);

            if (!checkUser)
                throw new NotFoundException(ExceptionMessages.UserNotFound);

            var checkProvider = await providerServices.CheckProvider(rate.ProviderId);

            if (!checkProvider)
                throw new NotFoundException(ExceptionMessages.ProviderNotFound);

            if (rate.Point < 0 || rate.Point > 5)
                throw new BadRequestException(ExceptionMessages.UserPointError);

            await dbContext.Ratings.AddAsync(new RatingEntity
            {
                UserId = rate.UserId,
                ProviderId = rate.ProviderId,
                Point = rate.Point,
                CreatedAt = DateTime.UtcNow
            });

            return await dbContext.SaveChangesAsync();
        }
    }
}
