using System;
using System.Threading;

namespace Desafio_1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            /*
            FEITO POR LUIS FERNANDO DE MESQUITA PEREIRA
            DESAFIO DOJO CAIXA ELETRÔNCIO
            */
            string continuar = "S";
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            while(continuar.Equals("S")){
                Console.Clear();
                Console.WriteLine("=== CAIXA ELETRÔNICO ==== \n");
                Console.Write("R$ ");
                int valor = Int32.Parse(Console.ReadLine());
                Console.WriteLine("espere um momento...");
                Thread.Sleep(2000);
                int nota100 = valor/100;
                valor = valor - nota100 * 100;
                int nota50 =  valor/50;
                valor = valor - nota50 * 50;
                int nota20 = valor/20;
                valor = valor - nota20 * 20;
                int nota10 = valor/10;
                valor = valor - nota10 * 10;

                Console.Write($"{nota100} notas de R$100,00 \n");
                Console.Write($"{nota50} notas de R$50,00 \n");
                Console.Write($"{nota20} notas de R$20,00 \n");
                Console.Write($"{nota10} notas de R$10,00 \n");
                Console.WriteLine("Valor restante R$"+valor+",00 \n\n");

                Console.Write("Deseja continuar (S/N)?");
                continuar = Console.ReadLine().ToUpper();
            }
            Console.ResetColor();
        }
    }
}
