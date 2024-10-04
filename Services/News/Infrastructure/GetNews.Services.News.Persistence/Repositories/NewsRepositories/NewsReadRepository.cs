using Dapper;
using GetNews.Services.News.Application.Repositories.NewsRepositories;
using GetNews.Services.News.Domain.Entities;
using GetNews.Services.News.Persistence.Settings.DbSettings;
using GetNews.Shared.Dtos;
using Npgsql;
using System.Data;

namespace GetNews.Services.News.Persistence.Repositories.NewsRepositories
{
    public class NewsReadRepository : INewsReadRepository
    {
        private readonly string _connectionString;

        public NewsReadRepository(IDatabaseSettings databaseSettings) 
        {
            _connectionString = databaseSettings.ConnectionString;
        }

        public async Task<Response<List<ENews>>> GetAll()
        {
            using (var dbConnection = new NpgsqlConnection(_connectionString)) 
            {
                await dbConnection.OpenAsync();

                var news = await dbConnection.QueryAsync<ENews>("SELECT * FROM news");
                return Response<List<ENews>>.Success(news.ToList(), 200);
            } 
        }

        public async Task<Response<ENews>> GetById(Guid id)
        {
            using (var dbConnection = new NpgsqlConnection(_connectionString)) 
            {
                await dbConnection.OpenAsync(); 

                var news = (await dbConnection.QueryAsync<ENews>("SELECT * FROM news WHERE id = @Id", new { Id = id })).SingleOrDefault();

                if (news == null)
                {
                    return Response<ENews>.Fail("News not found", 404);
                }

                return Response<ENews>.Success(news, 200);
            } 
        }
    }
}
