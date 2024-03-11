using AutoMapper;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class ExecutorService(IExecutorRepo executorRepo, IMapper mapper) : IExecutorService
    {

    }
}
