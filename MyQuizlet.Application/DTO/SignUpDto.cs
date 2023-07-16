using MyQuizlet.Application.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyQuizlet.Application.DTO
{
    public class SignUpDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public UserRoles Role { get; set; } = UserRoles.User;
    }
}
