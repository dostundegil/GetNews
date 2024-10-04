using GetNews.Services.News.Application.Features.Commands.CreateNews;
using GetNews.Services.News.Application.Features.Commands.DeleteNews;
using GetNews.Services.News.Application.Features.Commands.UpdateNews;
using GetNews.Services.News.Application.Features.Queries.GetAllNews;
using GetNews.Services.News.Application.Features.Queries.GetNewsById;
using GetNews.Shared.ControllerBases;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetNews.Services.News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NewsController : CustomBaseController
    {
        private readonly IMediator _mediatR;

        public NewsController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllNewsQueryRequest request)
        {
            GetAllNewsQueryResponse response =  await _mediatR.Send(request);
            return CreateActionResultInstance(response.Response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetNewsById(string Id)
        {
            var request = new GetNewsByIdQueryRequest { Id = Id };
            GetNewsByIdQueryResponse response = await _mediatR.Send(request);
            return CreateActionResultInstance(response.Response);
        }

        [Authorize(AuthenticationSchemes = "AdminScheme")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateNewsCommandRequest request)
        {
            CreateNewsCommandResponse response = await _mediatR.Send(request);
            return CreateActionResultInstance(response.Response);
        }

        [Authorize(AuthenticationSchemes = "AdminScheme")]
        [HttpPut]
        public async Task<IActionResult> Put(UpdateNewsCommandRequest request)
        {
            UpdateNewsCommandResponse response = await _mediatR.Send(request);
            return CreateActionResultInstance(response.Response);
        }

        [Authorize(AuthenticationSchemes = "AdminScheme")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(string id)
        {
            DeleteNewsCommandRequest request = new();
            request.Id = id;
            DeleteNewsCommandResponse response = await _mediatR.Send(request);
            return CreateActionResultInstance(response.Response);
        }
    }
}
