using System;

namespace Projetos
{
    class Program
    {
        public static void Apresentacao()
        {
            Console.WriteLine("\nInsira uma frase");
            string linha = Console.ReadLine();
            
            //verifica se alguma informação foi passada
            if (string.IsNullOrEmpty(linha))
            {
                Console.WriteLine("Nenhuma informação foi inserida");
                Apresentacao();
            }
            else
            {
                string frase = string.Empty;

                int count = 0;

                Console.WriteLine();

                foreach (var palavra in linha.Split(' '))
                {
                    string palavraFormatada = palavra + " ";
                    frase += palavraFormatada;

                    if (frase.Length >= 20)
                    {
                        string quebra = linha.Split(' ').GetValue(count).ToString();

                        Console.Write("\n" + quebra + " ");
                        frase = quebra;

                    }

                    else
                    {
                        Console.Write(palavraFormatada);
                    }
                    count++;
                }
            Console.WriteLine();

            }

            Apresentacao();



        }

        static void Main(string[] args)
        //Um pequeno jabuti xereta viu dez cegonhas felizes.
        {
            Program.Apresentacao();
        }
    }
}
