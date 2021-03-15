using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste3
{
    class BuzzFizz
    {
        public void TratarNumerosDivisiveis()
        {
            Console.Title = "FizzBuzz";
            for (int i = 1; i < 101; i++)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (i % 3 == 0 && i % 5 == 0)
                    Console.WriteLine(i + " BuzzFizz");


                else if ((i % 3) == 0)
                    Console.WriteLine(i + " Buzz");


                else if ((i % 5) == 0)
                    Console.WriteLine(i + " Fizz");

                else
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
