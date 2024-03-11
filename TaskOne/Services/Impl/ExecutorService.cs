using AutoMapper;
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

        public ExecutorDto UpdateExecutor(ExecutorDto executorDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteCustomer(int executorId)
        {
            throw new NotImplementedException();
        }

        public ExecutorDto GetExecutorById(int executorId)
        {
            throw new NotImplementedException();
        }
    }
}
