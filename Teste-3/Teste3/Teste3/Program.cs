using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste3
{
    class Program
    {

        //FizzBuzz
        //Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:
        //Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
        //Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
        //Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.

        static void Main(string[] args)
        {
            BuzzFizz buzzFizz = new BuzzFizz();
            buzzFizz.TratarNumerosDivisiveis();
        }
    }
}
