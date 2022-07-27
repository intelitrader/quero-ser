using System;

namespace Mictorios
{
    class Program
    {
        static void Main(string[] args)
        {
            //Recebendo a quantidade de mictórios no banheiro
            Console.WriteLine("Informe quantos mictórios existem no banheiro");
            string[] mictorios = new string[Int32.Parse(Console.ReadLine())];

            //Recebendo a posições dos mijões
            Console.WriteLine("\nInforme em qual dos mictorios há um mijão");
            string[] posicoes = Console.ReadLine().Split(new char[]{',', '-', ' '});
            Console.WriteLine();

            //Vericiando se não há mictórios em uso
            if(posicoes[0] == "" || posicoes[0] == " " || posicoes[0] == "0"){

                Console.WriteLine("Mictórios livres para uso, seja feliz :)");

            //Caso haja
            }else{

                //Criando array para conversão das posicoes ocupadas em inteiros
                int[] posicoesMijao = new int[posicoes.Length];

                //Percorrendo todo o array de valores informados
                for(int i = 0; i < posicoes.Length; i++){

                    //Convertendo para um array de inteiros
                    posicoesMijao[i] = Int32.Parse(posicoes[i]);
                }

                //Inserindo no array de mictórios indisponíveis e as posições dos mijões
                for(int i = 0; i < posicoes.Length; i++){

                    //Verificando se o primeiro mictório não está em uso
                    if(posicoesMijao[i] - 1 == 0){

                        //Seta no primeiro mictório o mijão
                        mictorios[posicoesMijao[i] - 1] = "mijão aqui";

                        //Seta no próximo mictório como indisponível
                        mictorios[posicoesMijao[i]] = "Indisponível";
                    }

                    //Verificando se o ultimo mictório não está em uso
                    if(posicoesMijao[i] - 1 == mictorios.Length - 1){

                        //Seta no último mictório o mijão
                        mictorios[posicoesMijao[i] - 1] = "mijão aqui";

                        mictorios[posicoesMijao[i] - 2] = "Indisponível";
                    }

                    //Verificar se o mictório não está em uso
                    if(mictorios[posicoesMijao[i] - 1] == null){

                        //Setando o mijão na posição informada
                        mictorios[posicoesMijao[i] - 1] = "mijão aqui";

                        //Verificando se o proximo mictório está liberado
                        if(mictorios[posicoesMijao[i]] == null){

                            //Colocando o mictório como indisponível
                            mictorios[posicoesMijao[i]] = "Indisponível";
                        }

                        //Verificanso se o mijão já está usando o mictório informado
                        if(mictorios[posicoesMijao[i] - 1] == "mijão aqui"){

                            //Colocando o mictório anterior como indisponível
                            mictorios[posicoesMijao[i] - 2] = "Indisponível";
                        }
                    }
                }

                //Veriavél para veficar quantos mijões ainda podem usar o banheiro
                int totalMijoes = 0;

                //Verificando os mictórios disponíveis
                for(int j = 0; j < mictorios.Length; j++){

                    if(mictorios[j] == null || mictorios[j] == ""){

                        mictorios[j] = "Disponível";

                        totalMijoes += 1;
                    }
                }

                //Criando um laço para percorrer os dados dos mictórios
                for(int j = 0; j < mictorios.Length; j++){

                    //Adicionando verificando dos valores para estilização do retorno
                    if(mictorios[j] == "mijão aqui"){

                        Console.ForegroundColor = ConsoleColor.Yellow;

                    }else if(mictorios[j] == "Indisponível"){

                        Console.ForegroundColor = ConsoleColor.Red;
                    }else{

                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.WriteLine($"Mictório {j + 1} : {mictorios[j]}");
                    Console.ResetColor();
                }

                //Mostrandoa a quantidade de mijões disponíveis
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\nA quantidade de mijões que podem usar os mictórios disponíveis é : {totalMijoes}");
                Console.ResetColor();
            }
        }
    }
}
