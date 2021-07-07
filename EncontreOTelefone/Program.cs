using System;
using System.Globalization;
using System.Linq;
using System.Text;
using EncontreOTelefone.Enums;

// Link do problema no DojoPuzzles: https://dojopuzzles.com/problems/encontre-o-telefone/

namespace EncontreOTelefone
{
    class Program
    {
        static void Main(string[] args)
        {
            string caracteres = "";

            // Do While para não deixar passar frases maiores que 30 caracteres
            do
            {
                Console.WriteLine("Digite uma frase de no máximo 30 caracteres.");
                caracteres = Console.ReadLine();

                // Caso ultrapasse limite de caracteres
                if (caracteres.Length > 30)
                    Console.WriteLine("O máximo de caracteres são 30");

                // Substitui todos os espaços em branco por hífens;
                caracteres = caracteres.ToUpper().Replace(" ", "-");

            } while (caracteres.Length > 30);

            // Remove acentuação da frase
            caracteres = RemoverAcentuacao(caracteres);

            // Verifica os caracteres e transforma-os em seus respectivos números
            string retorno = VerificarCaracteres(caracteres);

            Console.WriteLine("Sua sequência numérica é: ");
            Console.Write(retorno);
        }

        public static string VerificarCaracteres(string text)
        {
            string saida = "";
            CaracteresEnum ce;
            
            // Laço de repetição "for" para passar por todos os caracteres da frase
            for (int i = 0; i < text.Length; i++)
            {
                // O caracter atual é diferente de hífen?
                if (text[i].ToString() != "-")
                {
                    // Conversão de String para Enum: 1° parametro o tipo do enum, o 2° o caracter que será convertido, 
                    // o 3° caso seja necessário ignorar ou não caracteres maiúsculas e minúsculas.
                    ce = (CaracteresEnum)Enum.Parse(typeof(CaracteresEnum), text[i].ToString(), true);

                    // Conversão de enum para int
                    int num = (int)ce;

                    // Soma o número convertido à saida
                    saida += num.ToString();
                }
                else
                    saida += "-";
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
