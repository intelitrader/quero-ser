using System;
using static System.Console;

namespace Jokenpo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Bem-vindos ao Jokenpo\n" +
                "Para acessar o jogo digite 1, para sair digite outra tecla.");
            int jogar = int.Parse(ReadLine());

            if (jogar != 1) WriteLine("Saindo do jogo...");

            while (jogar == 1)
            {
                WriteLine("\nPrimeiro jogador, digite 1 para pedra, 2 para papel e 3 para tesoura!");
                int escolha1 = int.Parse(ReadLine());
                
                
                WriteLine("\nSegundo jogador, digite 1 para pedra, 2 para papel e 3 para tesoura!");
                int escolha2 = int.Parse(ReadLine());



                if (escolha1 == escolha2 && escolha1 > 0 && escolha1 < 4) WriteLine("Empate!");
                else if (escolha1 == 1 && escolha2 == 3) WriteLine("Jogador 1 venceu!!!");
                else if (escolha1 == 3 && escolha2 == 1) WriteLine("Jogador 2 venceu!!!");
                else if (escolha1 == 2 && escolha2 == 1) WriteLine("Jogador 1 venceu!!!");
                else if (escolha1 == 1 && escolha2 == 2) WriteLine("Jogador 2 venceu!!!");
                else if (escolha1 == 3 && escolha2 == 2) WriteLine("Jogador 1 venceu!!!");
                else if (escolha1 == 2 && escolha2 == 3) WriteLine("Jogador 2 venceu!!!");
                else WriteLine("Valor inválido");
                
                WriteLine("\nPara jogar novamente digite 1, para sair digite outra tecla.");
                jogar = int.Parse(ReadLine());
                if (jogar != 1) WriteLine("Saindo do jogo...");
            }
        }
    }
}
