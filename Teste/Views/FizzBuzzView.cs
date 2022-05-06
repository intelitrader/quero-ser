using System;
using Teste.Models;

namespace Teste.Views
{
    public class FizzBuzzView
    {
        public void IntroducaoFizzBuzz()
        {
            Console.WriteLine($"Olá, bem-vindo ao FizzBuzz.");
            Console.WriteLine($"Neste teste eu tive que desenvolver uma lógica que exibisse uma lista de 1 a 100, um em cada linha, com as seguintes exceções: \n Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número; \n Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número; \n Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'. \n");
        }
    }
}