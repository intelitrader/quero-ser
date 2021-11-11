
using System;
using System.Collections.Generic;

namespace caso2
{
    class Program
    {
        static bool valida(string frase, int colunas)
        {
            string[] palavras = frase.Split(" ");

            for (var i = 0; i < palavras.Length; i++)
            {
                if (palavras[i].Length > colunas)
                {
                    return false;
                }
            }

            return true;
        }


        static bool quebraLinha(string frase, int colunas)
        {
            List<string> linhas = new List<string>();

            string espaco = "";

            if (!valida(frase, colunas))
            {
                Console.WriteLine("\nTamanho de coluna invalido! \n\nO tamanho da coluna deve ser maior \nque a quantidade de caracteres da maior palavra na frase\n");
                return false;
            }

            while (frase.Length > 0)
            {
                if (frase.Length <= colunas)
                {
                    linhas.Add(frase);
                    frase = "";

                };

                if (frase.Length > colunas)
                {
                    espaco = frase[colunas].ToString();
                }

                int cont = 0;

                while ((espaco != " ") & (frase != ""))
                {
                    cont++;
                    espaco = frase[colunas - cont].ToString();
                }

                if (frase != "")
                {
                    string aux = frase.Substring(0, colunas - cont);
                    linhas.Add(aux);

                    //frase = frase.Replace(frase.Substring(0, colunas - cont + 1), "");
                    frase = frase.Remove(0, colunas - cont + 1);
                }

            }

            foreach (string element in linhas)
            {
                Console.Write($"{element}\n");
            }

            return true;
        }

        static void Main(string[] args)
        {
            //string frase = "Um pequeno jabuti xereta viu dez cegonhas felizes.";
            //int colunas = 20;
            int colunas = 0;

            Console.WriteLine("DIGITE A FRASE: ");
            string frase = Console.ReadLine();

            Console.WriteLine("\nDIGITE O TAMANHO DE COLUNAS: ");

            try
            {
                colunas = Int32.Parse(Console.ReadLine());
                Console.WriteLine("\n");

                quebraLinha(frase, colunas);

                Console.WriteLine("\nAPERTA QUALQUER TECLA PARA ENCERRAR ");
                Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.WriteLine("\nTAMANHO DAS COLUNAS DEVE CONTER SOMENTE NUMEROS.");
            }

        }
    }
}
