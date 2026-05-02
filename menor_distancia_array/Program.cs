using System;
namespace menor_distancia_array;

class Program
{
    static void Main(string[] args)
    {
        int[] primeiro_array = { 4, -9, -3, 55, -2, 8, 35, -9, -2, 8 };
        int[] segundo_array = { -5, 3, -4, 29, 7, 9, -73, 5, 1, 5 };

        int[] distancia = new int[primeiro_array.Length * segundo_array.Length];
        int[,] numeros = new int[primeiro_array.Length * segundo_array.Length, 2];

        int index = 0;

        for (int i = 0; i < primeiro_array.Length; i++)
        {
            for (int j = 0; j < segundo_array.Length; j++)
            {
                int value = primeiro_array[i] - segundo_array[j];

                if (value < 0)
                {
                    value = -value;
                }

                distancia[index] = value;
                numeros[index, 0] = primeiro_array[i];
                numeros[index, 1] = segundo_array[j];
                index++;
            }
        }

        int menor = distancia[0];

        foreach (int i in distancia)
        {
            if (i < menor)
            {
                menor = i;
            }
        }

        int posicao = 0;

        for (int i = 0; i < distancia.Length; i++)
        {
            if (distancia[i] == menor)
            {
                posicao = i;
                break;
            }
        }

        for (int x = 0; x < distancia.Length; x++)
        {
            if (x == posicao)
            {
                Console.WriteLine($"A Menor distancia é: {distancia[x]} e os números são o {numeros[x, 0]} do primeiro array e o {numeros[x, 1]} do segundo array");
            }
        }

    }
}
