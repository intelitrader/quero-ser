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
            //Checando input.
            if(args.Length != 2)
            {
                Console.WriteLine("Modo de usar:");
                Console.WriteLine("mysolution.exe vendas.txt produtos.txt");
                Console.WriteLine("dotnet run vendas.txt produtos.txt");
                return;
            }

            //Iniciando tasks de leitura.
            var s = Task.Run(() => ReadSells(args[0]));
            var p = Task.Run(() => ReadProducts(args[1]));

            //Populando vendas e produtos.
            List<SellModel> sells = s.Result;
            List<ProductModel> products = p.Result;

            //Chamando metodos pra gerar relatorios.
            TransfersReport.Save(sells, products);
            DivergenciesReport.Save(sells, products);
            TotalChannelsReport.Save(sells);

        }

        //Lendo arquivo de vendas e populando lista.
        public static List<SellModel> ReadSells(string sellsPath)
        {
            StreamReader sr = new StreamReader(sellsPath);
            List<SellModel> sells = new ();

            while (!sr.EndOfStream)
            {
                Span<int> line = sr.ReadLine().Split(';').Select(int.Parse).ToArray();
                SellModel sell = new SellModel
                (
                prodCode: (uint)line[0],
                soldQt: line[1],
                status: line[2],
                channel: line[3]
                );
                sells.Add(sell);
            }
            return sells;
        }

        //Lendo arquivo de produtos e populando lista.
        public static List<ProductModel> ReadProducts(string productsPath)
        {
            StreamReader sr = new StreamReader(productsPath);
            List<ProductModel> products = new ();

            while (!sr.EndOfStream)
            {
                Span<int> line = sr.ReadLine().Split(';').Select(int.Parse).ToArray();
                ProductModel product = new ProductModel
                (
                prodCode: (uint)line[0],
                initialQt: line[1],
                minimunQt: line[2]
                );
                products.Add(product);
            }
            return products;
        }
    }
}
