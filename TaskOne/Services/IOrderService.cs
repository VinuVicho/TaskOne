using TaskOne.Models.Dtos;

namespace TaskOne.Services
{
    public interface IOrderService
    {
        ICollection<OrderDto> GetOrders();
        ICollection<OrderDetailDto> GetOrderDetailsByOrderId(int orderId);
        OrderFullyDto GetOrder(int orderId);
        OrderDetailWithServiceDto GetOrderDetail(int orderDetailsId);
        OrderDto UpdateOrder(OrderRequest request);
        OrderDetailDto UpdateOrderDetail(OrderDetailDto request);
        OrderDto CreateOrder(OrderRequest request);
        void DeleteOrder(int orderId);
        void DeleteOrderDetails(int orderDetailsId);
        OrderDetailDto AddOrderDetail(OrderDetailsCreateRequest request);
        OrderDto SubmitOrder(int orderId);
        ICollection<OrderDto> GetOrdersForCustomer(int customerId);
        ICollection<OrderDto> GetOrdersForExecutor(int executorId);
    }
}
