using AutoMapper;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Models.Repositories;

namespace TaskOne.Services.Impl
{
    public class OrderService(IOrderRepo orderRepo, IMapper mapper) : IOrderService
    {
        public ICollection<OrderDto> GetOrders()
        {
            return orderRepo.GetOrders().Select(mapper.Map<OrderDto>).ToList();
        }

        public OrderDto GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDto UpdateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public OrderDto CreateOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }
    }
}
