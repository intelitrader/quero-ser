using Intelitrader.Application.DTOs;
using Intelitrader.Domain.Services;

namespace Intelitrader.Application.Queries
{
    public class CalcularOrcamentoQuery
    {
        private readonly DescontoService _descontoService;

        public CalcularOrcamentoQuery(DescontoService descontoService)
        {
            _descontoService = descontoService;
        }

        public decimal Executar(PedidoRequest request)
        {
            return _descontoService.CalcularMelhorPreco(request.LivrosIds);
        }
    }
}