using System;

namespace Jokenpo
{
    public class Comparar : IJokenpo
    {
        public void RetornoJogador1Venceu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("jogador 1 ganhou");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("jogador 2 perdeu");
            Console.ResetColor();
        }

        public void RetornoJogador2Venceu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("jogador 2 ganhou");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("jogador 1 perdeu");
            Console.ResetColor();
        }

        public void CompararJogadas(string player1, string player2)
        {
            if(player1 == player2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Empate");
                Console.ResetColor();
            }

            if(player1 == "pedra" && player2 == "tesoura" )
            {
                RetornoJogador1Venceu();
            }
            if (player1 == "pedra" && player2 == "papel")
            {
                RetornoJogador2Venceu();
            }
            if (player1 == "papel" && player2 == "tesoura")
            {
                RetornoJogador2Venceu();
            }
            if (player1 == "papel" && player2 == "pedra")
            {
                RetornoJogador1Venceu();
            }
            if (player1 == "tesoura" && player2 == "papel")
            {
                RetornoJogador1Venceu();
            }
            if (player1 == "tesoura" && player2 == "pedra")
            {
                RetornoJogador2Venceu();
            }
        }
    }
}
