using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Services;
using TaskOne.Services.Impl;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IServiceService service): ControllerBase
    {
        [HttpGet("all")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ServiceDto>))]
        public ActionResult<IEnumerable<ServiceDto>> GetAllServices()
        {
            var result = service.GetServices();
            return Ok(result);
        }


        [HttpGet("{serviceId:int}")]
        [ProducesResponseType(200, Type = typeof(ServiceDto))]
        [ProducesResponseType(404)]
        public ActionResult<ServiceDto> GetService(int serviceId)
        {
            var result = service.GetService(serviceId);
            return Ok(result);
        }

        [HttpPost("create"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200, Type = typeof(ServiceDto))]
        public ActionResult<ServiceDto> CreateService(ServiceDto request)
        {
            var serviceDto = service.CreateService(request);
            return Ok(serviceDto);
        }

        [HttpPut("update"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200, Type = typeof(ServiceDto))]
        [ProducesResponseType(404)]
        public ActionResult<ServiceDto> UpdateService(ServiceDto request)
        {
            var customerDto = service.UpdateService(request);
            return Ok(customerDto);
        }

        [HttpDelete("{serviceId:int}"), Authorize(Roles = "Executor")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult DeleteService(int serviceId)
        {
            service.DeleteService(serviceId);
            return Ok();
        }
    }
}
