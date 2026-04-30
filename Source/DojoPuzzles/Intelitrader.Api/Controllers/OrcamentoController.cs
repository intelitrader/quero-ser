using Microsoft.AspNetCore.Mvc;
using Intelitrader.Application.Queries;
using Intelitrader.Application.DTOs;

namespace Intelitrader.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class OrcamentoController : ControllerBase
    {
        private readonly CalcularOrcamentoQuery _query;
        public OrcamentoController(CalcularOrcamentoQuery query)
        {
            _query = query;
        }

        [HttpPost("calcular-desconto")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Calcular([FromBody] PedidoRequest request)
        {
            if (request.LivrosIds == null || !request.LivrosIds.Any())
            {
                return BadRequest("A cesta de livros não pode estar vazia.");
            }

            try
            {
                var total = _query.Executar(request);

                return Ok(new
                {
                    valorTotal = total,
                    moeda = "R$",
                    mensagem = "Desconto aplicado com sucesso seguindo a regra de melhor combinação."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao processar o cálculo de alto desempenho.");
            }
        }
    }
}