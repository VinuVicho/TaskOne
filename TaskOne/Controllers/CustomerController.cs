using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : Controller
    {
        [HttpGet("all"), Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CustomerDto>))]
        public IActionResult GetCustomers()
        {
            var customers = customerService.GetCustomers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customers);
        }

        [HttpGet("{customerId}"), Authorize]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public IActionResult GetCustomer(int customerId)
        {
            var customers = customerService.GetCustomerById(customerId);
            return Ok(customers);
        }

        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        public ActionResult<CustomerDto> Register(CustomerDto request)
        {
            var customerDto = customerService.CreateCustomer(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customerDto);
        }
    }
}
