using System;
using System.Collections.Generic;

namespace Dojo_FatoresPrimos
{
    public static class Program
    {
        const int MAX_SIZE = 15000;

        static void Main(string[] args)
        {
            List<int> valores = new List<int>();
            Console.Clear();
            Console.WriteLine($"===============================");
            Console.WriteLine($"== Geração de Fatores Primos ==");
            Console.WriteLine($"===============================");
            Console.WriteLine($"");
            Console.WriteLine($"Bem vindo(a)!");
            Console.WriteLine($"");

            Console.Write($"Insira seu número: ");
            int numero = int.Parse(Console.ReadLine());
            int[] arrResultado = new int[MAX_SIZE];
            int contador = GetFatoresPrimos(numero, out arrResultado);
            
            for (int i = 0; i < contador; i++)
            {
                valores.Add(arrResultado[i]);
            }

            Console.Write($"Fatores primos desse número: --");
            foreach (var item in valores)
            {
                Console.Write($" {item} -");
            }
            Console.Write($"-");
        }

        static bool IsNumeroPrimo(int numero)
        {
            bool isPrimo = true;
            int fator = numero / 2;
            int i = 0;
            for (i = 2; i <= fator; i++)
            {
                if ((numero % i) == 0) isPrimo = false;
            }
            return isPrimo;
        }

        public static int GetFatoresPrimos(int numero, out int[] arrResultado)
        {
            int posicao = 0;
            int[] vetor = new int[MAX_SIZE];
            arrResultado = new int[MAX_SIZE];
            int i = 0;
            int index = 0;
            for (i = 2; i <= numero; i++)
            {
                if (IsNumeroPrimo(i) == true) vetor[posicao++] = i;
            }
            while (true)
            {
                if (IsNumeroPrimo(numero) == true)
                {
                    arrResultado[index++] = numero;
                    break;
                }
                for (i = posicao - 1; i >= 0; i--)
                {
                    if ((numero % vetor[i]) == 0)
                    {
                        arrResultado[index++] = vetor[i];
                        numero = numero / vetor[i];
                        break;
                    }
                }
            }
            return index;
        }
    }
}
