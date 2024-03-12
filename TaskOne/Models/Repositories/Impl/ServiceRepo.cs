using Microsoft.EntityFrameworkCore;
using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class ServiceRepo(AppDbContext context) : IServiceRepo
    {
        public ICollection<Service> GetServices()
        {
            return [.. context.Services];
        }

        public Service GetServiceById(int id)
        {
            return context.Services.Find(id);
        }

        public bool DeleteService(int id)
        {
            var rowsAffected = context.Services.Where(c => c.ServiceId == id).ExecuteDelete();
            return rowsAffected != 0;
        }

        public Service UpdateService(Service service)
        {
            var toUpdate = context.Services.FirstOrDefault(c => c.ServiceId == service.ServiceId);
            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update customer with id: " + service.ServiceId);
            }
            context.Entry(toUpdate).CurrentValues.SetValues(service);
            context.SaveChanges();
            return toUpdate;
        }

        public Service CreateService(Service service)
        {
            var result = context.Add(service).Entity;
            context.SaveChanges();
            return result;
        }
    }
}
