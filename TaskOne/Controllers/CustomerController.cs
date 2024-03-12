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
        public ActionResult<List<CustomerDto>> GetCustomers()
        {
            var customers = customerService.GetCustomers();
            return Ok(customers);
    }

        [HttpGet("{customerId}"), Authorize]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public ActionResult GetCustomer(int customerId)
        {
            var customers = customerService.GetCustomerById(customerId);
            return Ok(customers);
        }

        [HttpPost("create"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        public ActionResult<CustomerDto> CreateCustomer(CustomerDto request)
        {
            var customerDto = customerService.CreateCustomer(request);
            return Ok(customerDto);
        }

        [HttpPut("update"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200, Type = typeof(CustomerDto))]
        [ProducesResponseType(404)]
        public ActionResult<CustomerDto> UpdateCustomer(CustomerDto request)
        {
            var customerDto = customerService.UpdateCustomer(request);
            return Ok(customerDto);
        }

        [HttpDelete("{customerId}"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteCustomer(int customerId)
        {
            customerService.DeleteCustomer(customerId);
            return Ok();
        }
    }
}
