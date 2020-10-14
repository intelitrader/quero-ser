using System;

namespace intelitraide
{
    class Program
    {
        static void Main(string[] args)
        {

            Boolean c = true;

            while (c)

            {
                Console.WriteLine(" ");

                Console.WriteLine("escreva um numero");
                int n = Convert.ToInt32(Console.ReadLine());


                for (int m = 2; m <= n; m++)
                {
                    int p = n % m;
                    

                    if (p == 0)
                    {
                        Console.WriteLine(m);
                         n = n / m;
                        m --;
                    }
                }







            }




        }

    }
}




