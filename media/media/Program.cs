using System;

namespace media
{
    class Program
    {
        static void Main(string[] args)
        {
            int total = 0, minimo = int.MaxValue, maximo = int.MinValue;

            Console.WriteLine("Digite os elementos separados por espaço seguido de nova linha:");
            string[] ss = Console.ReadLine().Split(' ');

            foreach( var s in ss )
            {
                int atual = int.Parse(s);
                maximo = System.Math.Max(maximo, atual);
                minimo = System.Math.Min(minimo, atual);
                total += atual;
            }

            double resultado = Convert.ToDouble(total) / Convert.ToDouble(ss.Length);

            Console.WriteLine("Valor mínimo: " + minimo);
            Console.WriteLine("Valor máximo: " + maximo);
            Console.WriteLine("Número de elementos na seqüência: " + ss.Length);
            Console.WriteLine("A média do valor é: " + resultado);
            Console.ReadKey();

        }
    }
}
