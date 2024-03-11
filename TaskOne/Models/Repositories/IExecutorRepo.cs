using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IExecutorRepo
    {
        public List<Executor> GetExecutors();
        public Executor GetExecutor(string Email);
        public Executor GetExecutor(int executorId);
        public Executor AddExecutor(Executor executor);
        public Executor UpdateExecutor(Executor executor);
    }
}
