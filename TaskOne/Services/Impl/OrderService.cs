using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class OrderService(IOrderRepo orderRepo) : IOrderService
    {
        public ICollection<Order> GetOrders()
        {
            return orderRepo.getOrders();
        }
    }
}
