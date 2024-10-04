using GetNews.Services.NotificationServices.Dtos;
using GetNews.Services.NotificationServices.Services.Abstractions;
using GetNews.Services.NotificationServices.Services.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GetNews.Services.NotificationServices.Services
{
    public class RabbitMqListener
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IEmailService _emailService;

        public RabbitMqListener(IConfiguration configuration, IEmailService emailService)
        {
            _emailService = emailService;

            var factory = new ConnectionFactory()
            {
                HostName = configuration["RabbitMQ:Host"],
                Port = int.Parse(configuration["RabbitMQ:Port"]),
                UserName = configuration["RabbitMQ:Username"],
                Password = configuration["RabbitMQ:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "email_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            StartListening();
        }

        public void StartListening()
        {
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var email = JsonSerializer.Deserialize<EmailDto>(message);

                await _emailService.SendEmailAsync(email);
            };
            _channel.BasicConsume(queue: "email_queue", autoAck: true, consumer: consumer);
        }
    }
}
