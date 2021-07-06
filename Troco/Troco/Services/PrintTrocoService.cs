using System;

namespace Troco.Services
{
    class PrintTrocoService
    {
        int qtdeTroco = 0;
       
        public void PrintTroco (int n100, int n50, int n10, int n5, int n1, int m50, int m10, int m5, int m1)
        {
            qtdeTroco = n100 + n50 + n10 + n5 + n1 + m50 + m10 + m5 + m1;

            System.Console.WriteLine("Confira seu troco: ");

            if (qtdeTroco != 0)
            {
                if (n100 != 0)
                {
                    System.Console.WriteLine(n100 + " nota(s) de R$ 100,00");
                }

                if (n50 != 0)
                {
                    System.Console.WriteLine(n50 + " nota(s) de R$ 50,00");
                }

                if (n10 != 0)
                {
                    System.Console.WriteLine(n10 + " nota(s) de R$ 10,00");
                }

                if (n5 != 0)
                {
                    System.Console.WriteLine(n5 + " nota(s) de R$ 5,00");
                }

                if (n1 != 0)
                {
                    System.Console.WriteLine(n1 + " nota(s) de R$ 1,00");
                }

                if (m50 != 0)
                {
                    System.Console.WriteLine(m50 + " moeda(s) de R$ 0,50");
                }

                if (m10 != 0)
                {
                    System.Console.WriteLine(m10 + " moeda(s) de R$ 0,10");
                }

                if (m5 != 0)
                {
                    System.Console.WriteLine(m5 + " moeda(s) de R$ 0,05");
                }

                if (m1 != 0)
                {
                    System.Console.WriteLine(m1 + " moeda(s) de R$ 0,01");
                }

                else
                {
                    Console.WriteLine("Não é necessário troco");
                }
            }
        }
    }
}
