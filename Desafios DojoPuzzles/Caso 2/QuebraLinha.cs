

using System;
using System.Collections.Generic;

namespace Caso2
{
    class Program
    {
        //Função para validar o tamanho da coluna em relação as palavras da frase
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

        //Função principal, quebra a frase em linhas
        static bool quebraLinha(string frase, int colunas)
        {
            List<string> linhas = new List<string>();

            string espaco = "";

            //Primeira validação, palavras x coluna
            if (!valida(frase, colunas))
            {
                Console.WriteLine("\nTamanho de coluna invalido! \n\nO tamanho da coluna deve ser maior \nque a quantidade de caracteres da maior palavra na frase\n");
                return false;
            }

            //Retira um pedaço da expressão passada por argumento e insere no vetor
            //O laço de repetição acontece até que essa frase esteja em branco
            while (frase.Length > 0)
            {
                //Importante verificação para a ultima palavra da expressão
                if (frase.Length <= colunas)
                {
                    linhas.Add(frase);
                    frase = "";

                };

                if (frase.Length > colunas)
                {
                    //inicia uma variavel no indice correspondente ao valor da coluna informada
                    espaco = frase[colunas].ToString();
                }

                int cont = 0;

                //Procura o espaço em branco mais próximo a esquerda ao indice indicado nas colunas
                //caso a letra correspondente a esse respectivo indice nao seja vazio(espaço na frase)
                //diminui um no indice até encontrar o espaço
                while ((espaco != " ") & (frase != ""))
                {
                    cont++;
                    espaco = frase[colunas - cont].ToString();
                }

                //caso a frase nao esteja vazia
                //adiciona a parte da frase correspondente a lista criada que conterá todas as linhas formadas
                if (frase != "")
                {
                    string aux = frase.Substring(0, colunas - cont);
                    linhas.Add(aux);

                    //frase = frase.Replace(frase.Substring(0, colunas - cont + 1), "");
                    frase = frase.Remove(0, colunas - cont + 1);
                }

            }

            //Percorre a lista mostrando no console as linhas
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

