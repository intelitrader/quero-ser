using System;

namespace Intelitrader.QueroSer.QuizAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            string entradaUsuarioLocomove = string.Empty;

            string entradaUsuarioAlimentacao = string.Empty;

            string entradaUsuarioCostume = string.Empty;

            Console.WriteLine("O animal que você pensou se locomove (corre, anda ou voa) ? ");

            entradaUsuarioLocomove = Console.ReadLine();

            Console.WriteLine("O animal que você pensou se alimenta com raçao ou fruta? ");

            entradaUsuarioAlimentacao = Console.ReadLine();

            Console.WriteLine("O animal que você pensou tem constume de ficar alegre ou quieto? ");

            entradaUsuarioCostume = Console.ReadLine();

            switch (entradaUsuarioAlimentacao)
            {
                case "raçao":
                    if (entradaUsuarioLocomove == "corre" && entradaUsuarioCostume == "alegre") 
                    {
                        Console.WriteLine("O animal é Cachorro");
                    }
                    if (entradaUsuarioLocomove == "corre" && entradaUsuarioCostume == "quieto")
                    {
                        Console.WriteLine("O animal é Gato");
                    }
                    if (entradaUsuarioLocomove == "anda" && entradaUsuarioCostume == "quieto")
                    {
                        Console.WriteLine("O animal é Gato");
                    }
                    Console.WriteLine("");
                    break;
                case "fruta":
                    Console.WriteLine("O voa é Passaro");
                    break;
            }
        }
    }
}
