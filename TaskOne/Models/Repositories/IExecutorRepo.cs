using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IExecutorRepo
    {
        public List<Executor> GetExecutors();
        public Executor GetExecutor(string Email);
        public Executor AddExecutor(Executor executor);
        public void UpdateExecutor(Executor executor);
    }
}
