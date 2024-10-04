using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using GetNews.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Queries.GetNewsById
{
    public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQueryRequest, GetNewsByIdQueryResponse>
    {
        private readonly INewsReadRepository _readRepository;

        public GetNewsByIdQueryHandler(INewsReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetNewsByIdQueryResponse> Handle(GetNewsByIdQueryRequest request, CancellationToken cancellationToken)
        {
            if (Guid.TryParse(request.Id, out var id))
            {
                var response = await _readRepository.GetById(Guid.Parse(request.Id));

                return new()
                {
                    Response = response,
                };
            }

            var errorResponse = Response<ENews>.Fail("News not found", 404);
            return new()
            {
                Response = errorResponse

            };

        }
    }
}
