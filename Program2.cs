using System;

namespace intelitraider2
{
    class Program
    {

        static void Main(string[] args)
        {

            Boolean c = true;

            while (c)

            {
                Console.WriteLine(" ");

                Console.WriteLine("escreva n");





                int n = Convert.ToInt32(Console.ReadLine());

                for(int i = 1; i < n+1; i++)
                {
                    int p = i % 3;
                    int x = i % 5;
                    if (p == 0 && x == 0)
                    {
                        Console.Write(i);
                        Console.WriteLine("fizzBuzz");

                    }
                    else
                    {
                        if (p == 0)
                        {
                            Console.Write(i);
                            Console.WriteLine("fizz");

                        }

                        if (x == 0)
                        {
                            Console.Write(i);
                            Console.WriteLine("buzz");

                        }
                    }
                   

                }

            }




        }
    }
}

    
