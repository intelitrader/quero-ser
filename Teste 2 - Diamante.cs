/*
Ricardo Ruiz <-> Teste Dojo
  Link: https://dojopuzzles.com/problems/diamantes/
Problema:
  Dado uma letra ('A' a 'Z'), exiba um diamante iniciando em 'A' e tendo a letra fornecida com o ponto mais distante.

  Por exemplo, dado a letra 'E' temos:

      A

     B B

    C   C

   D     D

  E       E

   D     D

    C   C

     B B

      A



  Dado a letra 'C' temos:

    A

   B B

  C   C

   B B

    A
*/

using System;

namespace Teste2
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] alfabeto = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            //Input do usuario
            Console.WriteLine("Digite a ultima letra a ser gerada: ");
            string final = Console.ReadLine().ToUpper();

            while (final == "A")
            {
                Console.WriteLine("Digite uma letra maior que \"a\" no alfabeto: ");
                final = Console.ReadLine().ToUpper();
            }
            int indexFinal = Array.IndexOf(alfabeto, final);
            int espaco = indexFinal + 1;
            int espacoMeio = 1;
            //Gerador do diamante
            Console.WriteLine(new string(' ', espaco) + " " + alfabeto[0]);
            Console.WriteLine();
            for (int i = 0; i < indexFinal; i++)
            {
                Console.WriteLine(new string(' ', espaco) + alfabeto[i + 1] + (new string(' ', espacoMeio)) + alfabeto[i + 1]);
                Console.WriteLine();
                espaco -= 1;
                espacoMeio += 2;
            }

            espaco += 1;
            espacoMeio -= 2;

            for (int i = indexFinal - 2; i > -1; i--)
            {
                espaco += 1;
                espacoMeio -= 2;
                Console.WriteLine(new string(' ', espaco) + alfabeto[i + 1] + (new string(' ', espacoMeio)) + alfabeto[i + 1]);
                Console.WriteLine();
            }
            Console.WriteLine(new string(' ', espaco) + " " + alfabeto[0]);


        }
    }
}
