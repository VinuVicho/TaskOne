using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskOne.Data;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ExecutorService(IExecutorRepo executorRepo, IConfiguration configuration, IMapper mapper) : IExecutorService
    {
        private readonly IConfiguration _configuration = configuration;

        public ExecutorDto RegisterExecutor(ExecutorRequestDto request)
        {
            var executor = mapper.Map<Executor>(request);
            executor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var savedExecutor = executorRepo.AddExecutor(executor);
            return mapper.Map<ExecutorDto>(savedExecutor);
        }

        public string Login(ExecutorLoginDto loginRequest)
        {
            var executor = executorRepo.GetExecutor(loginRequest.Email);
            if (executor == null)
            {
                throw new Exception("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, executor.PasswordHash))
            {
                throw new Exception("Wrong password.");
            }

            string token = CreateToken(executor);

            return token;
        }

        private string CreateToken(Executor executor)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, executor.Email),
                new Claim(ClaimTypes.Role, executor.GetType().FullName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value!));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
