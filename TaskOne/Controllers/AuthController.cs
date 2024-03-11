using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Services;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMapper mapper, IAuthService authService): ControllerBase
    {
        [HttpPost("register")]
        public ActionResult<Executor> Register(ExecutorRequestDto request)
        {
            var executorDto = authService.RegisterExecutor(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(executorDto);
        }

        [HttpPost("login")]
        public ActionResult<Executor> Login(ExecutorLoginDto request)
        {
            var executorDto = authService.Login(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(executorDto);
        }
    }
}
