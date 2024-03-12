using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface IExecutorService
    {
        public ICollection<ExecutorDto> GetExecutors();
        public ExecutorDto UpdateExecutor(ExecutorDto executorDto);
        public ExecutorDto GetExecutor(int executorId);
    }
}
