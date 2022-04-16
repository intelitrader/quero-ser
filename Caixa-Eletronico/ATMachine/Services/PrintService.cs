using ATMachine.Entities;

namespace ATMachine.Services
{
    class PrintService
    {
        int quantidadeDeNotas = 0;

        public void PrintNotas(int n100, int n50, int n20, int n10)
        {
            quantidadeDeNotas = n100 + n50 + n20 + n10;

            System.Console.WriteLine("Confira suas cédulas: ");

            while (quantidadeDeNotas != 0)
            {
                if (n100 != 0)
                {
                    System.Console.WriteLine(n100 + " nota(s) de R$ 100,00");
                    quantidadeDeNotas -= n100;
                    n100 -= n100;
                }

                else if (n50 != 0)
                {
                    System.Console.WriteLine(n50 + " nota(s) de R$ 50,00");
                    quantidadeDeNotas -= n50;
                    n50 -= n50;
                }

                else if (n20 != 0)
                {
                    System.Console.WriteLine(n20 + " nota(s) de R$ 20,00");
                    quantidadeDeNotas -= n20;
                    n20 -= n20;
                }

                else if (n10 != 0)
                {
                    System.Console.WriteLine(n10 + " nota(s) de R$ 10,00");
                    quantidadeDeNotas -= n10;
                    n10 -= n10;
                }
            }
        }
    }
}
