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

        public OrderFullyDto GetOrder(int orderId)
        {
            var order = orderRepo.GetOrderById(orderId);
            return order == null
                ? throw new NotFoundException("Order was not found with id: " + orderId)
                : mapper.Map<OrderFullyDto>(order);
        }

        public OrderDetailWithServiceDto GetOrderDetail(int orderDetailsId)
        {
            var order = orderRepo.GetOrderDetailById(orderDetailsId);
            return order == null
                ? throw new NotFoundException("OrderDetail was not found with id: " + orderDetailsId)
                : mapper.Map<OrderDetailWithServiceDto>(order);
        }

        public OrderDto UpdateOrder(OrderUpdateDto request)
        {
            var result = orderRepo.UpdateOrder(mapper.Map<Order>(request));
            return mapper.Map<OrderDto>(result);
        }

        public OrderDetailDto UpdateOrderDetail(OrderDetailDto request)         //TODO: make another DTO request to avoid updating order
        {
            var result = orderRepo.UpdateOrderDetail(mapper.Map<OrderDetail>(request));

            UpdateOrderPrice(result.OrderId);

            return mapper.Map<OrderDetailDto>(result);
        }

        public OrderDto CreateOrder(OrderRequest request)
        {
            Order order = new Order
            {
                ExecutorId = request.ExecutorId,
                CustomerId = request.CustomerId,
                Status = "In process",
                TotalAmount = 0,
            };
            var savedOrder = orderRepo.CreateOrder(order);
            var orderDetailsList = request.orderDetails
                .Select(orderDetail => new OrderDetail
                {
                    OrderId = savedOrder.OrderId,
                    Quantity = orderDetail.Quantity,
                    ServiceId = orderDetail.ServiceId,
                })
                .ToList();
            orderRepo.CreateOrderDetails(orderDetailsList);
            UpdateOrderPrice(savedOrder.OrderId);
            return mapper.Map<OrderDto>(savedOrder);
        }

        public void DeleteOrder(int orderId)
        {
            if (!orderRepo.DeleteOrder(orderId))
            {
                throw new NotFoundException("No order with id: " + orderId);
            }
        }

        public void DeleteOrderDetails(int orderDetailId)
        {
            var orderId = orderRepo.GetOrderDetailById(orderDetailId).OrderId;
            if (!orderRepo.DeleteOrderDetails(orderDetailId))
            {
                throw new NotFoundException("No OrderDetails with id: " + orderDetailId);
            }
            UpdateOrderPrice(orderId);
        }

        public List<OrderDetailDto> AddOrderDetails(OrderDetailRequest request)
        {
            if (request.OrderDetails.Count == 0)
            {
                return [];
            }

            var order = orderRepo.GetOrderById(request.OrderId);
            if (order == null || order.Status != "In process")
            {
                throw new BadRequestException("Cannot add details to order with Id: " + request.OrderId);
            }
            int orderId = order.OrderId;
            var orderDetailsList = request.OrderDetails
                .Select(orderDetail => new OrderDetail
                {
                    OrderId = orderId, 
                    Quantity = orderDetail.Quantity, 
                    ServiceId = orderDetail.ServiceId,
                })
                .ToList();
            
            var result = orderRepo.CreateOrderDetails(orderDetailsList);
            UpdateOrderPrice(orderId);
            return result.Select(mapper.Map<OrderDetailDto>).ToList();
        }

        public OrderDto SubmitOrder(int orderId)
        {
            return mapper.Map<OrderDto>(orderRepo.SubmitOrder(orderId));
        }

        public ICollection<OrderDto> GetOrdersForCustomer(int customerId)
        {
            return orderRepo.GetOrdersForCustomerId(customerId).Select(mapper.Map<OrderDto>).ToList();
        }

        public ICollection<OrderDto> GetOrdersForExecutor(int executorId)
        {
            return orderRepo.GetOrdersForExecutorId(executorId).Select(mapper.Map<OrderDto>).ToList();
        }

        public void UpdateOrderPrice(int orderId)
        {
            var order = orderRepo.GetOrderById(orderId);
            if (order != null && order.Status == "In process")
            {
                decimal price = order.OrderDetails
                    .Sum(orderDetail => orderDetail.Quantity * orderDetail.Service.Price);
                orderRepo.SetOrderPrice(orderId, price);
            }
        }
    }
}
