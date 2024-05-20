using Microsoft.Extensions.Caching.Memory;
using NSubstitute;
using RatingService.Bll.Exceptions;
using RatingService.Bll.Globals;
using RatingService.Bll.Services.Abstracts;
using RatingService.Bll.Services.Implementations;
using RatingService.Dtos;

namespace RatingService.Test.BllTesting
{
    public class RatingServicesTest
    {
        #region fields
        private readonly RatingServices ratingServices;
        private readonly IUserServices userServicesMock;
        private readonly IProviderServices providerServicesMock;
        private readonly IMemoryCache cacheMock;
        private static readonly int UserId = 1;
        private static readonly int ProviderId = 1;
        private static readonly int Point = 3;
        #endregion
        public RatingServicesTest()
        {
            userServicesMock = Substitute.For<IUserServices>();
            providerServicesMock = Substitute.For<IProviderServices>();
            cacheMock = Substitute.For<IMemoryCache>();
            ratingServices = new RatingServices(null, userServicesMock, providerServicesMock, cacheMock);
        }

        #region RateAsync Tests
        [Fact]
        public async Task RateAsync_Should_ThrowError_WhenUserNotFound()
        {
            //Arrange
            var rate = new RatingDto
            {
                UserId = UserId,
                ProviderId = ProviderId,
                Point = Point
            };

            userServicesMock.CheckUser(rate.UserId).Returns(false);

            //Act
            var result = await Assert.ThrowsAsync<NotFoundException>(() => ratingServices.RateAsync(rate));

            //Assert
            Assert.Equal(ExceptionMessages.UserNotFound, result.Message);
        }

        [Fact]
        public async Task Rate_Async_Should_ThrowError_WhenProviderNotFound()
        {
            //Arrange
            var rate = new RatingDto
            {
                UserId = UserId,
                ProviderId = ProviderId,
                Point = Point
            };

            userServicesMock.CheckUser(rate.UserId).Returns(true);
            providerServicesMock.CheckProvider(ProviderId).Returns(false);

            //Act
            var result = await Assert.ThrowsAsync<NotFoundException>(() => ratingServices.RateAsync(rate));

            //Assert
            Assert.Equal(ExceptionMessages.ProviderNotFound, result.Message);
        }

        [Fact]
        public async Task Rate_Async_Should_ThrowError_WhenPointBelowZero()
        {
            //Arrange
            var rate = new RatingDto
            {
                UserId = UserId,
                ProviderId = ProviderId,
                Point = -1
            };

            userServicesMock.CheckUser(rate.UserId).Returns(true);
            providerServicesMock.CheckProvider(ProviderId).Returns(true);

            //Act
            var result = await Assert.ThrowsAsync<BadRequestException>(() => ratingServices.RateAsync(rate));

            //Assert
            Assert.Equal(ExceptionMessages.UserPointError, result.Message);
        }

        [Fact]
        public async Task Rate_Async_Should_ThrowError_WhenPointAboveFive()
        {
            //Arrange
            var rate = new RatingDto
            {
                UserId = UserId,
                ProviderId = ProviderId,
                Point = 6
            };

            userServicesMock.CheckUser(rate.UserId).Returns(true);
            providerServicesMock.CheckProvider(ProviderId).Returns(true);

            //Act
            var result = await Assert.ThrowsAsync<BadRequestException>(() => ratingServices.RateAsync(rate));

            //Assert
            Assert.Equal(ExceptionMessages.UserPointError, result.Message);
        }
        #endregion

        #region AvarageasyncTests
        [Fact]
        public async Task Avarage_Async_Should_ThrowError_WhenProviderNotFound()
        {
            //Arrange
            providerServicesMock.CheckProvider(ProviderId).Returns(false);

            //Act
            var result = await Assert.ThrowsAsync<NotFoundException>(() => ratingServices.AvarageAsync(ProviderId));

            //Assert
            Assert.Equal(ExceptionMessages.ProviderNotFound, result.Message);
        }
        #endregion
    }
}
