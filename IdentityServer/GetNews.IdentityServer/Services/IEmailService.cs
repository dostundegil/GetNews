using System.Threading.Tasks;

namespace GetNews.IdentityServer.Services
{
    public interface IEmailService
    {
        public Task SendWelcomeEmailAsync(string email);
    }
}
