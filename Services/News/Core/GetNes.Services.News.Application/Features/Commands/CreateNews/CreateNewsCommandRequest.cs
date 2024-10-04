using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.CreateNews
{
    public class CreateNewsCommandRequest:IRequest<CreateNewsCommandResponse>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Summary { get; set; }
        public bool is_published { get; set; }
        public string image_url { get; set; }
    }
}
