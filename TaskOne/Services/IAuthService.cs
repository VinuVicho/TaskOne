using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface IAuthService
    {
        /// <summary>
        /// Method to register Executor
        /// </summary>
        /// <returns>Registered user</returns>
        public ExecutorDto RegisterExecutor(ExecutorRequestDto executorDto);
        /// <summary>
        /// Method accepts Email and Password to verify and returns JWT.
        /// </summary>
        /// <param name="loginRequest">Request with Email and Password</param>
        /// <returns>JWT</returns>
        public string Login(ExecutorLoginDto loginRequest);
    }
}
