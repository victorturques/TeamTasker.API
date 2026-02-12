using System.ComponentModel.DataAnnotations;
using TeamTasker.API.Enums;

namespace TeamTasker.API.DTOs
{
    
    public record CreateTaskDto
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "É necessário informar o ID do usuário")]
        public int UserId { get; set; }
        public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Pendente;
    }
}