﻿using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RatingService.Dal.MessageBrokers.Abstract;
using System.Text;

namespace RatingService.Dal.MessageBrokers.Implementations
{
    public class NotificationBroker(IConfiguration configuration) : INotificationBroker
    {
        private readonly IConfiguration configuration = configuration;

        public Task SendToQueue(string notificationMessage, int providerId)
        {
            var factory = new ConnectionFactory()
            {
                HostName = configuration["NotificationBroker:HostName"],
                UserName = configuration["NotificationBroker:UserName"],
                Password = configuration["NotificationBroker:Password"],
                Ssl = new SslOption()
                {
                    Enabled = false,
                    ServerName = $"{configuration["NotificationBroker:HostName"]}"
                }
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                string queueName = $"{configuration["NotificationBroker:QueueName"]}-{providerId}";

                channel.QueueDeclare(
                    queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                var body = Encoding.UTF8.GetBytes(notificationMessage);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: queueName,
                    body: body);
            }

            return Task.CompletedTask;
        }
    }
}
