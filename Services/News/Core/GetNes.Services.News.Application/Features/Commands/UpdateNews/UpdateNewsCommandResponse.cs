using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.UpdateNews
{
    public class UpdateNewsCommandResponse
    {
        public Response<NoContent> Response{ get; set; }
    }
}
