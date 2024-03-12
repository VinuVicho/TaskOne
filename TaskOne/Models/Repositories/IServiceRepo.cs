using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IServiceRepo
    {
        ICollection<Service> GetServices();
        Service GetServiceById(int id);
        bool DeleteService(int id);
        Service UpdateService(Service service);
        Service CreateService(Service service);
    }
}
