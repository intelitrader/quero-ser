using System;
using static System.Console;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Bem-vindo ao FizzBuzz\n");

            for ( int i = 1; i <= 100; i++)
            {
                int fizz = i % 3;
                int buzz = i % 5;

                if (fizz == 0 && buzz == 0) WriteLine("FizzBuzz");               
                else if (buzz == 0) WriteLine("Buzz");
                else if (fizz == 0) WriteLine("Fizz");
                else WriteLine(i);             
            }
        }
    }
}
