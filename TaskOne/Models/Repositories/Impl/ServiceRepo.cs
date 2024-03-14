using Microsoft.EntityFrameworkCore;
using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class ServiceRepo(AppDbContext context, IOrderRepo orderRepo) : IServiceRepo
    {
        public ICollection<Service> GetServices()
        {
            return [.. context.Services];
        }

        public Service GetServiceById(int id)
        {
            return context.Services.Find(id);
        }

        public bool DeleteService(int serviceId)
        {
            var service = context.Services.Find(serviceId);

            if (service == null)
            {
                return false;
            }

            var orderDetails = context.OrderDetails
                .Include(od => od.Order)
                .Where(od => od.ServiceId == serviceId);
            foreach (var od in orderDetails)
            {
                var order = od.Order;
                order.TotalAmount -= (od.Quantity * service.Price);
                context.Update(order);
                context.OrderDetails.Remove(od);
            }

            context.Remove(service);
            context.SaveChanges();
            return true;
        }

        public Service UpdateService(Service service)
        {
            var toUpdate = context.Services.FirstOrDefault(c => c.ServiceId == service.ServiceId);

            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update customer with id: " + service.ServiceId);
            }

            if (service.Price != toUpdate.Price)
            {
                var orderDetails = context.OrderDetails
                    .Include(od => od.Order)
                    .Where(od => od.ServiceId == service.ServiceId);
                foreach (var orderDetail in orderDetails)
                {
                    var order = orderDetail.Order;
                    order.TotalAmount += -((toUpdate.Price - service.Price) * orderDetail.Quantity);
                    context.Update(order);
                }
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

        private async void UpdatePrice()
        {

        }
    }
}
