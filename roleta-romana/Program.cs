using System;
using System.Collections.Generic;

namespace roleta_romana
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                --ROLETA ROMANA--
                https://dojopuzzles.com/problems/roleta-romana/
                número de pessoas : quantidade > 0 
                posição inicial : 1 <= quem começa <= quantidade
                número de passos: de quantas em quantas > 0

            */
            
            
            int pessoas = 5;
            int passo = 2;
            int inicio = 1;

            int count = 1;
            int proximo = inicio + passo;

      

            do{
                Console.WriteLine(proximo.ToString());

                
                proximo = proximo + passo;

                
                if (proximo > pessoas)
                {
                    proximo = proximo - pessoas;
                }

                count++;
            }while(count < pessoas);

        }
    }
}
