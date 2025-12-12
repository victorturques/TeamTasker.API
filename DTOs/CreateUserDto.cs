using System.ComponentModel.DataAnnotations;

namespace TeamTasker.API.DTOs
{
    public record CreateUserDto
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; } = string.Empty;
    }
}