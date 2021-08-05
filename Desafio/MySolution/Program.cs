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

        //Parsing string para produto.
        static ProductModel ParseToProduct(string strProduct)
        {
            int[] strList = Array.ConvertAll(strProduct.Split(';'), int.Parse);

            ProductModel product = new ProductModel
            (
                code: (int)strList[0], 
                quantity: strList[1],
                minRequiredQuantity: strList[2]
            );

            return product;
        }

    }
}
