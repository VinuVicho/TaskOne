﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Services;
using TaskOne.Services.Impl;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : ControllerBase
    {

        [HttpGet, Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = orderService.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{orderId:int}"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> GetOrder(int orderId)
        {
            var order = orderService.GetOrder(orderId);
            return Ok(order);
        }


        [HttpGet("{orderId:int}/details"), Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OrderDetailDto>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<OrderDetailDto>> GetOrderDetailsByOrderId(int orderId)
        {
            var order = orderService.GetOrderDetailsByOrderId(orderId);
            return Ok(order);
        }


        [HttpGet("details/{orderDetailId:int}"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDetailDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDetailDto> GetOrderDetail(int orderDetailId)
        {
            var order = orderService.GetOrderDetail(orderDetailId);
            return Ok(order);
        }

        [HttpPost, Authorize]
        [ProducesResponseType(200)]
        public ActionResult CreateOrder(OrderRequest orderRequest)
        {
            var order = orderService.CreateOrder(orderRequest);
            return Ok(order);
        }


        [HttpPost("details"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDetailDto))]
        public ActionResult<OrderDetailDto> AddOrderDetail(NewOrderDetailsRequest request)
        {
            var order = orderService.AddOrderDetail(request);
            return Ok(order);
        }

        [HttpPut("update"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> UpdateOrder(OrderRequest request)
        {
            var customerDto = orderService.UpdateOrder(request);
            return Ok(customerDto);
        }

        [HttpPut("details/update"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDetailDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDetailDto> UpdateOrderDetail(OrderDetailDto request)
        {
            var customerDto = orderService.UpdateOrderDetail(request);
            return Ok(customerDto);
        }

        [HttpDelete("{orderId:int}"), Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteOrder(int orderId)
        {
            orderService.DeleteOrder(orderId);
            return Ok();
        }

        [HttpDelete("details/{orderDetailsId:int}"), Authorize]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteOrderDetails(int orderDetailsId)
        {
            orderService.DeleteOrderDetails(orderDetailsId);
            return Ok();
        }

        [HttpPatch("{orderId:int}"), Authorize]
        [ProducesResponseType(200, Type = typeof(OrderDto))]
        [ProducesResponseType(404)]
        public ActionResult<OrderDto> SubmitOrder(int orderId)
        {
            var response = orderService.SubmitOrder(orderId);
            return Ok(response);
        }
    }
}
