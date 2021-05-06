using System;
using System.Globalization;
using System.Linq;
using System.Text;
using EncontreOTelefone.Enums;

// Link do problema no DojoPuzzles: https://dojopuzzles.com/problems/buracos-nas-letras/

namespace BuracoNasLetras
{
    class Program
    {
        static void Main(string[] args)
        {
            string frase = "";
            do
            {
                Console.Clear();
                Console.WriteLine("Digite uma frase qualquer para saber a quantidade de buracos nela! Máximo de 100 caracteres.");
                frase = Console.ReadLine();

                if (frase.Length > 100)
                {
                    Console.WriteLine("O limite da frase é de 100 caracteres.");
                    Console.ReadLine();
                }

            } while (frase.Length > 100);

            int retorno = ContarBuracos(RemoverAcentuacao(frase));

            Console.WriteLine("Quantidade de buracos na frase: ");
            Console.WriteLine(retorno);
        }

        public static int ContarBuracos(string text)
        {
            int saida = 0;
            CaracteresEnum ce;
            // Laço de repetição "for" para passar por todos os caracteres da frase
            for (int i = 0; i < text.Length; i++)
            {
                // Não fazer a contagem de buracos caso for um espaço vazio
                if (text[i].ToString() != " ")
                {
                    // Conversão de String para Enum: 1° parametro o tipo do enum, o 2° o caracter que será convertido, 
                    // o 3° caso seja necessário ignorar ou não caracteres maiúsculas e minúsculas
                    ce = (CaracteresEnum)Enum.Parse(typeof(CaracteresEnum), text[i].ToString());

                    // Conversão de enum para int
                    int num = (int)ce;

                    // Soma o número convertido à saida
                    saida += num;
                }
            }

            return saida;
        }

        public static string RemoverAcentuacao(string text)
        {
            // Essa expressão em LINQ remove as acentuações (consideradas como "NonSpacingMark") do texto e substitui pelas letras base (sem acentuação)
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
    }
}
