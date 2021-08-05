using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MySolution.Models;

namespace MySolution
{
    class Program
    {
        public static List<SellModel> sells = new ();
        public static List<SellModel> products = new ();
        static void Main(string[] args)
        {
            string[] argss = new string[]{
                @"C:\Users\dev\Documents\GitHub\quero-ser\Desafio\MySolution\bin\Debug\net5.0\c1_vendas.txt",
                @"C:\Users\dev\Documents\GitHub\quero-ser\Desafio\MySolution\bin\Debug\net5.0\c1_produtos.txt"};
            
            if(argss.Length != 2)
            {
                Console.WriteLine("Modo de usar:");
                Console.WriteLine("mysolution.exe vendas.txt produtos.txt");
                return;
            }

        }
    }
        
}
