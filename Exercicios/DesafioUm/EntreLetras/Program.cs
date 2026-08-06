using System;

namespace EntreLetras
{
    class Program
    {
        static void Main(string[] args)
        {
            //Recendo a resposta do usuário
            Console.WriteLine("Informe duas letras quaisquer do alfabeto em ordem alfabética!");
            string[] resposta = Console.ReadLine().ToLower().Split(new char[]{',', '-', ' '});

            //Salvando em um array todos os resultados contidos do alfabeto
            string[] alfabeto = new string[]{
                "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
            };

            //Converindo se os dados obtidos da resposta estão dentro do alfabeto
            if(Array.IndexOf(alfabeto, resposta[0]) < 0 || Array.IndexOf(alfabeto, resposta[1]) < 0){
                Console.WriteLine("\nCaracter informado não está dentro do alfabeto, confira os dados informados!");
            }

            //Verificando se a mesma está em ordem alfabetica
            else if(Array.IndexOf(alfabeto, resposta[0]) > Array.IndexOf(alfabeto, resposta[1])){
                Console.WriteLine("\nAs letras informadas não estão em ordem alfabética!");
            }

            //Verificando se os caracteres informados não são o mesmo
            else if(resposta[0] == resposta[1]){
                Console.WriteLine("\nAs letras informadas devem ser diferentes umas das outras!");
            }

            else{
                //Verificando a diferença de elementos entre uma letra e a outra
                int letraUm = Array.IndexOf(alfabeto, resposta[0]);

                int letraDois = Array.IndexOf(alfabeto, resposta[1]);

                //Calculando a distância das duas letras
                int resultado = (letraDois - letraUm) - 1; //Coloca-se '-1' para desconsiderar a posição da 2º letra informada

                //Retornando o resultado calculado
                Console.WriteLine($"\nA quantidade de letras entre '{resposta[0].ToUpper()}' e '{resposta[1].ToUpper()}' é de : {resultado} letras!");
            }
        }
    }
}
