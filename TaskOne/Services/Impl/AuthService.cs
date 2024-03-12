using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class AuthService(IExecutorRepo executorRepo, IConfiguration configuration, IMapper mapper) : IAuthService
    {
        /// <inheritdoc cref=""/>
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
                throw new NotFoundException("User not found with email: " + loginRequest.Email);
            }

            if (!BCrypt.Net.BCrypt.Verify(loginRequest.Password, executor.PasswordHash))
            {
                throw new BadHttpRequestException("Wrong password");
            }

            string token = CreateToken(executor);

            return token;
        }

         ///Creates JWT token, that has role same as class of applicant
        private string CreateToken(Executor executor)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, executor.Email),
                new Claim(ClaimTypes.Role, executor.GetType().Name!)
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
