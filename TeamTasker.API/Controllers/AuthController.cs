using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTasker.API.DTOs;
using TeamTasker.API.Entities;
using TeamTasker.API.Repositories;
using TeamTasker.API.Services;

namespace TeamTasker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly TokenService _tokenService;

        public AuthController(IUserRepository repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var existingUser = await _repository.GetUserByEmailAsync(model.Email);
            if (existingUser != null)
                return BadRequest("Email já está em uso.");

            var newUser = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password
            };

            await _repository.CreateUserAsync(newUser);

            return Ok("Usuário criado com sucesso.");
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var user = await _repository.GetUserByEmailAsync(model.Email);

            if (user == null || user.Password != model.Password)
                return Unauthorized("Usuário ou senha inválidos");

            var token = _tokenService.GenerateToken(user);

            return Ok(new { token = token });
        }
    }
}