using Quero.Ser.Application.UseCase.EstatisticaSimples;
using System.Collections.Generic;

namespace Quero.Ser.Application.Interfaces
{
    public interface IEstatisticaSimplesUseCase
    {
        EstatisticaSimplesResponse Handler(List<int> listaDeInteiros);
    }
}
