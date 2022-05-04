using System;
using Teste.Models;

namespace Teste.Views
{
    public class JokenpoView
    {
        public void IntroducaoJokenpo()
        {
            Console.WriteLine("Olá, bem vindo ao Jokenpo. \n Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem cada um uma dentre três opções: Pedra, Papel ou Tesoura. ");
            Console.WriteLine("");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"As regras são as seguintes: \n Pedra empata com Pedra e ganha de Tesoura \n Tesoura empata com Tesoura e ganha de Papel \n Papel empata com Papel e ganha de Pedra");
            Console.WriteLine("");
        }
    }
}


