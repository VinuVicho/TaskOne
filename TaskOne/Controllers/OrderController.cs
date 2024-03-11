using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Entities;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController(IOrderService orderService) : Controller
    {

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Order>))]
        public IActionResult GetOrders()
        {
            var orders = orderService.GetOrders();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(orders);
        }
    }
}
