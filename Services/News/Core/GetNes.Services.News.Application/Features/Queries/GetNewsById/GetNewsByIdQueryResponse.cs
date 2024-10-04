using GetNews.Services.News.Domain.Entities;
using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Queries.GetNewsById
{
    public class GetNewsByIdQueryResponse
    {
        public Response<ENews> Response { get; set; }
    }
}
