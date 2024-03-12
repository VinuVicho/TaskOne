using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IExecutorRepo
    {
        public List<Executor> GetExecutors();
        public Executor GetExecutorByEmail(string Email);
        public Executor GetExecutorById(int executorId);
        public Executor AddExecutor(Executor executor);
        public Executor UpdateExecutor(Executor executor);
    }
}
