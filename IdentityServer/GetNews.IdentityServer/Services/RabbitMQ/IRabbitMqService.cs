using GetNews.IdentityServer.Models;

namespace GetNews.IdentityServer.Services.RabbitMQ
{
    public interface IRabbitMqService
    {
        public void SendEmailMessage(SendEmailModel emailMessage);
    }
}
