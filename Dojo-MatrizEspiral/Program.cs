using System;

namespace Dojo_MatrizEspiral
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine($"=======================");
            Console.WriteLine($"== Matriz em espiral ==");
            Console.WriteLine($"=======================");
            Console.WriteLine($"");
            Console.WriteLine($"Bem vindo(a)!");
            Console.WriteLine($"");

            
            Console.Write("Digite o número de linhas: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Digite o número de colunas: ");
            int m = int.Parse(Console.ReadLine());
            
            int[,] espiral = new int[n,m];
            int row = 0;
            int col = 0;
            string direcao = "right";
            int tamanhoMax = n * m;

            for (int i = 1; i <= tamanhoMax; i++)
            {
                if (direcao == "right" && (col > m - 1 || espiral[row, col] != 0))
                {
                    direcao = "down";
                    col--;
                    row++;
                }
                if (direcao == "down" && (row > n - 1 || espiral[row, col] != 0))
                {
                    direcao = "left";
                    row--;
                    col--;
                }
                if (direcao == "left" && (col < 0 || espiral[row, col] != 0))
                {
                    direcao = "up";
                    col++;
                    row--;
                }

                if (direcao == "up" && row < 0 || espiral[row, col] != 0)
                {
                    direcao = "right";
                    row++;
                    col++;
                }

                espiral[row, col] = i;

                if (direcao == "right")
                {
                    col++;
                }
                if (direcao == "down")
                {
                    row++;
                }
                if (direcao == "left")
                {
                    col--;
                }
                if (direcao == "up")
                {
                    row--;
                }
            }

            //Saída do resultado em tela
            for (int r = 0; r < n; r++)
            {
                for (int c = 0; c < m ; c++)
                {
                    Console.Write("{0,4}", espiral[r,c]);
                }
                Console.WriteLine();

            }
            Console.WriteLine($"Pressione qualquer tecla para finalizar!");
            
            Console.ReadLine();
        }
    }
}
