using System;
using System.Globalization;
using System.Text;
using EncontreOTelefone.Enums;

namespace EncontreOTelefone
{
    class Program
    {
        static void Main(string[] args)
        {
            string caracteres = "";

            do
            {
                Console.WriteLine("Digite uma frase de no máximo 30 caracteres.");
                caracteres = Console.ReadLine();

                if (caracteres.Length > 30)
                    Console.WriteLine("O máximo de caracteres são 30");

                // Substitui todos os espaços em branco por hífens;
                caracteres = caracteres.ToUpper().Replace(" ", "-");

            } while (caracteres.Length > 30);

            caracteres = RemoverAcentuacao(caracteres);

            string retorno = VerificarCaracteres(caracteres);

            Console.WriteLine("Sua sequência numérica é: ");
            Console.Write(retorno);
        }

        public static string VerificarCaracteres(string text)
        {
            string saida = "";
            CaracteresEnum ce;

            for (int i = 0; i < text.Length; i++)
            {
                // O caracter atual é diferente de hífen?
                if (text[i].ToString() != "-")
                {
                    // Conversão de String para Enum: 1° parametro o tipo do enum, o 2° o caracter que será convertido, 
                    // o 3° caso seja necessário ignorar ou não caracteres maiusculas e minusculas.
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
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
