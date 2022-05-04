using System;
using System.Linq;

namespace Teste.Models
{
    public class EstatisticaModel
    {
        int[] numeros;
        string[] transicao;
        string entrada;
        float media, soma;

        public void Estatistica()
        {

            entrada = Console.ReadLine();

            // 1 modo:
            // C# puro e cru.

            #region Preparação

            // Os números que foram inseridos estão inicialmente em formato de string.
            // Para que seja mais fácil e mais correto de manipulá-los, é necessário transformar eles em um array do tipo int.
            transicao = entrada.Split(";");
            numeros = Array.ConvertAll(transicao, int.Parse);
            for (var i = 0; i < numeros.Length; i++)
            { Console.WriteLine($"{numeros[i]}"); }

            #endregion

            #region Maior número

            // Primeiro estabelecemos uma variável chamada "maior". 
            int maior = 0;

            // Depois usamos um loop que vai verificar se o valor de "maior" é inferior ao valor do índice pelo qual o loop está passando.
            for (var i = 0; i < numeros.Length; i++)
            {
                // Caso o valor do índice atual seja maior que o valor da variável ele substitui o valor da váriavel pelo valor do índice.
                if (maior < numeros[i])
                {
                    maior = numeros[i];
                }
            }

            #endregion

            #region Menor número
            // Menor número

            int menor = 0;
            for (var i = 0; i < numeros.Length; i++)
            {
                if (menor > numeros[i])
                {
                    menor = numeros[i];
                }
            }
            #endregion


            // Média
            foreach (int n in numeros)
            {
                soma += n;
            }
            media = soma / numeros.Length;

            // Quantidade de números no array
            int qtd;
            qtd = numeros.Length;

            Console.WriteLine($"Número de elementos: {qtd}");
            Console.WriteLine($"Maior valor: {maior}");
            Console.WriteLine($"Menor valor: {menor}");
            Console.WriteLine($"Valor médio: {media}");



            // 2 modo:
            // Uma opção que utiliza menos linhas, porém é necessário usar LINQ.

            // numeros = entrada.Split(";").Select(n => Convert.ToInt32(n)).ToArray();
            // for (var i = 0; i < numeros.Length; i++)
            // { Console.WriteLine($"{numeros[i]}"); }

            // qtd = numeros.Length;
            // maior = numeros.Max();
            // menor = numeros.Min();
            // media = Queryable.Average(numeros.AsQueryable());

            // Console.WriteLine($"Número de elementos: {qtd}");
            // Console.WriteLine($"Maior valor: {maior}");
            // Console.WriteLine($"Menor valor: {menor}");
            // Console.WriteLine($"Valor médio: {media}");
        }
    }
}