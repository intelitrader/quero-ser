using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FIZZBUZZ");
            Console.WriteLine("Iremos exibir números de 0 à 100");
            Console.WriteLine("Quando for um número divisível por 3, irá aparecer 'FIZZ'");
            Console.WriteLine("Quando for um número divisível por 5, irá aparecer 'BUZZ'");
            Console.WriteLine("Quando for um número divisível por 3 e 5, irá aparecer 'FIZZBUZZ'");

            //Contagem de 0 a 100
            for(int i = 1; i < 101; i++)
            {
                //Caso seja divisível por 3 e 5
                if(i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("FIZZBUZZ");
                }
                //Caso seja divisível por 3
                else if (i % 3 == 0)
                {
                    Console.WriteLine("FIZZ");
                }
                //Caso seja divisível por 5
                else if (i % 5 == 0)
                {
                    Console.WriteLine("BUZZ");
                }
                //Caso não seja divisível por 3 ou 5
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
