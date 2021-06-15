using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {

            // Desafio reaizado por Fernando V C Araujo

            // laço para exibir numeros de 1 a 100
            for(int f=1; f <= 100; f++){
                
                string valores = "";
                
                // Se é divisivel por 3, exibe Fizz
                if (f % 3 == 0) valores = "Fizz";

                // Se é divisivel por 5, exibe Fizz
                // Se é divisivel por 3 e 5, exibe FizzBuzz
                if (f % 5 == 0) valores = valores + "Buzz";
                
                // Mostra os algarismos que não são divisiveis por 3 e/ou 5
                if (valores.Length == 0)
                valores = f.ToString();

                // Escreve os valores no console
                Console.WriteLine(valores);
            }

        }
    }
}
