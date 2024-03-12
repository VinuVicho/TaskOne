using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;
using TaskOne.Models.Repositories.Impl;

namespace TaskOne.Services.Impl
{
    public class ExecutorService(IExecutorRepo executorRepo, IMapper mapper) : IExecutorService
    {
        public ICollection<ExecutorDto> GetExecutors()
        {
            return executorRepo.GetExecutors().Select(mapper.Map<ExecutorDto>).ToList();
        }

        public ExecutorDto UpdateExecutor(ExecutorDto executorDto)
        {
            var resultExecutor = executorRepo.UpdateExecutor(mapper.Map<Executor>(executorDto));
            return mapper.Map<ExecutorDto>(resultExecutor);
        }

        public ExecutorDto GetExecutor(int executorId)
        {
            var executor = executorRepo.GetExecutor(executorId);
            if (executor == null)
            {
                throw new NotFoundException("Executor not found with id: " + executorId);
            }
            return mapper.Map<ExecutorDto>(executor);
        }
    }
}
