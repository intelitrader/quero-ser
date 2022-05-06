using System;
using System.Linq;

namespace Teste.Models
{
    public class EstatisticaModel
    {
        // Declaração de variáveis
        public int[] NumerosInt { get; set; }
        public string NumerosString { get; set; }
        public string[] Conversor { get; set; }
        public float Media { get; set; }
        public float Soma { get; set; }

        public void Estatistica()
        {
            NumerosString = Console.ReadLine();

            // 1 modo:
            // Uma opção que precisa de mais linhas para funcionar.
            #region Opcao 1

            // Os números que foram inseridos estão inicialmente em formato de string.
            // Para que seja mais fácil e mais correto de manipulá-los, é necessário transformar eles em um array do tipo int.
            #region Preparacao

            // Primeiro "splita" os números que estão armazenados na string NumerosString e armazena eles em um array.
            // Após isso utiliza o método ConvertAll para converter todos os valores do array de string para dentro de um array de int.
            Conversor = NumerosString.Split(";");
            NumerosInt = Array.ConvertAll(Conversor, int.Parse);

            // Testei para ver se estava funcionando.
            // for (var i = 0; i < NumerosInt.Length; i++)
            // { Console.WriteLine($"{NumerosInt[i]}"); }

            #endregion

            // Encontra o maior número da lista de números.
            #region Maior Numero

            // Primeiro estabelecemos uma variável chamada "maior". 
            int Maior = 0;

            // Depois usamos um loop que vai verificar se o valor de "maior" é menor que o valor do índice pelo qual o loop está passando.
            for (var i = 0; i < NumerosInt.Length; i++)
            {
                // Caso o valor do índice atual seja maior que o valor da variável ele substitui o valor da váriavel pelo valor do índice.
                if (Maior < NumerosInt[i])
                {
                    Maior = NumerosInt[i];
                }
            }

            #endregion

            // Encontra o menor número da lista de números.
            #region Menor Numero

            // Primeiro estabelecemos uma variável chamada "menor". 
            int Menor = 0;

            // Depois usamos um loop que vai verificar se o valor de "menor" é maior ao valor do índice pelo qual o loop está passando.
            for (var i = 0; i < NumerosInt.Length; i++)
            {   
                // Caso o valor do índice atual seja menor que o valor da variável ele substitui o valor da váriavel pelo valor do índice.
                if (Menor > NumerosInt[i])
                {
                    Menor = NumerosInt[i];
                }
            }

            #endregion

            // Calcula a média dos valores recebidos.
            #region Media

            // Um loop que vai passar por cada indice e somar seu valor com o valor adicionado anteriormente.
            foreach (int n in NumerosInt)
            {
                Soma += n;
            }
            Media = Soma / NumerosInt.Length;
            
            #endregion
            
            // Calcula quantos números há dentro do array.
            #region Quantidade de Números
            
            int Qtd;
            Qtd = NumerosInt.Length;

            #endregion

            Console.WriteLine($"Número de elementos: {Qtd}");
            Console.WriteLine($"Maior valor: {Maior}");
            Console.WriteLine($"Menor valor: {Menor}");
            Console.WriteLine($"Valor médio: {Media}");


            #endregion
            
            // 2 modo:
            // Uma opção que utiliza menos linhas, porém é necessário usar LINQ.
            #region Opcao 2

            // NumerosInt = NumerosString.Split(";").Select(n => Convert.ToInt32(n)).ToArray();

            // int qtd = NumerosInt.Length;
            // int maior = NumerosInt.Max();
            // int menor = NumerosInt.Min();
            // double MediaDouble = Queryable.Average(NumerosInt.AsQueryable());

            // Console.WriteLine($"Número de elementos: {qtd}");
            // Console.WriteLine($"Maior valor: {maior}");
            // Console.WriteLine($"Menor valor: {menor}");
            // Console.WriteLine($"Valor médio: {MediaDouble}");

            #endregion
        }
    }
}