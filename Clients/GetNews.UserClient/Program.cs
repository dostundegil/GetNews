using GetNews.UserClient.Handlers;
using GetNews.UserClient.Models.ApiSettings;
using GetNews.UserClient.Services.Abstract;
using GetNews.UserClient.Services.Interfaces;
using IdentityModel.AspNetCore.AccessTokenManagement;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddAccessTokenManagement();

var serviceApiSettings = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();

builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddHttpClient<INewsService, NewsService>(opt =>
{
    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.News.Path}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();

builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=News}/{action=Index}/{id?}");

app.Run();
