using System;

public class Program
{
    /// Desenvolvido um menu na main
    public static void Main(string[] args)
    {
        Console.WriteLine("Seja bem vindo ao FizzBuzz");
        Console.WriteLine(@"
=============================   
|       FizzBuzz!!          |
-----------------------------
| 1- Analisar Divisões      |
| 2- Limpar                 |
| 3- Sair                   |
|===========================|");
/// Definido a função de cada numéro do switch
        int OpçãoMenu = int.Parse(Console.ReadLine());
                switch (OpçãoMenu)
                {
                    case 1:
                        {
                            FizzBuzz();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Obrigado por utilizar o nosso sistema de analise de divisões!!");
                        break;
                    default:
                        break;
                }
    }
    /// Divisões e a palavra que irá aparecer em cada Console
    public static void FizzBuzz()
    {       
        for (int i = 1; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Console.WriteLine("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine("Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Buzz");
            }
            else
            {
                Console.WriteLine(i);
            }
        }
    }
}