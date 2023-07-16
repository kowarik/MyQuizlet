using System.ComponentModel.DataAnnotations;

namespace MyQuizlet.Application.DTO
{
    public class SignInDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
