using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Services;

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
    }
}
