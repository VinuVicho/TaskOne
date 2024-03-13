using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ExecutorService(IExecutorRepo executorRepo, IMapper mapper) : IExecutorService
    {
        public ICollection<ExecutorDto> GetExecutors()
        {
            return executorRepo.GetExecutors().Select(mapper.Map<ExecutorDto>).ToList();
        }

        public ExecutorDto UpdateExecutor(ExecutorUpdateRequest request)
        {
            var executor = mapper.Map<Executor>(request);
            executor.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            var resultExecutor = executorRepo.UpdateExecutor(executor);
            return mapper.Map<ExecutorDto>(resultExecutor);
        }

        public ExecutorDto GetExecutor(int executorId)
        {
            var executor = executorRepo.GetExecutorById(executorId);
            return executor == null
                ? throw new NotFoundException("Executor not found with id: " + executorId)
                : mapper.Map<ExecutorDto>(executor);
        }
    }
}
