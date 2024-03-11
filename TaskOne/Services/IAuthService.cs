using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface IAuthService
    {
        public ExecutorDto RegisterExecutor(ExecutorRequestDto executorDto);
        public string Login(ExecutorLoginDto loginRequest);
    }
}
