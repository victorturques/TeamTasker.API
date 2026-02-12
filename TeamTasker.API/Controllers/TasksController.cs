using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTasker.API.DTOs;
using TeamTasker.API.Entities;
using TeamTasker.API.Enums;
using TeamTasker.API.Mappers;
using TeamTasker.API.Repositories;

namespace TeamTasker.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        
        private readonly ITaskRepository _taskRepository;
        private readonly IUserRepository _userRepository;

        
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
           
            if (!await _userRepository.UserExistsAsync(dto.UserId))
            {
                return BadRequest("Usuário não encontrado. Verifique o ID enviado.");
            }
            

            var newTask = new JobTask
            {
                Title = dto.Title,
                Description = dto.Description,
                UserId = dto.UserId,
                Status = dto.Status,
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

           
            if (dto.UserId != task.UserId)
            {
                
                if (!await _userRepository.UserExistsAsync(dto.UserId))
                {
                    return BadRequest("O novo usuário informado não existe.");
                }
                
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