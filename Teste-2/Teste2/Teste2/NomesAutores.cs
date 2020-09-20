using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste2
{
    class NomesAutores
    {
        public void TratarNomes()
        {
            Console.Title = "Nomes de Autores de Obras Bibliográficas";
            string nomeCompleto;
            string mostrarNome = string.Empty;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nomes de Autores de Obras Bibliográficas");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Digite seu nome completo: ");
            nomeCompleto = Console.ReadLine();

            var nomeCompquebr = nomeCompleto.Split(' ');
            string primeiraPosicao = nomeCompquebr[0].Substring(0, 1).ToUpper() +
                nomeCompquebr[0].Substring(1);

            for (int i = 1; i < nomeCompquebr.Length; i++)
            {
                switch (nomeCompquebr[i].ToUpper())
                {
                    case "DA":
                        if (VerificaPosicaoIgual1(i))
                        {
                            primeiraPosicao += " da";
                        }
                        else
                        {
                            mostrarNome += " " + nomeCompquebr[i];
                        }
                        break;

                    case "DAS":
                        if (VerificaPosicaoIgual1(i))
                        {
                            primeiraPosicao += " das";
                        }
                        else
                        {
                            mostrarNome += " " + nomeCompquebr[i];
                        }
                        break;

                    case "DO":
                        if (VerificaPosicaoIgual1(i))
                        {
                            primeiraPosicao += " do";
                        }
                        else
                        {
                            mostrarNome += " " + nomeCompquebr[i];
                        }
                        break;

                    case "DOS":
                        if (VerificaPosicaoIgual1(i))
                        {
                            primeiraPosicao += " dos";
                        }
                        else
                        {
                            mostrarNome += " " + nomeCompquebr[i];
                        }
                        break;

                    case "DE":
                        if (VerificaPosicaoIgual1(i))
                        {
                            primeiraPosicao += " de";
                        }
                        else
                        {
                            mostrarNome += " " + nomeCompquebr[i];
                        }
                        break;

                    default:
                        mostrarNome += " " + nomeCompquebr[i].ToUpper();
                        break;
                }

            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Nome do autor: " + mostrarNome + ", " + primeiraPosicao + "\n");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Pressione qualquer tecla para sair");
            Console.ReadKey();
        }
        public static bool VerificaPosicaoIgual1(int posicao)
        {
            return posicao == 1;
        }

    }
}