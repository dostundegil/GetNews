﻿using GetNews.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Application.Features.Commands.DeleteNews
{
    public class DeleteNewsCommandResponse
    {
        public Response<NoContent> Response { get; set; }
    }
}
