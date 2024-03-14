using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IOrderRepo
    {
        ICollection<Order> GetOrders();
        ICollection<OrderDetail> GetOrderDetails();
        ICollection<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        Order CreateOrder (Order order);
        OrderDetail CreateOrderDetail(OrderDetail orderDetail);
        Order GetOrderById (int orderId);
        OrderDetail GetOrderDetailById (int orderDetailId);
        Order UpdateOrder(Order order);
        OrderDetail UpdateOrderDetail(OrderDetail orderDetail);
        /// <summary>
        /// Deletes Order and all his OrderDetails
        /// </summary>
        /// <param name="id">Id of Order to delete</param>
        /// <returns>true, if successful delete, false, if there is no Order</returns>
        bool DeleteOrder(int orderId);
        bool DeleteOrderDetails(int orderDetailId);
        Order UpdateOrderStatus(int orderId, string status);
        Order SubmitOrder(int orderId);
        ICollection<Order> GetOrdersForCustomerId(int customerId);
        ICollection<Order> GetOrdersForExecutorId(int executorId);
    }
}
