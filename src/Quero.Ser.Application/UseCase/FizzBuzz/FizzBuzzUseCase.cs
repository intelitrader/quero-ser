using Quero.Ser.Application.Interfaces;
using System.Collections.Generic;

namespace Quero.Ser.Application.UseCase.FizzBuzz
{
    public class FizzBuzzUseCase : IFizzBuzzUseCase
    {

        public IEnumerable<string> Handler(int inicio, int fim)
        {
            var listaDeRetorno = new List<string>();

            for (var numero = inicio; numero <= fim; numero++)
            {
                if (numero % 3 == 0 && numero % 5 == 0)
                {
                    listaDeRetorno.Add("FizzBUZZ");
                }
                else if (numero % 3 == 0)
                {
                    listaDeRetorno.Add("Fizz");
                }
                else if (numero % 5 == 0)
                {
                    listaDeRetorno.Add("Buzz");
                }
                else
                {
                    listaDeRetorno.Add(numero.ToString());
                }
            }

            return listaDeRetorno;
        }
    }
}
