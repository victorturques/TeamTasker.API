using TeamTasker.API.DTOs;
using TeamTasker.API.Entities;

namespace TeamTasker.API.Mappers
{
    public static class TaskMapper
    {
        // O "this" na frente do parâmetro é o que cria a mágica do Extension Method
        public static TaskResponseDto ToDto(this JobTask task)
        {
            return new TaskResponseDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                
                
                Status = task.Status.ToString(),
                
                
                CreatedAt = task.CreatedAt,
                
                
                User = new UserSummaryDto
                {
                    Id = task.User?.Id ?? 0, 
                    Name = task.User?.Name ?? "Usuário Desconhecido",
                    Email = task.User?.Email ?? ""
                }
            };
        }
    }
}