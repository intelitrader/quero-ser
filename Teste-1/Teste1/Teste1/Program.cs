using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste1
{
    class Program
    {
        //Jokenpo
        //Você está resolvendo este problema.
        //Este problema foi utilizado em 1217 Dojo(s).
        //Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.
        //O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.
        //As regras são as seguintes:
        //Pedra empata com Pedra e ganha de Tesoura
        //Tesoura empata com Tesoura e ganha de Papel
        //Papel empata com Papel e ganha de Pedra

        static void Main(string[] args)
        {
            Jokenpo jogo = new Jokenpo();
            jogo.Jogo();
        }
    }
}