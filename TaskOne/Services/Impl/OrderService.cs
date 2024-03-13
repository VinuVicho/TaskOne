using AutoMapper;
using TaskOne.Exceptions;
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

        public ICollection<OrderDetailDto> GetOrderDetailsByOrderId(int orderId)
        {
            return orderRepo.GetOrderDetailsByOrderId(orderId).Select(mapper.Map<OrderDetailDto>).ToList();
        }

        public OrderDto GetOrder(int orderId)
        {
            var order = orderRepo.GetOrderById(orderId);
            return order == null
                ? throw new NotFoundException("Order was not found with id: " + orderId)
                : mapper.Map<OrderDto>(order);
        }

        public OrderDetailDto GetOrderDetail(int orderDetailsId)
        {
            var order = orderRepo.GetOrderDetailById(orderDetailsId);
            return order == null
                ? throw new NotFoundException("OrderDetail was not found with id: " + orderDetailsId)
                : mapper.Map<OrderDetailDto>(order);
        }

        public OrderDto UpdateOrder(OrderRequest request)
        {
            var result = orderRepo.UpdateOrder(mapper.Map<Order>(request));
            return mapper.Map<OrderDto>(result);
        }

        public OrderDetailDto UpdateOrderDetail(OrderDetailDto request)
        {
            var result = orderRepo.UpdateOrderDetail(mapper.Map<OrderDetail>(request));
            return mapper.Map<OrderDetailDto>(result);
        }

        public OrderDto CreateOrder(OrderRequest request)
        {
            Order order = new Order
            {
                ExecutorId = request.ExecutorId,
                CustomerId = request.CustomerId,
                Status = "In process",
            };
            var savedOrder = orderRepo.CreateOrder(order);
            OrderDetail orderDetail = new OrderDetail
            {
                OrderId = savedOrder.OrderId,
                ServiceId = request.ServiceId,
                Quantity = request.Quantity
            };
            orderRepo.CreateOrderDetail(orderDetail);
            return mapper.Map<OrderDto>(savedOrder);
        }

        public void DeleteOrder(int orderId)
        {
            if (!orderRepo.DeleteOrder(orderId))
            {
                throw new NotFoundException("No order with id: " + orderId);
            }
        }

        public void DeleteOrderDetails(int orderDetailsId)
        {
            if (!orderRepo.DeleteOrderDetails(orderDetailsId))
            {
                throw new NotFoundException("No orderDetails with id: " + orderDetailsId);
            }
        }

        //public OrderDto ChangeOrderStatus(int orderId, string status)
        //{
        //    return mapper.Map<OrderDto>(orderRepo.UpdateOrderStatus(orderId, status));
        //}

        public OrderDetailDto AddOrderDetail(NewOrderDetailsRequest request)
        {
            var result = orderRepo.CreateOrderDetail(mapper.Map<OrderDetail>(request));
            return mapper.Map<OrderDetailDto>(result);
        }

        public OrderDto SubmitOrder(int orderId)
        {
            return mapper.Map<OrderDto>(orderRepo.UpdateOrderStatus(orderId, "Submitted"));
        }
    }
}
