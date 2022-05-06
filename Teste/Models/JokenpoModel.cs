using System;

namespace Teste.Models
{
    public class JokenpoModel
    {
        // Declaração de variáveis
        public string Jogador1 { get; set; }
        public string Escolha1 { get; set; }
        public int Escolha1Int { get; set; }
        public int Escolha2Int { get; set; }
        public string EscolhaAstolfoString { get; set; }
        public string ModoJogo { get; set; }

        public void Jokenpo()
        {

            string reinicia;

            // Estabelecemos um Do While para que seja possível reiniciar caso o jogador queira.
            do
            {
                Console.WriteLine("Para começarmos, você deseja jogar com um amigo ou contra o computador?: ");
                Console.Write("(Computador/Amigo): ");
                ModoJogo = Console.ReadLine().ToLower();

                JokenpoModel jogo = new JokenpoModel();

                switch (ModoJogo)
                {
                    case "computador":
                        {
                            // Declaração de variáveis locais
                            int EscolhaAstolfo;

                            // Cria o objeto Rnd da classe Random e ao usar o método next é feito a atribuição de um número aleátorio a variável EscolhaAstolfo.
                            // É importante observa que como as opções são poucas (1, 2 ou 3) é comum que o número gerado/escolhido aleátoriamente se repita algumas vezes seguidas.
                            // 1 = Pedra
                            // 2 = Papel
                            // 3 = Tesoura
                            Random Rnd = new Random();
                            EscolhaAstolfo = Rnd.Next(1, 3);

                            // Alguns textos e atribuição de valores.
                            #region Textos

                            Console.Clear();

                            Console.WriteLine("Ok, vamos começar!");
                            System.Threading.Thread.Sleep(2000);
                            Console.WriteLine("Primeiramente qual o seu nome?");
                            Console.Write("Meu nome é: ");
                            Jogador1 = Console.ReadLine();

                            Console.WriteLine("Certo, agora faça a sua jogada, lembrando que as escolhas são: pedra, papel ou tesoura.");
                            Console.Write($"Eu escolho ");
                            Escolha1 = Console.ReadLine().ToLower();

                            Console.WriteLine("");

                            Console.WriteLine("Ok, agora está na hora do nosso super robô chamado Astolfo fazer a sua escolha! Por favor dê a ele alguns segundos para pensar!");
                            System.Threading.Thread.Sleep(3000);

                            Console.WriteLine($"Certo! Ele se decidiu, vamos ao ganhador");
                            System.Threading.Thread.Sleep(3000);

                            Console.WriteLine("");

                            #endregion

                            // Converter o valor das variáveis que estão em string para int e vice versa.
                            #region Conversor

                            switch (Escolha1)
                            {
                                case "pedra":
                                    {
                                        Escolha1Int = 1;
                                    }
                                    break;
                                case "papel":
                                    {
                                        Escolha1Int = 2;
                                    }
                                    break;
                                case "tesoura":
                                    {
                                        Escolha1Int = 3; ;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            switch (EscolhaAstolfo)
                            {
                                case 1:
                                    {
                                        EscolhaAstolfoString = "pedra";
                                    }
                                    break;
                                case 2:
                                    {
                                        EscolhaAstolfoString = "papel";
                                    }
                                    break;
                                case 3:
                                    {
                                        EscolhaAstolfoString = "tesoura";
                                    }
                                    break;
                                default:
                                    break;
                            }

                            #endregion

                            // Toda a operação que define o resultado da partida, se há vencedor e quem é o vencedor.
                            #region Jokenpo

                            if (Escolha1Int - EscolhaAstolfo == 1 || Escolha1Int - EscolhaAstolfo == -2)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu {EscolhaAstolfoString}!");
                                Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de {EscolhaAstolfoString}, portanto o vencedor é {Jogador1}!!");

                            }
                            else if (Escolha1Int == EscolhaAstolfo)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo também escolheu {EscolhaAstolfoString}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }
                            else if (Escolha1Int - EscolhaAstolfo == -1 || Escolha1Int - EscolhaAstolfo == 2)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu {EscolhaAstolfoString}!");
                                Console.WriteLine($"Senhoras e senhores! {EscolhaAstolfoString} ganha de {Escolha1}, portanto o vencedor é Astolfo!!");

                            }
                            else
                            {
                                Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            }

                            #endregion

                            // Inicialmente eu havia feito dessa maneira, mas a utilização de tantos if else é algo que me incomoda muito, então fui atrás de um meio de simplificar.
                            // As variáveis Escolha1Int e AstolfoEscolhaString não haviam sido criadas até este momento.
                            #region Jeito Antigo

                            #region Pedra
                            // if (Escolha1 == "pedra" && EscolhaAstolfo == 2)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu papel!");
                            //     Console.WriteLine($"Senhoras e senhores! Papel ganha de {Escolha1}, portanto o vencedor é Astolfo!!");

                            // }
                            // else if (Escolha1 == "pedra" && EscolhaAstolfo == 3)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu tesoura!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de tesoura, portanto o vencedor é {Jogador1}!!");
                            // }
                            // else if (Escolha1 == "pedra" && EscolhaAstolfo == 1)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo também escolheu {Escolha1}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            // }
                            #endregion

                            #region Papel
                            // else if (Escolha1 == "papel" && EscolhaAstolfo == 3)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu tesoura!");
                            //     Console.WriteLine($"Senhoras e senhores! Tesoura ganha de {Escolha1}, portanto o vencedor é Astolfo!!");

                            // }
                            // else if (Escolha1 == "papel" && EscolhaAstolfo == 1)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu pedra!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de pedra, portanto o vencedor é {Jogador1}!!");
                            // }
                            // else if (Escolha1 == "papel" && EscolhaAstolfo == 2)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo também escolheu {Escolha1}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            // }
                            #endregion

                            #region Tesoura
                            // else if (Escolha1 == "tesoura" && EscolhaAstolfo == 1)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu pedra!");
                            //     Console.WriteLine($"Senhoras e senhores! Pedra ganha de {Escolha1}, portanto o vencedor é Astolfo!!");

                            // }
                            // else if (Escolha1 == "tesoura" && EscolhaAstolfo == 2)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo escolheu papel!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de papel, portanto o vencedor é {Jogador1}!!");
                            // }
                            // else if (Escolha1 == "tesoura" && EscolhaAstolfo == 3)
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto Astolfo também escolheu {Escolha1}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            // }

                            #endregion

                            #region Invalido
                            // else
                            // {
                            //     Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            // }
                            #endregion

                            #endregion
                        }
                        break;

                    case "amigo":
                        {
                            // Declaração de variáveis locais
                            string Jogador2;
                            string Escolha2;

                            // Alguns textos e atribuição de valores.
                            #region Textos

                            Console.Clear();
                            Console.WriteLine("Ok, vamos começar!");
                            Console.WriteLine("Primeiramente, qual o nome do jogador 1?");
                            Console.Write("Meu nome é: ");
                            Jogador1 = Console.ReadLine();

                            Console.WriteLine("E o nome do jogador 2?");
                            Console.Write("Meu nome é: ");
                            Jogador2 = Console.ReadLine();

                            Console.Clear();
                            Console.WriteLine("Agora, façam as suas jogadas, lembrando que as escolhas são: pedra, papel ou tesoura.");
                            Console.Write($"{Jogador1}: ");
                            Escolha1 = Console.ReadLine().ToLower();

                            Console.Clear();
                            Console.Write($"{Jogador2}: ");
                            Escolha2 = Console.ReadLine().ToLower();
                            Console.Clear();

                            #endregion

                            // Converter o valor das variáveis que estão em string para int e vice versa.
                            #region Conversor

                            switch (Escolha1)
                            {
                                case "pedra":
                                    {
                                        Escolha1Int = 1;
                                    }
                                    break;
                                case "papel":
                                    {
                                        Escolha1Int = 2;
                                    }
                                    break;
                                case "tesoura":
                                    {
                                        Escolha1Int = 3; ;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            switch (Escolha2)
                            {
                                case "pedra":
                                    {
                                        Escolha2Int = 1;
                                    }
                                    break;
                                case "papel":
                                    {
                                        Escolha2Int = 2;
                                    }
                                    break;
                                case "tesoura":
                                    {
                                        Escolha2Int = 3; ;
                                    }
                                    break;
                                default:
                                    break;
                            }

                            #endregion

                            // Toda a operação que define o resultado da partida, se há vencedor e quem é o vencedor.
                            #region Jokenpo

                            if (Escolha1Int - Escolha2Int == 1 || Escolha1Int - Escolha2Int == -2)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de {Escolha2}, portanto o vencedor é {Jogador1}!!");

                            }
                            else if (Escolha1Int - Escolha2Int == -1 || Escolha1Int - Escolha2Int == 2)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! {Escolha2} ganha de {Escolha1}, portanto o vencedor é {Jogador2}!!");

                            }
                            else if (Escolha1Int == Escolha2Int)
                            {
                                Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} também escolheu {Escolha2}!");
                                Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            }
                            else
                            {
                                Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            }

                            #endregion

                            // Inicialmente eu havia feito dessa maneira, mas a utilização de tantos if else é algo que me incomoda muito, então fui atrás de um meio de simplificar.
                            // A variável Escolha2Int não havia sido criada até este momento.
                            #region Jeito Antigo

                            #region Pedra

                            // if (Escolha1 == "pedra" && Escolha2 == "papel")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha2} ganha de {Escolha1}, portanto o vencedor é {Jogador2}!!");

                            // }
                            // else if (Escolha1 == "pedra" && Escolha2 == "tesoura")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"!!");
                            // }
                            // else if (Escolha1 == "pedra" && Escolha2 == "pedra")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} também escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            // }

                            #endregion

                            #region Papel

                            // else if (Escolha1 == "papel" && Escolha2 == "papel")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");

                            // }
                            // else if (Escolha1 == "papel" && Escolha2 == "tesoura")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha2} ganha de {Escolha1}, portanto o vencedor é {Jogador2}!!");
                            // }
                            // else if (Escolha1 == "papel" && Escolha2 == "pedra")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de {Escolha2}, portanto o vencedor é {Jogador1} !!");
                            // }

                            #endregion

                            #region Tesoura

                            // else if (Escolha1 == "tesoura" && Escolha2 == "papel")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha1} ganha de {Escolha2}, portanto o vencedor é {Jogador1}!!");

                            // }
                            // else if (Escolha1 == "tesoura" && Escolha2 == "tesoura")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! Parece que temos um empate!! Sem vencedores por agora, mas será que haverá uma revanche?");
                            // }
                            // else if (Escolha1 == "tesoura" && Escolha2 == "pedra")
                            // {
                            //     Console.WriteLine($"{Jogador1} escolheu {Escolha1} enquanto {Jogador2} escolheu {Escolha2}!");
                            //     Console.WriteLine($"Senhoras e senhores! {Escolha2} ganha de {Escolha1}, portanto o vencedor é {Jogador2}!!");
                            // }

                            // // Inválida
                            // else
                            // {
                            //     Console.WriteLine($"Escolha inválida, por favor escolham entre uma das três opções!");
                            // }

                            #endregion

                            #endregion
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