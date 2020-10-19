using Microsoft.AspNetCore.Mvc;
using Quero.Ser.Application.Interfaces;
using System.Collections.Generic;

namespace Quero.Ser.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstatisticaSimplesController : ControllerBase
    {
        private readonly IEstatisticaSimplesUseCase estatisticaSimplesUseCase;

        public EstatisticaSimplesController(IEstatisticaSimplesUseCase estatisticaSimplesUseCase)
        {
            this.estatisticaSimplesUseCase = estatisticaSimplesUseCase;
        }

        [HttpPost]
        public IActionResult Get([FromBody] List<int> listaDeInteiros)
        {
            return Ok(estatisticaSimplesUseCase.Handler(listaDeInteiros));
        }
    }
}



