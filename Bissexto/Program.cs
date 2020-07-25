using System;

namespace Bissexto
{
    class Program
    {
        public static void CalculaAno()
        {


            //onde a informação e passada
            Console.WriteLine("\nInforme o Ano");
            int ano = int.Parse(Console.ReadLine());

            string success = $"\nO Ano {ano} é bissexto";

            //faz o calculo pra ver se o ano e bissexto
            if (ano % 4 == 0 && ano % 100 != 0)
            {
                Console.WriteLine(success);
                CalculaAno();
            }
            else if (ano % 400 == 0)
            {
                Console.WriteLine(success);
                CalculaAno();
            }
            else
            {
                Console.WriteLine($"\nO Ano {ano} não é bissexto");
                CalculaAno();
            }

        }

        static void Main(string[] args)
        {
            Program.CalculaAno();
        }
    }
}
