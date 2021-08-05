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

            //Inicializando e populando vendas.
            List<SellModel> sells = new ();
			Task populateSellsTask = Task.Run(() => 
            {
                using (StreamReader streamReader = new StreamReader(argss[0]))
		        {
			        while (!streamReader.EndOfStream)
			        {
				    sells.Add(Program.ParseToSell(streamReader.ReadLine()));
			        }
		        }
            }
            );

            //Inicializando e populando produtos.
            List<ProductModel> products = new ();
            Task populateProductsTask = Task.Run(() => 
            {
                using (StreamReader streamReader = new StreamReader(argss[1]))
		        {
			        while (!streamReader.EndOfStream)
			        {
				    products.Add(Program.ParseToProduct(streamReader.ReadLine()));
			        }
		        }
            }
            );
            
            Task.WaitAll(new Task[] {populateSellsTask, populateProductsTask});

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

        //Parsing string para sell.
        static SellModel ParseToSell(string strSell)
        {
            int[] strList = Array.ConvertAll(strSell.Split(';'), int.Parse);

            SellModel sell = new SellModel()
            { 
                Code = strList[0], 
                Quantity = strList[1],
                Status = (StatusModel)strList[2],
                Channel = (ChannelModel)strList[3]
            };

            return sell;
        }
    }
}
