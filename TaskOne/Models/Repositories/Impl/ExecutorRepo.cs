using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class ExecutorRepo(AppDbContext context) : IExecutorRepo
    {
        public List<Executor> GetExecutors()
        {
            return [.. context.Executors];
        }

        public Executor GetExecutor(string Email)
        {
            return context.Executors.FirstOrDefault(e => e.Email == Email);
        }

        public Executor GetExecutor(int executorId)
        {
            throw new NotImplementedException();
        }

        public Executor AddExecutor(Executor executor)
        {
            var result = context.Add(executor).Entity;
            context.SaveChanges();
            return result;
        }

        Executor IExecutorRepo.UpdateExecutor(Executor executor)
        {
            throw new NotImplementedException();
        }

        public void UpdateExecutor(Executor executor)
        {
            throw new NotImplementedException();
        }
    }
}
