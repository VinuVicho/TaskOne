using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class ServiceRepo(AppDbContext context, IOrderRepo orderRepo) : IServiceRepo
    {
        /// <inheritdoc />
        public ICollection<Service> GetServices()
        {
            return [.. context.Services];
        }

        /// <inheritdoc />
        public Service GetServiceById(int id)
        {
            return context.Services.Find(id);
        }

        /// <inheritdoc />
        public HashSet<int> DeleteService(int serviceId)
        {
            var service = context.Services.Find(serviceId);

            if (service == null)
            {
                throw new NotFoundException("There already no Service with Id: " + serviceId);
            }

            var orderIds = new HashSet<int>();
            var orderDetails = context.OrderDetails
                .Where(od => od.ServiceId == serviceId);
            foreach (var od in orderDetails)
            {
                orderIds.Add(od.OrderId);
                context.OrderDetails.Remove(od);
            }

            context.Remove(service);
            context.SaveChanges();
            return orderIds;
        }

        /// <inheritdoc />
        public (Service, HashSet<int>) UpdateService(Service service)
        {
            var toUpdate = context.Services.FirstOrDefault(c => c.ServiceId == service.ServiceId);

            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update service with id: " + service.ServiceId);
            }

            var orderIds = new HashSet<int>();
            if (service.Price != toUpdate.Price)
            {
                var orderDetails = context.OrderDetails
                    .Where(od => od.ServiceId == service.ServiceId);
                foreach (var od in orderDetails)
                {
                    orderIds.Add(od.OrderId);
                }
            }

            context.Entry(toUpdate).CurrentValues.SetValues(service);
            context.SaveChanges();   

            return (toUpdate, orderIds);
        }

        /// <inheritdoc />
        public Service CreateService(Service service)
        {
            var result = context.Add(service).Entity;
            context.SaveChanges();
            return result;
        }
    }
}
