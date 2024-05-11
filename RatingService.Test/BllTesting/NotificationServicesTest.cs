using Microsoft.Extensions.Caching.Memory;
using NSubstitute;
using RatingService.Bll.Exceptions;
using RatingService.Bll.Globals;
using RatingService.Bll.Services.Abstracts;
using RatingService.Bll.Services.Implementations;
using RatingService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatingService.Test.BllTesting
{
    public class NotificationServicesTest
    {
        #region fields
        private readonly NotificationServices notificationServices;
        private readonly IMemoryCache cacheMock;
        private readonly IProviderServices providerServicesMock;

        private static readonly int ProviderId = 1;
        private static readonly string CahceKey = $"{Constants.RatingCacheKey}{ProviderId}";
        #endregion
        public NotificationServicesTest()
        {
            cacheMock = Substitute.For<IMemoryCache>();
            providerServicesMock = Substitute.For<IProviderServices>();
            notificationServices = new NotificationServices(cacheMock, providerServicesMock);
        }

        [Fact]
        public async Task GetProviderNotifications_Should_Throw_Error_WhenProviderNotFound()
        {
            //Arrange
            int providerId = ProviderId;

            providerServicesMock.CheckProvider(providerId).Returns(false);

            //Act
            var result = await Assert.ThrowsAsync<NotFoundException>(()=> notificationServices.GetProviderNotificationsAsync(providerId));

            //Assert
            Assert.Equal(ExceptionMessages.ProviderNotFound, result.Message);
        }

        [Fact]
        public async Task GetProviderNotifications_Should_Throw_Error_WhenNotificationNotFound()
        {
            //Arrange
            int providerId = ProviderId;
            var data = new List<RatingDto>();
            providerServicesMock.CheckProvider(providerId).Returns(true);
            cacheMock.TryGetValue(CahceKey,out data).Returns(false);
            //Act
            var result = await Assert.ThrowsAsync<NotFoundException>(() => notificationServices.GetProviderNotificationsAsync(providerId));

            //Assert
            Assert.Equal(ExceptionMessages.NoNewNotification, result.Message);
        }

        [Fact]
        public async Task GetProviderNotifications_Should_ReturnList()
        {
            // Arrange
            var providerId = 1;
            providerServicesMock.CheckProvider(providerId).Returns(true);
            var key = $"{Constants.RatingCacheKey}{providerId}";
            var notifications = new List<RatingDto> { new RatingDto(), new RatingDto() };
            cacheMock.TryGetValue(key, out Arg.Any<List<RatingDto>>()).Returns(true).AndDoes(x =>
            {
                x[1] = notifications;
            });

            // Act
            var result = await notificationServices.GetProviderNotificationsAsync(providerId);

            // Assert
            Assert.Equal(notifications, result);
        }

    }
}
