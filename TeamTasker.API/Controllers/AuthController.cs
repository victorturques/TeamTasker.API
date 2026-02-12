using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamTasker.API.DTOs;
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

        // Injeção de Dependência: O .NET entrega o Repo e o TokenService prontos aqui
        public AuthController(IUserRepository repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            // Busca o usuário no banco pelo email
            var user = await _repository.GetUserByEmailAsync(model.Email);

            //  Valida se o usuário existe e se a senha bate
              if (user == null || user.Password != model.Password)
                return Unauthorized("Usuário ou senha inválidos");

            // Se deu tudo certo, gera o Token
            var token = _tokenService.GenerateToken(user);

            // Devolve o token para quem chamou a API
            return Ok(new { token = token });
        }
    }
}