using System;

namespace Jokenpo
{
   public class Program
    {
        //https://dojopuzzles.com/problems/jokenpo/
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao Jokenpo");
            Console.WriteLine("Pressione enter para começar");
            Console.ReadLine();
            Console.WriteLine("Jogado 1 Por Favor escolha entre Pedra, Papel e Tesoura, ");
            Console.WriteLine("e entao digite abaixo sua escolha");
            var player1 = Console.ReadLine();
            Console.WriteLine("Jogado 2 Por Favor escolha entre Pedra, Papel e Tesoura, ");
            Console.WriteLine("e entao digite abaixo sua escolha");
            var player2 = Console.ReadLine();
            Comparar comparar = new Comparar();
            var x = player1.ToLower();
            var y = player2.ToLower();
            comparar.CompararJogadas(x, y);

        }
    }
}
