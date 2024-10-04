using GetNews.Services.News.Persistence;
using GetNews.Services.News.Application;
using GetNews.Services.News.Persistence.Settings.DbSettings;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new AuthorizeFilter());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = "UserScheme";
    options.DefaultChallengeScheme = "UserScheme";
})
.AddJwtBearer("UserScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "resource_client"; // Herkes için olan þema
    opt.RequireHttpsMetadata = false;
})
.AddJwtBearer("AdminScheme", opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "resource_admin"; // Adminler için olan þema
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSingleton<IDatabaseSettings, DatabaseSettings>();
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp => sp.GetRequiredService<IOptions<DatabaseSettings>>().Value);

builder.Services.AddTransient<IDbConnection>(sp =>
{
    var dbSettings = sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    return new NpgsqlConnection(dbSettings.ConnectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
