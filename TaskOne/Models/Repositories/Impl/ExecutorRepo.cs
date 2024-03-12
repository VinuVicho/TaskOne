using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class ExecutorRepo(AppDbContext context) : IExecutorRepo
    {
        public List<Executor> GetExecutors()
        {
            return [.. context.Executors];
        }

        public Executor GetExecutorByEmail(string Email)
        {
            return context.Executors.FirstOrDefault(e => e.Email == Email);
        }

        public Executor GetExecutorById(int executorId)
        {
            return context.Executors.Find(executorId);
        }

        public Executor AddExecutor(Executor executor)
        {
            var result = context.Add(executor).Entity;
            context.SaveChanges();
            return result;
        }

        public Executor UpdateExecutor(Executor executor)
        {
            var toUpdate = context.Executors.FirstOrDefault(c => c.ExecutorId == executor.ExecutorId);
            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update executor with id: " + executor.ExecutorId);
            }
            context.Entry(toUpdate).CurrentValues.SetValues(executor);
            context.SaveChanges();
            return toUpdate;
        }
    }
}
