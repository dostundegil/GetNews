using GetNews.Services.News.Domain.Entities;
using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Repositories.NewsRepositories
{
    public interface INewsWriteRepository
    {
        Task<Response<NoContent>> Create(ENews news);
        Task<Response<NoContent>> Update(ENews news);
        Task<Response<NoContent>> Delete(Guid id);
    }
}
