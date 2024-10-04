using GetNews.AdminClient.Handlers;
using GetNews.AdminClient.Models.ApiSettings;
using GetNews.AdminClient.Services.Abstract;
using GetNews.AdminClient.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));

builder.Services.Configure<AdminClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddScoped<ClientCredentialTokenHandler>();

builder.Services.AddScoped<IClientCredentialTokenService, ClientCredentialTokenService>();

builder.Services.Configure<ClientSettingsForUser>(builder.Configuration.GetSection("ClientSettingsForUser"));

builder.Services.AddAccessTokenManagement();
var serviceApiSettings = builder.Configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
builder.Services.AddScoped<ResourceOwnerPasswordTokenHandler>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddHttpClient<INewsService, NewsService>(opt =>
{
    opt.BaseAddress = new Uri($"{serviceApiSettings.GatewayBaseUri}/{serviceApiSettings.News.Path}");

}).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

builder.Services.AddHttpClient<IUserService, UserService>(opt =>
{
    opt.BaseAddress = new Uri($"{serviceApiSettings.IdentityBaseUri}");
}).AddHttpMessageHandler<ClientCredentialTokenHandler>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
    {
        opt.LoginPath = "/Auth/SignIn";
        opt.ExpireTimeSpan = TimeSpan.FromDays(60);
        opt.SlidingExpiration = true;
        opt.Cookie.Name = "webcookie";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Authentication must be added before UseAuthorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
