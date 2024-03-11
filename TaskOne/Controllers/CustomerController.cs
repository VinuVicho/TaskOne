using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Entities;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : Controller
    {

        [HttpGet, Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = customerService.GetCustomers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customers);
        }
    }
}
