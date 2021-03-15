using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
    class Jokenpo
    {
        public void Jogo()
        {
            string Playerchoose, pc, randomn, enter;
            int n, pcrandom;
            Random rdn = new Random();


            {
                Console.Title = "JOKENPO";
                Console.WriteLine("JOKENPO");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Digite 1 para Pedra, 2 para Papel ou 3 para Tesoura");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                enter = Console.ReadLine();
                n = Convert.ToInt32(enter);

                Playerchoose = Returnchoose(n);
                randomn = rdn.Next(1, 4).ToString();
                pcrandom = Convert.ToInt32(randomn);
                pc = Pcchoose(pcrandom);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Player 1 escolheu " + Playerchoose);
                Console.WriteLine("vs");
                Console.WriteLine("Computador escolheu " + pc);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Pressione qualquer tecla para sair.");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Winner(Playerchoose, pc));

                Console.ReadKey();
                Console.Clear();

            }
        }
        static string PcChoose(int escolhaPC)
        {

            if (escolhaPC == 1)
            {
                return "Pedra";
            }
            else if (escolhaPC == 2)
            {
                return "Papel";
            }
            else if (escolhaPC == 3)
            {
                return "Tesoura";
            }
            else
            {
                return "hmm";
            }
        }

        static string ReturnChoose(int Escolha)
        {
            if (Escolha == 1)
            {
                return "Pedra";
            }
            else if (Escolha == 2)
            {
                return "Papel";
            }
            else if (Escolha == 3)
            {
                return "Tesoura";
            }
            else if (Escolha == 5)
            {
                return " >>Saindo<<";
            }
            else
            {
                return "Não ha essa escolha, tente novamente...";
            }
        }
        static string Winner(string player1, string computer)
        {
            string vencedor = string.Empty;

            if (player1 == computer) { vencedor = "Empatou."; }

            if (player1 == "Pedra")
            {
                if (computer == "Tesoura") { vencedor = "Computador perdeu."; }
                if (computer == "Papel") { vencedor = "Computador venceu."; }
            }

            if (player1 == "Tesoura")
            {
                if (computer == "Pedra") { vencedor = "Computador venceu."; }
                if (computer == "Papel") { vencedor = "Computador venceu."; }
            }

            if (player1 == "Papel")
            {
                if (computer == "Pedra") { vencedor = "Computador perdeu."; }
                if (computer == "Tesoura") { vencedor = "Computador venceu."; }
            }
            return vencedor;
        }
    }
}