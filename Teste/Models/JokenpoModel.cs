using System;

namespace Teste.Models
{
    public class JokenpoModel
    {
        public string nome1 { get; set; }
        public string nome2 { get; set; }
        public string escolha1 { get; set; }
        public string escolha2 { get; set; }
        public string modojogo { get; set; }
        public int escolharobo { get; set; }


        public void Jokenpo()
        {
            Console.WriteLine("Para começarmos, você deseja jogar com um amigo ou contra o computador?: ");
            Console.Write("(Computador/Amigo): ");
            modojogo = Console.ReadLine().ToLower();

            string reinicia;

            do
            {
                JokenpoModel jogo = new JokenpoModel();
                switch (modojogo)
                {
                    case "computador":
                        {
                            Random rnd = new Random();
                            escolharobo = rnd.Next(1, 3);

                            // 1 = Pedra
                            // 2 = Papel
                            // 3 = Tesoura

                            Console.Clear();
                            Console.WriteLine("Ok, vamos começar!");

                            // System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("Primeiramente qual o seu nome?");
                            Console.Write("Meu nome é: ");
                            nome1 = Console.ReadLine();

                            Console.WriteLine("Certo, agora faça a sua jogada, lembrando que as escolhas são: pedra, papel ou tesoura.");
                            Console.Write($"Eu escolho ");
                            escolha1 = Console.ReadLine().ToLower();

                            Console.WriteLine("");

                            Console.WriteLine("Ok, agora está na hora do nosso super robô chamado Astolfo fazer a sua escolha! Por favor dê a ele alguns segundos para pensar!");
                            System.Threading.Thread.Sleep(3000);

                            Console.WriteLine($"Certo! Ele se decidiu, vamos ao ganhador");
                            System.Threading.Thread.Sleep(3000);

                            Console.WriteLine("");

                            // Pedra
                            if (escolha1 == "pedra" && escolharobo == 2)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu papel!");
                                Console.WriteLine($"Senhoras e senhores! Papel ganha de {escolha1}, portanto o vencedor é Astolfo!!");

                            }
                            else if (escolha1 == "pedra" && escolharobo == 3)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu tesoura!");
                                Console.WriteLine($"Senhoras e senhores! {escolha1} ganha de tesoura, portanto o vencedor é {nome1}!!");
                            }
                            else if (escolha1 == "pedra" && escolharobo == 1)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo também escolheu {escolha1}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }

                            // Papel
                            else if (escolha1 == "papel" && escolharobo == 3)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu tesoura!");
                                Console.WriteLine($"Senhoras e senhores! Tesoura ganha de {escolha1}, portanto o vencedor é Astolfo!!");

                            }
                            else if (escolha1 == "papel" && escolharobo == 1)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu pedra!");
                                Console.WriteLine($"Senhoras e senhores! {escolha1} ganha de pedra, portanto o vencedor é {nome1}!!");
                            }
                            else if (escolha1 == "papel" && escolharobo == 2)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo também escolheu {escolha1}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }

                            // Tesoura
                            else if (escolha1 == "tesoura" && escolharobo == 1)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu pedra!");
                                Console.WriteLine($"Senhoras e senhores! Pedra ganha de {escolha1}, portanto o vencedor é Astolfo!!");

                            }
                            else if (escolha1 == "tesoura" && escolharobo == 2)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo escolheu papel!");
                                Console.WriteLine($"Senhoras e senhores! {escolha1} ganha de papel, portanto o vencedor é {nome1}!!");
                            }
                            else if (escolha1 == "tesoura" && escolharobo == 3)
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto Astolfo também escolheu {escolha1}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }

                            else
                            {
                                Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            }
                        }
                        break;

                    case "amigo":
                        {
                            Console.Clear();
                            Console.WriteLine("Ok, vamos começar!");
                            Console.WriteLine("Primeiramente, qual o nome do jogador 1?");
                            Console.Write("Meu nome é: ");
                            nome1 = Console.ReadLine();

                            Console.WriteLine("E o nome do jogador 2?");
                            Console.Write("Meu nome é: ");
                            nome2 = Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine("Agora, façam as suas jogadas, lembrando que as escolhas são: pedra, papel ou tesoura.");
                            Console.Write($"{nome1}: ");
                            escolha1 = Console.ReadLine().ToLower();

                            Console.Clear();
                            Console.Write($"{nome2}: ");
                            escolha2 = Console.ReadLine().ToLower();
                            Console.Clear();

                            // Pedra
                            if (escolha1 == "pedra" && escolha2 == "papel")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {escolha2} ganha de {escolha1}, portanto o vencedor é {nome2}!!");

                            }
                            else if (escolha1 == "pedra" && escolha2 == "tesoura")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"!!");
                            }
                            else if (escolha1 == "pedra" && escolha2 == "pedra")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} também escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }

                            // Papel

                            else if (escolha1 == "papel" && escolha2 == "papel")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");

                            }
                            else if (escolha1 == "papel" && escolha2 == "tesoura")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {escolha2} ganha de {escolha1}, portanto o vencedor é {nome2}!!");
                            }
                            else if (escolha1 == "papel" && escolha2 == "pedra")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {escolha1} ganha de {escolha2}, portanto o vencedor é {nome1} !!");
                            }

                            // Tesoura

                            else if (escolha1 == "tesoura" && escolha2 == "papel")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {escolha1} ganha de {escolha2}, portanto o vencedor é {nome1}!!");

                            }
                            else if (escolha1 == "tesoura" && escolha2 == "tesoura")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }
                            else if (escolha1 == "tesoura" && escolha2 == "pedra")
                            {
                                Console.WriteLine($"{nome1} escolheu {escolha1} enquanto {nome2} escolheu {escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {escolha2} ganha de {escolha1}, portanto o vencedor é {nome2}!!");
                            }

                            // Inválida
                            else
                            {
                                Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            }
                        }
                        break;
                    default:
                        break;
                }

                Console.WriteLine("Deseja jogar novamente?");
                Console.Write("(Sim/Não): ");

                reinicia = Console.ReadLine().ToLower();
                Console.Clear();

            } while (reinicia == "sim");


        }

    }
}