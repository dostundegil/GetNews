using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommandRequest, CreateNewsCommandResponse>
    {
        private readonly INewsWriteRepository _newsWriteRepository;

        public CreateNewsCommandHandler(INewsWriteRepository newsWriteRepository)
        {
            _newsWriteRepository = newsWriteRepository;
        }

        public async Task<CreateNewsCommandResponse> Handle(CreateNewsCommandRequest request, CancellationToken cancellationToken)
        {
            ENews news = new()
            {
                Content = request.Content,
                image_url = request.image_url,
                Summary = request.Summary,
                Title = request.Title,
                Id = Guid.NewGuid(),
                last_updated = DateTime.UtcNow,
                publish_date = DateTime.UtcNow,
                is_published = request.is_published
            };

            var response = await _newsWriteRepository.Create(news);

            return new()
            {
                Response = response
            };
        }
    }
}
