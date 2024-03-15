using Microsoft.EntityFrameworkCore;
using TaskOne.Exceptions;
using TaskOne.Models.Entities;

namespace TaskOne.Models.Repositories.Impl
{
    public class OrderRepo(AppDbContext context) : IOrderRepo
    {
        public ICollection<Order> GetOrders()
        {
            return [.. context.Orders];
        }

        public ICollection<OrderDetail> GetOrderDetails()
        {
            return [.. context.OrderDetails];
        }

        public ICollection<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return [.. context.OrderDetails.Where(od => od.OrderId == orderId)];
        }

        public ICollection<Order> GetOrdersForCustomerId(int customerId)
        {
            return [.. context.Orders.Where(o => o.CustomerId == customerId)];
        }

        public ICollection<Order> GetOrdersForExecutorId(int executorId)
        {
            return [.. context.Orders.Where(o => o.ExecutorId == executorId)];
        }

        public Order CreateOrder(Order order)
        {
            var oCustomerExists = context.Customers.Any(c => c.CustomerId == order.CustomerId);
            var oExecutorExists = context.Executors.Any(e => e.ExecutorId == order.ExecutorId);
            if (oCustomerExists && oExecutorExists)
            {
                var result = context.Add(order).Entity;
                context.SaveChanges();
                return result;
            }
            throw new BadRequestException("Invalid fields");
        }

        public Order GetOrderById(int id)
        {
            return context.Orders
                .AsNoTracking()
                .Include(o => o.OrderDetails)
                    .ThenInclude(od => od.Service)
                .FirstOrDefault(o => o.OrderId == id);
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return context.OrderDetails
                .AsNoTracking()
                .Include(od => od.Service)
                .FirstOrDefault(od => od.OrderDetailId == id);
        }

        public List<OrderDetail> CreateOrderDetails(List<OrderDetail> orderDetail)
        {
            var result = new List<OrderDetail>();
            foreach (var od in orderDetail)
            {
                var odService = context.Services.FirstOrDefault(s => s.ServiceId == od.ServiceId);
                if (odService != null)
                {
                    result.Add(context.Add(od).Entity);
                }
            }
            context.SaveChanges();
            return result;
        }

        public OrderDetail UpdateOrderDetail(OrderDetail orderDetail)
        {
            var toUpdate = context.OrderDetails
                .FirstOrDefault(od => od.OrderDetailId == orderDetail.OrderDetailId);
            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update OrderDetails with id: " + orderDetail.OrderDetailId);
            }

            context.Entry(toUpdate).CurrentValues.SetValues(orderDetail);
            context.SaveChanges();
            return toUpdate;
        }

        public Order UpdateOrder(Order order)
        {
            var toUpdate = context.Orders
                .FirstOrDefault(o => o.OrderId == order.OrderId);
            if (toUpdate == null)
            {
                throw new NotFoundException("Cannot update order with id: " + order.OrderId);
            }

            var oCustomerExists = context.Customers.Any(c => c.CustomerId == order.CustomerId);
            var oExecutorExists = context.Executors.Any(e => e.ExecutorId == order.ExecutorId);
            if (oCustomerExists && oExecutorExists)
            {
                context.Entry(toUpdate).CurrentValues.SetValues(order);
                context.SaveChanges();
                return toUpdate;
            }
            throw new BadRequestException("Invalid fields");
        }
        public bool DeleteOrder(int id)
        {
            context.OrderDetails.Where(od => od.OrderId == id).ExecuteDelete();
            var rowsAffected = context.Orders.Where(o => o.OrderId == id).ExecuteDelete();
            return rowsAffected != 0;
        }

        public bool DeleteOrderDetails(int orderDetailsId)
        {
            var rowsAffected = context.OrderDetails.Where(od => od.OrderDetailId == orderDetailsId).ExecuteDelete();
            return rowsAffected != 0;
        }

        public Order SubmitOrder(int orderId)
        {
            var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new NotFoundException("No order with id: " + orderId);
            }
            order.Status = "Submitted";
            order.OrderDate = DateTime.Now;
            context.SaveChanges();
            return order;
        }

        public void SetOrderPrice(int orderId, decimal price)
        {
            var order = context.Orders.FirstOrDefault(o => o.OrderId == orderId)!;
            order.TotalAmount = price;
            context.SaveChanges();
        }
    }
}
