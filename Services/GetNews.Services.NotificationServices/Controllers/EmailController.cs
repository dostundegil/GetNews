using GetNews.Services.NotificationServices.Dtos;
using GetNews.Services.NotificationServices.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IEmailService _emailService;
    private readonly ITokenService _tokenService;

    public EmailController(IEmailService emailService, ITokenService tokenService)
    {
        _emailService = emailService;
        _tokenService = tokenService;
    }

    [HttpPost("send")]
    public async Task<IActionResult> SendEmail([FromBody] EmailDto emailDto)
    {
        var response = await _tokenService.GetTokenAsync();
        if (emailDto == null)
        {
            return BadRequest("Email data is required.");
        }

        await _emailService.SendEmailAsync(emailDto);
        return Ok("Email sent successfully.");
    }
}
