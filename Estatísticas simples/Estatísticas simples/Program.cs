using System;
using System.Linq;

namespace Estatísticas_simples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ESTATÍSTICAS SIMPLES");
            Console.WriteLine("Digite uma sequencia de números inteiros separados por vírgulas,");
            Console.WriteLine("Assim responderemos com alguns dados sobre estes números!");

            float Media = 0;

            try
            {
                Console.WriteLine("Digite a sequencia:");
                //Separando os números pela vírgula
                var Numeros = Console.ReadLine().Split(',').Select(i => int.Parse(i));
                //Alocando os números em uma array
                Numeros.ToArray();
                //Passando a soma do valor dos números para a variável média
                foreach (int num in Numeros)
                {
                    Media = Media + num;
                }
                //Calculando a média
                Media = Media / Numeros.Count();
                //Mostrando o valor mínimo
                Console.WriteLine($"Valor Mínimo: {Numeros.Min()}");
                //Mostrando o valor máximo
                Console.WriteLine($"Valor Máximo: {Numeros.Max()}");
                //Mostrando a quantidade de números digitados
                Console.WriteLine($"Número de elementos na sequencia: {Numeros.Count()}");
                //Mostrando a média
                Console.WriteLine($"Média dos números {Media}");
                //Tratamento de erros
            } catch (FormatException)
            {
                Console.WriteLine("Coloque os números INTEIROS seprados por VIRGULA ex: 2, 5, 10, 15, 5");
            }
        }
    }
}
