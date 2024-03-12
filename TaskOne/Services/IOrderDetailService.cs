using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;

namespace TaskOne.Services
{
    public interface IOrderDetailService
    {
        public ICollection<OrderDetailDto> GetOrderDetails();
        public void DeleteOrderDetail(int orderDetailId);
        public OrderDetailDto GetOrderDetail(int orderDetailId);
        public OrderDetailDto UpdateOrderDetail(OrderDetailDto orderDetail);
    }
}
