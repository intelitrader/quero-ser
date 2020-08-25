using Microsoft.AspNetCore.Mvc;
using Quero.Ser.Application.Interfaces;

namespace Quero.Ser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        private readonly IFizzBuzzUseCase fizzBuzzUseCase;

        public FizzBuzzController(IFizzBuzzUseCase fizzBuzzUseCase)
        {
            this.fizzBuzzUseCase = fizzBuzzUseCase;
        }

        [HttpGet("{inicio}/{fim}")]
        public IActionResult Get(int inicio, int fim)
        {
            return Ok(fizzBuzzUseCase.Handler(inicio, fim));
        }
    }
}
