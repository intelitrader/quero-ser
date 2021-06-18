/*
Ricardo Ruiz <-> Teste Dojo
  Link: https://dojopuzzles.com/problems/jokenpo/
Problema:
  Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.

  O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.
  As regras são as seguintes:

  > Pedra empata com Pedra e ganha de Tesoura
  > Tesoura empata com Tesoura e ganha de Papel
  > Papel empata com Papel e ganha de Pedra
 */
using System;

namespace Teste_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string vencedor = null;
            Console.WriteLine("« Bem vindo ao \"Juíz de Jokenpo! »\"");
            Console.Write("» Jogador 1: Escolha um entre: Pedra, Papel e Tesoura: ");
            string jogador1 = Console.ReadLine().ToLower();
            Console.Write("» Jogador 2: Escolha um entre: Pedra, Papel e Tesoura: ");
            string jogador2 = Console.ReadLine().ToLower();

            switch (jogador1)
            {
                case "pedra": // Jogador 1 escolheu pedra
                    switch (jogador2)
                    {
                        case "pedra": // Jogador 2 escolheu pedra
                            vencedor = "Empate";
                            break;
                        case "papel": // Jogador 2 escolheu papel
                            vencedor = "Jogador 2 é o vencedor";
                            break;
                        case "tesoura": // Jogador 2 escolheu tesoura
                            vencedor = "Jogador 1 é o vencedor";
                            break;
                        default:
                            vencedor = "Jogador 2 não escolheu direito, logo a vitória vai para o jogador 1";
                            break;
                    }
                    break;
                case "papel": // Jogador 1 escolheu papel
                    switch (jogador2)
                    {
                        case "pedra": // Jogador 2 escolheu pedra
                            vencedor = "Jogador 1 é o vencedor";
                            break;
                        case "papel": // Jogador 2 escolheu papel
                            vencedor = "Empate";
                            break;
                        case "tesoura": // Jogador 2 escolheu tesoura
                            vencedor = "Jogador 2 é o vencedor";
                            break;
                        default:
                            vencedor = "Jogador 2 não escolheu direito, logo a vitória vai para o jogador 1";
                            break;
                    }
                    break;
                case "tesoura": // Jogador 1 escolheu tesoura
                    switch (jogador2)
                    {
                        case "pedra": // Jogador 2 escolheu pedra
                            vencedor = "Jogador 2 é o vencedor";
                            break;
                        case "papel": // Jogador 2 escolheu papel
                            vencedor = "Jogador 1 é o vencedor";
                            break;
                        case "tesoura": // Jogador 2 escolheu tesoura
                            vencedor = "Empate";
                            break;
                        default:
                            vencedor = "Jogador 2 não escolheu corretamente, logo a vitória vai para o jogador 1";
                            break;
                    }
                    break;
                default: // Jogador não escolheu direito
                    vencedor = "Jogador 1 não escolheu corretamente, logo a vitória vai para o jogador 2.";
                    break;
            }

            Console.WriteLine("» Resultado: " +  vencedor); // imprime o resultado na tela

        }
    }
}
