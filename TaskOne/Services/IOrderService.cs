using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface IOrderService
    {
        public ICollection<OrderDto> GetOrders();
        public ICollection<OrderDetailDto> GetOrderDetailsByOrderId(int orderId);
        public OrderFullyDto GetOrder(int orderId);
        public OrderDetailWithServiceDto GetOrderDetail(int orderDetailsId);
        public OrderDto UpdateOrder(OrderUpdateDto request);
        public OrderDetailDto UpdateOrderDetail(OrderDetailDto request);
        public OrderDto CreateOrder(OrderRequest request);
        public void DeleteOrder(int orderId);
        public void DeleteOrderDetails(int orderDetailId);
        public List<OrderDetailDto> AddOrderDetails(OrderDetailRequest request);
        public OrderDto SubmitOrder(int orderId);
        public ICollection<OrderDto> GetOrdersForCustomer(int customerId);
        public ICollection<OrderDto> GetOrdersForExecutor(int executorId);
        public void UpdateOrderPrice(int orderId);
    }
}
