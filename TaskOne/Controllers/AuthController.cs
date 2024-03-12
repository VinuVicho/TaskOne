using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMapper mapper, IAuthService authService): ControllerBase
    {

        [HttpPost("register")]
        [ProducesResponseType(200, Type = typeof(ExecutorDto))]
        public ActionResult<ExecutorDto> Register(ExecutorRequestDto request)
        {
            var executorDto = authService.RegisterExecutor(request);
            return Ok(executorDto);
        }

        [HttpPost("login")]
        [ProducesResponseType(200, Type = typeof(string))]
        [ProducesResponseType(404)]
        public ActionResult<string> Login(ExecutorLoginDto request)
        {
            var executorDto = authService.Login(request);
            return Ok(executorDto);
        }
    }
}
