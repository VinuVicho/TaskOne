using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface IOrderService
    {
        public ICollection<OrderDto> GetOrders();
        public ICollection<OrderDetailDto> GetOrderDetailsByOrderId(int orderId);
        public OrderFullyDto GetOrder(int orderId);
        public OrderDetailWithServiceDto GetOrderDetail(int orderDetailsId);
        public OrderDto UpdateOrder(OrderRequest request);
        public OrderDetailDto UpdateOrderDetail(OrderDetailDto request);
        public OrderDto CreateOrder(OrderRequest request);
        public void DeleteOrder(int orderId);
        public void DeleteOrderDetails(int orderDetailsId);
        //public OrderDto ChangeOrderStatus(int orderId, string status);
        public OrderDetailDto AddOrderDetail(NewOrderDetailsRequest request);
        OrderDto SubmitOrder(int orderId);
    }
}
