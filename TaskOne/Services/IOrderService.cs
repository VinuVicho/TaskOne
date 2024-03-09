using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface IOrderService
    {
        public ICollection<Order> GetOrders();
    }
}
