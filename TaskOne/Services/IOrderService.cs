using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface IOrderService
    {
        public ICollection<OrderDto> GetOrders();
        public OrderDto GetOrder(int id);
        public OrderDto UpdateOrder(OrderDto orderDto);
        public OrderDto CreateOrder(OrderDto orderDto);
        public void DeleteOrder(int id);
    }
}
