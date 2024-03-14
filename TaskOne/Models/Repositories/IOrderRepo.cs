using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories
{
    public interface IOrderRepo
    {
        public ICollection<Order> GetOrders();
        public ICollection<OrderDetail> GetOrderDetails();
        public ICollection<OrderDetail> GetOrderDetailsByOrderId(int orderId);
        public Order CreateOrder (Order order);
        public OrderDetail CreateOrderDetail(OrderDetail orderDetail);
        public List<OrderDetail> CreateOrderDetails(List<OrderDetail> orderDetail);
        public Order GetOrderById (int orderId);
        public OrderDetail GetOrderDetailById (int orderDetailId);
        public Order UpdateOrder(Order order);
        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail);
        /// <summary>
        /// Deletes Order and all his OrderDetails
        /// </summary>
        /// <param name="id">Id of Order to delete</param>
        /// <returns>true, if successful delete, false, if there is no Order</returns>
        public bool DeleteOrder(int orderId);
        public bool DeleteOrderDetails(int orderDetailId);
        public Order UpdateOrderStatus(int orderId, string status);
        public Order SubmitOrder(int orderId);
        public ICollection<Order> GetOrdersForCustomerId(int customerId);
        public ICollection<Order> GetOrdersForExecutorId(int executorId);
    }
}
