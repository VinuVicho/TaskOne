using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskOne.Models.Dtos;
using TaskOne.Models.Entities;
using TaskOne.Services;
using TaskOne.Services.Impl;

namespace TaskOne.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IMapper mapper, IExecutorService executorService): ControllerBase
    {
        [HttpPost("register")]
        public ActionResult<Executor> Register(ExecutorRequestDto request)
        {
            var executorDto = executorService.RegisterExecutor(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(executorDto);
        }

        [HttpPost("login")]
        public ActionResult<Executor> Login(ExecutorLoginDto request)
        {
            var executorDto = executorService.Login(request);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(executorDto);
        }


        [HttpGet]
        public IActionResult Index()
        {
            var executor = new Executor
            {
                Email = "email",
                ExecutorId = 1,
                Name = "Name",
                PasswordHash = "fjenfjn"
            };

            Console.WriteLine(executor.Email);
            var dto = mapper.Map<ExecutorRequestDto>(executor);
            return Ok(dto);
        }
    }
}
