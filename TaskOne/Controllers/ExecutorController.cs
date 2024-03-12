using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExecutorController(IExecutorService executorService): ControllerBase
    {
        [HttpGet("all"), Authorize]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ExecutorDto>))]
        public ActionResult<IEnumerable<ExecutorDto>> GetExecutors()
        {
            var executors = executorService.GetExecutors();
            return Ok(executors);
        }

        //[HttpPut("update"), Authorize(Roles = "Executor")]
        //[ProducesResponseType(200, Type = typeof(ExecutorDto))]
        //[ProducesResponseType(404)]
        //public ActionResult<ExecutorDto> UpdateExecutor(ExecutorDto request)
        //{
        //    var executorDto = executorService.UpdateExecutor(request);
        //    return Ok(executorDto);
        //}


        [HttpGet("{executorId}"), Authorize]
        [ProducesResponseType(200, Type = typeof(ExecutorDto))]
        [ProducesResponseType(404)]
        public ActionResult<ExecutorDto> GetExecutor(int executorId)
        {
            var executor = executorService.GetExecutor(executorId);
            return Ok(executor);
        }
    }
}
