using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using GetNews.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommandRequest, DeleteNewsCommandResponse>
    {
        private readonly INewsWriteRepository _newsWriteRepository;

        public DeleteNewsCommandHandler(INewsWriteRepository newsWriteRepository)
        {
            _newsWriteRepository = newsWriteRepository;
        }

        public async Task<DeleteNewsCommandResponse> Handle(DeleteNewsCommandRequest request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.Id, out var id))
            {
                var response = await _newsWriteRepository.Delete(Guid.Parse(request.Id));

                return new()
                {
                    Response = response,
                };
            }

            var errorResponse = Response<NoContent>.Fail("News not found", 404);

            return new()
            {
                Response = errorResponse
            };
        }
    }
}
