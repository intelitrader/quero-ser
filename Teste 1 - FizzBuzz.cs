/*
Ricardo Ruiz <-> Teste Dojo
  Link: https://dojopuzzles.com/problems/diamantes/
Problema:
  Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:

  Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
  Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
  Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
*/

using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 1; i <= 100; i++)
            {
                string saida = "";

                if (i % 3 == 0)
                    saida += "Fizz";
                if (i % 5 == 0)
                    saida += "Buzz";
                if (saida == "")
                    saida = i.ToString();

                Console.WriteLine(saida);
            }
        }
    }
}
