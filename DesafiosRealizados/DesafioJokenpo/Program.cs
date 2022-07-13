using System;

namespace Jokenpo
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1 Pedra
            // 2 Papel
            // 3 Tesoura
            int playerOne = 0;
            int playerTwo = 0;
            var array = new bool?[3, 3];

            array[0, 1] = false;
            array[0, 2] = true;

            array[1, 0] = true;
            array[1, 2] = false;

            array[2, 0] = false;
            array[2, 1] = true;

            do
            {
                try
                {
                    Console.WriteLine(@" 
Jogo Jokenpo
-----------------------------
| 1 - Pedra                 |
| 2 - Papel                 |
| 3 - Tesoura               |
|===========================|");
                    
                    Console.WriteLine("Jogador 1 digite o número que deseja utilizar: ");
                    playerOne = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Jogador 2 digite o número  que deseja utilizar: ");
                    playerTwo = Int32.Parse(Console.ReadLine());

                    Console.WriteLine();
                    switch (array[playerOne - 1, playerTwo - 1])
                    {
                        case true:
                            Console.WriteLine("Parabéns o número 1 foi o grande vencedor!!");
                            break;
                        case false:
                            Console.WriteLine("Parabéns o jogador número 2 foi o grande vencedor!!");
                            break;
                        default:
                            Console.WriteLine("Infelizmente não houve nenhum vencedor :( Incie uma nova rodada");
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine(@" 
Deseja jogar uma nova partida?
---------------------------- -
| 1 - Sim                     |
| 2 - Não                     |
|===========================|");
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Algo aconteceu de errado! Tente Novamente");
                    Console.WriteLine(@" 
Deseja jogar uma nova partida?
---------------------------- -
| 1 - Sim                     |
| 2 - Não                     |
|===========================|");
                }

            } while (Console.ReadLine() == "1");

        }
    }
}