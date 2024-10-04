using System.ComponentModel.DataAnnotations;

namespace GetNews.IdentityServer.Dtos
{
    public class UserSignUpDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
