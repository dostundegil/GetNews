using GetNews.Services.News.Domain.Entities;
using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Repositories.NewsRepositories
{
    public interface INewsReadRepository
    {
        Task<Response<List<ENews>>> GetAll();
        Task<Response<ENews>> GetById(Guid id);
    }
}
