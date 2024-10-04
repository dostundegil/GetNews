using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.CreateNews
{
    public class CreateNewsCommandResponse
    {
        public Response<NoContent> Response { get; set; }
    }
}
