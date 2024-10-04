using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Persistence.Repositories.NewsRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddSingleton<INewsReadRepository, NewsReadRepository>();
            services.AddSingleton<INewsWriteRepository, NewsWriteRepository>();
        }
    }
}
