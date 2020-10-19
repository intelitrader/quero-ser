using Microsoft.AspNetCore.Mvc;
using Quero.Ser.Application.Interfaces;

namespace Quero.Ser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokenpoController : ControllerBase
    {
        private readonly IJokenpoUseCase jokenpoUseCase;

        public JokenpoController(IJokenpoUseCase jokenpoUseCase)
        {
            this.jokenpoUseCase = jokenpoUseCase;

        }

        [HttpGet("{jogadorUm}/{jogadorDois}")]
        public IActionResult Get(string jogadorUm, string jogadorDois)
        {
            return Ok(jokenpoUseCase.Handler(jogadorUm, jogadorDois));
        }
    }
}
