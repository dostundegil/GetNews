using Dapper;
using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using GetNews.Services.News.Persistence.Settings.DbSettings;
using GetNews.Shared.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GetNews.Services.News.Persistence.Repositories.NewsRepositories
{
    public class NewsWriteRepository : INewsWriteRepository
    {
        private readonly string _connectionString;

        public NewsWriteRepository(IDatabaseSettings databaseSettings)
        {
            _connectionString = databaseSettings.ConnectionString;
        }

        public async Task<Response<NoContent>> Create(ENews news)
        {
            using (var dbConnection = new NpgsqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();
                var saveStatus = await dbConnection.ExecuteAsync("INSERT INTO news (id,title,content,summary,is_published,publish_date,last_updated,image_url) VALUES(@Id, @Title,@Content,@Summary,@is_published,@publish_date,@last_updated,@image_url)", news);
                return saveStatus > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("An error occurred while creating news", 500);
            }
        }

        public async Task<Response<NoContent>> Update(ENews news)
        {
            using (var dbConnection = new NpgsqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();
                var status = await dbConnection.ExecuteAsync(
                    "UPDATE news SET title=@Title, content=@Content, summary=@Summary, is_published=@is_published, lasT_updated=@last_updated, image_url=@image_url WHERE Id=@Id",
                    new
                    {
                        Id = news.Id,
                        Title = news.Title,
                        Content = news.Content,
                        Summary = news.Summary,
                        is_published = news.is_published,
                        lasT_updated = news.last_updated,
                        image_url = news.image_url
                    });
                return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("News not found", 404);
            }
        }

        public async Task<Response<NoContent>> Delete(Guid id)
        {
            using (var dbConnection = new NpgsqlConnection(_connectionString))
            {
                await dbConnection.OpenAsync();
                var status = await dbConnection.ExecuteAsync("DELETE FROM news WHERE id = @Id", new { Id = id });
                return status > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("News not found", 404);
            }
        }
    }
}
