using Microsoft.AspNetCore.Mvc;
using TeamTasker.API.DTOs;
using TeamTasker.API.Entities;
using TeamTasker.API.Repositories; 

namespace TeamTasker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _repository; 

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _repository.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email
            };

            await _repository.AddAsync(user);
            
            return CreatedAtAction(nameof(GetAll), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto dto)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null) return NotFound("Usuário não encontrado.");

            user.Name = dto.Name;
            user.Email = dto.Email;

            await _repository.UpdateAsync(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _repository.GetByIdAsync(id);
            
            if (user == null) return NotFound();

            await _repository.DeleteAsync(user);

            return NoContent();
        }
    }
}