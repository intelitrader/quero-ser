using System;

namespace media
{
    class Program
    {
        static void Main(string[] args)
        {
            double valores = 6 + 70 + 3 + 9;

            double divisor = 4;
            double resultado = valores/divisor;

            Console.WriteLine("A média do valor é: " + resultado);
            Console.ReadKey();

        }
    }
}
