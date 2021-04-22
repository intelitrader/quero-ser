using System;

namespace vetores_escalar
{
    class Program
    {
        static void Main(string[] args)
        {  
            /*
                    --PRODUTO ESCALAR DE VETORES--
                https://dojopuzzles.com/problems/produto-escalar-de-vetores/
            */
            int multiplica=0, resultado = 0, somar = 0;
            int tamanhoA, tamanhoB;
            string resposta;

            Console.WriteLine("Digite um nº:");
            tamanhoA = int.Parse(Console.ReadLine());
            tamanhoB = tamanhoA;

            int [] vetorA = new int[tamanhoA];

            int [] vetorB = new int[tamanhoB];

            for(int i = 0; i <=vetorA.Length-1;i++){
                
                    Console.WriteLine($"Adicione {i} valor:");
                    vetorA[i] = int.Parse(Console.ReadLine());


                    Console.WriteLine($"Adicione {i} outro valor:");
                    vetorB[i] = int.Parse(Console.ReadLine());

                    

                    multiplica = vetorA[i] * vetorB[i];

                    somar += multiplica;
                   

                    resultado = resultado + somar;
                    
            }

            Console.ReadKey();


            if(resultado == 0){
                resposta = "Ângulo reto";
            }
            else if (resultado < 0){
                resposta = "Ângulo obtuso";
            }
            else{
                resposta = "Ângulo agudo";
            }
            
            Console.WriteLine("O produto escalar de vetores é: " + resultado +"/"+ resposta);

        }
    }
}
