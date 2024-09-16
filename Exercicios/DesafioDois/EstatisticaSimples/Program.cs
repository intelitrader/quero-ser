using System;

namespace EstatisticaSimples
{
    class Program
    {
        static void Main(string[] args)
        {
            //Recendo a resposta do usuário
            Console.WriteLine("Informe uma sequencia de de números inteiros a seu critério");
            string[] resposta = Console.ReadLine().Replace(" ", "").Split(',');

            //Criando as variáveis para alocar os resultados
            float mediaTotal = 0;
            int maximoValor = 0;
            int minimoValor = 0;
            int[] valores = new int[resposta.Length];

            //Percorrendo todo o array de valores informados
            for(int i = 0; i < resposta.Length; i++){

                //Convertendo para um array de inteiros
                valores[i] = Int32.Parse(resposta[i]);

                //Somando todos os valores recebidos
                mediaTotal += (valores[i]);
            }

            //Percorrendo um array para verificar as condições
            for(int j = 0; j < valores.Length; j++){

                //Atribuindo o maximo e o minimo valor no começo do array
                if(j == 0){
                    maximoValor = valores[j];

                    minimoValor = valores[j];
                }

                //Verificando se o atual maximo valor é menor que o proximo no indice sucessor do array
                else if(maximoValor < valores[j]){

                    maximoValor = valores[j];
                }

                //Verificando se o atual minimo valor é maior que o proximo no indice sucessor do array
                else if(minimoValor > valores[j]){

                    minimoValor = valores[j];
                }
            }

            //Calculando a media dos valores recebidos
            mediaTotal = mediaTotal / resposta.Length;

            Console.WriteLine($"\nValor mínimo da sequência : {minimoValor}");
            Console.WriteLine($"Valor máximo da sequência : {maximoValor}");
            Console.WriteLine($"A quantidade de elementos na sequência : {valores.Length}");
            Console.WriteLine($"O resultado da média da sequência : {mediaTotal}");
        }
    }
}
