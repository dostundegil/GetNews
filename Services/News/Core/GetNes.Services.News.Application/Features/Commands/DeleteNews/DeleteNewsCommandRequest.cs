using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommandRequest:IRequest<DeleteNewsCommandResponse>
    {
        public string Id { get; set; }
    }
}
