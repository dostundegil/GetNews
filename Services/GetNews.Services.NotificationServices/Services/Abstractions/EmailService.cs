using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Logging; 
using System;
using System.Threading.Tasks;
using GetNews.Services.NotificationServices.Dtos;
using GetNews.Services.NotificationServices.Models;
using GetNews.Services.NotificationServices.Services.Interfaces;

public class EmailService : IEmailService
{
    private readonly SmtpSettings _smtpSettings;
    private readonly ILogger<EmailService> _logger; 

    public EmailService(SmtpSettings smtpSettings, ILogger<EmailService> logger)
    {
        _smtpSettings = smtpSettings;
        _logger = logger; 
    }

    public async Task SendEmailAsync(EmailDto emailDto)
    {
        var emailMessage = new MimeMessage();
        emailMessage.From.Add(new MailboxAddress("GetNews", _smtpSettings.Username)); 
        emailMessage.To.Add(new MailboxAddress(emailDto.Email, emailDto.Email)); 
        emailMessage.Subject = "Welcome";
        emailMessage.Body = new TextPart("plain") 
        {
            Text = "GetNews'e hoşgeldiniz!"
        };

        using var client = new SmtpClient();
        try
        {
            await client.ConnectAsync(_smtpSettings.Host, _smtpSettings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpSettings.Username, _smtpSettings.Password);
            await client.SendAsync(emailMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error sending email: {ex.Message}"); 
            throw;
        }
        finally
        {
            await client.DisconnectAsync(true);
        }
    }
}
