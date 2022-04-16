using System;
using Troco.Services;
using System.Globalization;

namespace Troco.Entities
{
    class Caixa
    {
        public double ValorTotal = 0;
        public double ValorRecebido = 0;
        public double ValorTroco = 0;
        public int n1 = 0;
        public int n5 = 0;
        public int n10 = 0;
        public int n50 = 0;
        public int n100 = 0;
        public int m1 = 0;
        public int m5 = 0;
        public int m10 = 0;
        public int m50 = 0;

        public void GetTroco(double valorTotal, double valorRecebido)
        {
            ValorTroco = valorRecebido - valorTotal;
            ValorTroco = Math.Round(ValorTroco, 2);
            Console.WriteLine("Valor do troco: R$ " + ValorTroco);
            DevolveTroco(ValorTroco);
        }

        public void DevolveTroco(double valorTroco)
        {
            if (valorTroco != 0)
            {

                while (Math.Round(valorTroco, 2) != 0)
                {
                    if (valorTroco >= 100.0)
                    {
                        valorTroco -= 100.0;
                        n100++;
                    }

                    else if (valorTroco >= 50.0)
                    {
                        valorTroco -= 50.0;
                        n50++;
                    }

                    else if (valorTroco >= 10.0)
                    {
                        valorTroco -= 10.0;
                        n10++;
                    }

                    else if (valorTroco >= 5.0)
                    {
                        valorTroco -= 5.0;
                        n5++;
                    }

                    else if (valorTroco >= 1.0)
                    {
                        valorTroco -= 1.0;
                        n1++;
                    }

                    else if (Math.Round(valorTroco, 2) >= 0.50)
                    {
                        valorTroco -= 0.50;
                        m50++;
                    }

                    else if (Math.Round(valorTroco, 2) >= 0.10)
                    {
                        valorTroco -= 0.10;
                        m10++;
                    }

                    else if (Math.Round(valorTroco, 2) >= 0.05)
                    {
                        valorTroco -= 0.05;
                        m5++;
                    }

                    else if (Math.Round(valorTroco, 2) >= 0.01)
                    {
                        valorTroco -= 0.01;
                        m1++;
                    }
                }

                PrintTrocoService print = new PrintTrocoService();
                print.PrintTroco(n100, n50, n10, n5, n1, m50, m10, m5, m1);
            }

            else
            {
                Console.WriteLine("Não é necessário troco");
            }
        }
    }
}
