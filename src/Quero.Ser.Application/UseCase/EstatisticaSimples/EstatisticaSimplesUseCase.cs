using Quero.Ser.Application.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace Quero.Ser.Application.UseCase.EstatisticaSimples
{
    public class EstatisticaSimplesUseCase : IEstatisticaSimplesUseCase
    {
        public EstatisticaSimplesResponse Handler(List<int> listaDeInteiros)
        {
            if (listaDeInteiros == null || !listaDeInteiros.Any())
                return null;

            var response = new EstatisticaSimplesResponse();
            response.Minimo = listaDeInteiros.Min();
            response.Maximo = listaDeInteiros.Max();
            response.Medio = listaDeInteiros.Average();
            response.Quantidade = listaDeInteiros.Count();

            return response;
        }
    }
}
