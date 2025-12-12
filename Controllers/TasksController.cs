using Microsoft.AspNetCore.Mvc;
using TeamTasker.API.DTOs;
using TeamTasker.API.Entities;
using TeamTasker.API.Enums;
using TeamTasker.API.Mappers;
using TeamTasker.API.Repositories;

namespace TeamTasker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        // Agora temos DOIS assistentes (Repositórios)
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        // Injetamos os dois no construtor
        public TasksController(ITaskRepository taskRepository, IUserRepository userRepository)
        {
            _taskRepository = taskRepository;
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _taskRepository.GetAllAsync();
            var tasksDto = tasks.Select(t => t.ToDto());
            return Ok(tasksDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskDto dto)
        {
            // --- MUDANÇA AQUI ---
            // Usamos o método pronto do repositório de usuários
            if (!await _userRepository.UserExistsAsync(dto.UserId))
            {
                return BadRequest("Usuário não encontrado. Verifique o ID enviado.");
            }
            // --------------------

            var newTask = new JobTask
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                Status = TaskStatusEnum.Pendente,
                CreatedAt = DateTime.Now
            };

            await _taskRepository.AddAsync(newTask);

            var taskWithUser = await _taskRepository.GetByIdAsync(newTask.Id);

            return CreatedAtAction(nameof(GetAll), new { id = newTask.Id }, taskWithUser!.ToDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
        {
            var task = await _taskRepository.GetByIdAsync(id);

            if (task == null) return NotFound("Tarefa não encontrada.");

            // Verifica se mudou de dono
            if (dto.UserId != task.UserId)
            {
                // --- MUDANÇA AQUI TAMBÉM ---
                if (!await _userRepository.UserExistsAsync(dto.UserId))
                {
                    return BadRequest("O novo usuário informado não existe.");
                }
                // ---------------------------
            }

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.UserId = dto.UserId;

            await _taskRepository.UpdateAsync(task);

            return Ok(task.ToDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskRepository.GetByIdAsync(id);
            
            if (task == null) return NotFound();

            await _taskRepository.DeleteAsync(task);

            return NoContent();
        }
    }
}