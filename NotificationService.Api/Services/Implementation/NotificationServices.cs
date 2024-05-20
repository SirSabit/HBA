using NotificationService.Api.Services.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NotificationService.Api.Services.Implementation
{
    public class NotificationServices(IConfiguration configuration) : INotificationServices
    {
        private readonly IConfiguration configuration = configuration;

        public List<string> GetNotifications(int providerId)
        {
            var response = new List<string>();

            string queueName = $"{configuration["NotificationBroker:QueueName"]}-{providerId}";
            var factory = new ConnectionFactory() { HostName = configuration["NotificationBroker:HostName"], UserName = configuration["NotificationBroker:UserName"], Password = configuration["NotificationBroker:Password"] };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var body = args.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                response.Add(message);
            };

            channel.BasicConsume(
                queue: queueName,
                autoAck: true,
                consumer: consumer);

            return response;
        }
    }
}
