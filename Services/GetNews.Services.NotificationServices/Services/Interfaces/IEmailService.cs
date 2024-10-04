using GetNews.Services.NotificationServices.Dtos;

namespace GetNews.Services.NotificationServices.Services.Interfaces
{
    public interface IEmailService
    {
        public  Task SendEmailAsync(EmailDto emailDto);
    }
}
