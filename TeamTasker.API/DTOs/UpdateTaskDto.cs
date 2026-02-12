using System.ComponentModel.DataAnnotations;
using TeamTasker.API.Enums;

namespace TeamTasker.API.DTOs
{
    public record UpdateTaskDto
    {
        [Required(ErrorMessage = "O título é obrigatório")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TaskStatusEnum Status { get; set; }

        [Required(ErrorMessage = "Informe o ID do usuário dono da tarefa")]
        public int UserId { get; set; } 
    }
}