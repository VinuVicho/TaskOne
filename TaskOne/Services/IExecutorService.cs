using Microsoft.AspNetCore.Identity.Data;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface IExecutorService
    {
        public ExecutorDto RegisterExecutor(ExecutorRequestDto executorDto);
        public string Login(ExecutorLoginDto loginRequest);
    }
}
