using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommandRequest, UpdateNewsCommandResponse>
    {
        private readonly INewsWriteRepository _newsWriteRepository;

        public UpdateNewsCommandHandler(INewsWriteRepository newsWriteRepository)
        {
            _newsWriteRepository = newsWriteRepository;
        }

        public async Task<UpdateNewsCommandResponse> Handle(UpdateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            ENews news = new()
            {
                Content = request.Content,
                Id = request.Id,
                image_url = request.image_url,
                is_published = request.is_published,
                last_updated = DateTime.UtcNow,
                Summary = request.Summary,
                Title = request.Title,
            };

            var response =await _newsWriteRepository.Update(news);
            return new() { Response = response };
        }
    }
}
