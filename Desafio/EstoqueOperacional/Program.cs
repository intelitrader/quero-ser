using EstoqueOperacional.Helpers;
using EstoqueOperacional.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EstoqueOperacional
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Uso: EstoqueOperacional <arq_vendas> <arq_produtos>");
                Console.WriteLine("Exemplo: EstoqueOperacional c1_vendas.txt c1_produtos.txt");
                Console.Write("Pressione uma tecla para terminar o programa.");
                Console.ReadKey();
                return;
            }

            List<Sell> sells = new List<Sell>();
            Task taskSell = Task.Run(() =>
                                  {
                                      using (StreamReader streamReader = new StreamReader(args[0]))
                                          while (!streamReader.EndOfStream)
                                              sells.Add(ParseHelper.ParseToSell(streamReader.ReadLine()));
                                  });
            List<Product> products = new List<Product>();
            Task taskProduct = Task.Run(() =>
                                  {
                                      using (StreamReader streamReader = new StreamReader(args[1]))
                                          while (!streamReader.EndOfStream)
                                          {
                                              Product toProduct = ParseHelper.ParseToProduct(streamReader.ReadLine());
                                              products.Add(toProduct);
                                              PrintHelper.Products.Add(toProduct.Code);
                                          }
                                  });
            Task.WaitAll(taskSell, taskProduct);

            MiscHelper.CalcTotVendas(sells);
            PrintHelper.PrintTransfer(MiscHelper.CreateTransfers(products));
            PrintHelper.PrintDivergences(sells);
            PrintHelper.PrintChannelSales(MiscHelper.TotalChannels);

            Console.Write("Pressione uma tecla para terminar o programa.");
            Console.ReadKey();
        }
    }
}