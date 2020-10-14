using System;
using System.Collections;

namespace intelitraider3
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean cloop = true;

            while (cloop)

            {


                ArrayList entradas = new ArrayList();

                entradas.Add("pedra");
                entradas.Add("papel");
                entradas.Add("tesoura");

                string escolha;
                Console.WriteLine("pedra papel Ou tesoura?");
                escolha = Console.ReadLine();

                string Jokenpo = Sortearjokenpo(entradas);
                Console.WriteLine(Jokenpo);

                Console.WriteLine("maquina" + Jokenpo);

                if (escolha == "Pedra" && Jokenpo == "papel")
                {
                    Console.WriteLine("Voce Perdeu!");
                }
                else if (escolha == "pedra" && Jokenpo == "tesoura")
                {
                    Console.WriteLine("Você Ganhou : D");
                }
                else if (escolha == "papel" && Jokenpo == "pedra")
                {
                    Console.WriteLine("Você Ganhou : D");
                }
                else if (escolha == "papel" && Jokenpo == "tesoura")
                {
                    Console.WriteLine("Voce Perdeu!");
                }
                else if (escolha == "tesoura" && Jokenpo == "pedra")
                {
                    Console.WriteLine("\nVoce Perdeu!");
                }
                else if (escolha == "tesoura" && Jokenpo == "papel")
                {
                    Console.WriteLine("\nVocê Ganhou : D");

                }
                else if (escolha == "tesoura" && Jokenpo == "tesoura")
                {
                    Console.WriteLine("\nEmpate");

                }
                else if (escolha == "pedra" && Jokenpo == "pedra")
                {
                    Console.WriteLine("\nEmpate");

                }
                else if (escolha == "papel" && Jokenpo == "papel")
                {
                    Console.WriteLine("\nEmpate");

                }
                string Sortearjokenpo(ArrayList entradas)
                {
                    Random random = new Random();
                    int opcao = random.Next(0, entradas.Count);
                    return entradas[opcao].ToString();
                }


            }
        }
    }
}



