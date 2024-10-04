using GetNews.Services.NotificationServices.Models;
using GetNews.Services.NotificationServices.Services;
using GetNews.Services.NotificationServices.Services.Abstractions;
using GetNews.Services.NotificationServices.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var smtpSettings = builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<RabbitMqListener>(); // Scoped olarak deðiþtirildi

builder.Services.AddSingleton(smtpSettings);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

// RabbitMqListener sýnýfýnýn baþlatýlmasý
using (var scope = app.Services.CreateScope())
{
    var rabbitMqListener = scope.ServiceProvider.GetRequiredService<RabbitMqListener>();
}

app.Run();
