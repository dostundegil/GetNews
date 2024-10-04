using GetNews.Services.News.Application.Repositories.NewsRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Queries.GetAllNews
{
    public class GetAllNewsQueryHandler : IRequestHandler<GetAllNewsQueryRequest, GetAllNewsQueryResponse>
    {
        private readonly INewsReadRepository _readRepository;

        public GetAllNewsQueryHandler(INewsReadRepository readRepository)
        {
            _readRepository = readRepository;
        }

        public async Task<GetAllNewsQueryResponse> Handle(GetAllNewsQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await _readRepository.GetAll();
            return new()
            {
                Response = response
            };
        }
    }
}
