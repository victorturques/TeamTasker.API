using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TeamTasker.API.Entities;

namespace TeamTasker.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            // Pega a mesma chave que configuramos no Program.cs
            var jwtKey = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Chave JWT não encontrada!");
            var key = Encoding.ASCII.GetBytes(jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // O "Payload" (dados que vão dentro do token)
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()), // Guardamos o ID
                    new Claim(ClaimTypes.Email, user.Email)         // Guardamos o Email
                }),
                Expires = DateTime.UtcNow.AddHours(4), // Token dura 4 horas
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}