using AutoMapper;
using TaskOne.Exceptions;
using TaskOne.Models.Dtos;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ExecutorService(IExecutorRepo executorRepo, IMapper mapper) : IExecutorService
    {
        public ICollection<ExecutorDto> GetExecutors()
        {
            return executorRepo.GetExecutors().Select(mapper.Map<ExecutorDto>).ToList();
        }

        //public ExecutorDto UpdateExecutor(ExecutorDto executorDto)
        //{
        //    var resultExecutor = executorRepo.UpdateExecutor(mapper.Map<Executor>(executorDto));
        //    return mapper.Map<ExecutorDto>(resultExecutor);
        //}

        public ExecutorDto GetExecutor(int executorId)
        {
            var executor = executorRepo.GetExecutorById(executorId);
            return executor == null
                ? throw new NotFoundException("Executor not found with id: " + executorId)
                : mapper.Map<ExecutorDto>(executor);
        }
    }
}
