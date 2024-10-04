using GetNews.IdentityServer.Models;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using IModel = RabbitMQ.Client.IModel;

namespace GetNews.IdentityServer.Services.RabbitMQ
{
    public class RabbitMqService:IRabbitMqService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMqService(IConfiguration configuration)
        {
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
        }

        public void SendEmailMessage(SendEmailModel emailMessage)
        {
           var message = JsonSerializer.Serialize(emailMessage);
           var body = Encoding.UTF8.GetBytes(message);

           _channel.BasicPublish(exchange: "", routingKey: "email_queue", basicProperties: null, body: body);
        }
    }
}
