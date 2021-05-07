using System;

namespace Desafio_3
{
    class Program
    {
        static void Main(string[] args)
        {
        Console.Clear();
            /*
        FEITO POR LUIS FERNANDO DE MESQUITA PEREIRA
        DESAFIO DOJO
         Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
         Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
         Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
        */
        Console.Clear();
        for(int i = 1; i < 101; i++){
            if(i % 5 == 0 && i % 3 == 0){
                Console.Write("FizzBuzz |");
            }
            else{
                if(i % 3 == 0){
                    Console.Write("Fizz |");
                }
                else{
                    if(i % 5 == 0){
                        Console.Write("Buzz |");
                    }
                    else{
                        Console.Write(i + " |");
                    }
                }
            }
        }
        }
    }
}
