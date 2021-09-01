﻿using System;
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

            //Inicializando e populando produtos.
            List<ProductModel> products = new ();
            Task populateProductsTask = Task.Run(() => 
            {
                using (StreamReader streamReader = new StreamReader(args[1]))
		        {
			        while (!streamReader.EndOfStream)
			        {
				    products.Add(Program.ParseToProduct(streamReader.ReadLine()));
			        }
		        }
            }
            );
            
            //Thread aguardando listas serem populadas.
            Task.WaitAll(new Task[] {populateSellsTask, populateProductsTask});

            //Buscando vendas concluidas.
            IEnumerable<SellModel> qtSold = GetQtSold(sells);

            //Gerando relatorios.
            WriteTransfersReport(products, qtSold);
            WriteDivergencesReport(products, sells);
            WritePerChannelReport(products, qtSold);
        }

        //Lendo arquivo de vendas e populando lista.
        public static List<Sell> ReadSells(string sellPath)
        {
            StreamReader sr = new StreamReader(sellPath);
            List<Sell> sells = new ();

            while (!sr.EndOfStream)
            {
                Span<int> line = sr.ReadLine().Split(';').Select(int.Parse).ToArray();
                Sell sell = new Sell
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

        //Escrevendo arquivo relatorio de divergencias.
        private static void WriteDivergencesReport(List<ProductModel> products, List<SellModel> sells)
        {
            using(StreamWriter streamWriter = new StreamWriter("DIVERGENCIAS.txt"))
            {
                int i = 1;

                foreach(SellModel sell in sells)
                {

                    if(sell.Status == (StatusModel)135)
                    streamWriter.WriteLine($"Linha {i} – Venda cancelada");

                    else if(sell.Status == (StatusModel)190)
                    streamWriter.WriteLine($"Linha {i} – Venda não finalizada");

                    else if(sell.Status == (StatusModel)999)
                    streamWriter.WriteLine($"Linha {i} – Erro desconhecido. Acionar equipe de TI");
                    
                    else if(!products.Select(x => x).Where(x => x.Code == sell.Code).Any())
                    streamWriter.WriteLine($"Linha {i} – Código de Produto não encontrado {sell.Code}");

                    i++;
                }
            }
        }

        //Escrevendo arquivo relatorio de canais.
        private static void WritePerChannelReport(List<ProductModel> products, IEnumerable<SellModel> sold)
        {
            using(StreamWriter streamWriter = new StreamWriter("TOTCANAIS.txt"))
            {
                streamWriter.WriteLine("Quantidades de Vendas por canal\n");
                streamWriter.WriteLine("Canal\t\t\tQtVendas");

                streamWriter.WriteLine("1 - Representantes\t\t{0}",
                GetQtSoldByChannel(ChannelModel.CommercialRepresentative, sold));
                streamWriter.WriteLine("2 - Website\t\t{0}",
                GetQtSoldByChannel(ChannelModel.Website, sold));
                streamWriter.WriteLine("3 - App móvel Android\t{0}",
                GetQtSoldByChannel(ChannelModel.AndroidApp, sold));
                streamWriter.WriteLine("4 - App móvel iPhone\t{0}",
                GetQtSoldByChannel(ChannelModel.IphoneApp, sold));
            }
        }

        //Escrevendo arquivo relatorio de transferencias.
        private static void WriteTransfersReport(List<ProductModel> products, IEnumerable<SellModel> sold)
        {

            using(StreamWriter streamWriter = new StreamWriter("TRANSFERE.txt"))
            {
                int productCode,
                    qtCO,
                    qtMin,
                    qtSold,
                    qtStockAfterSell,
                    qtRepoRequired,
                    qtTransferRequired;

                    streamWriter.Write($"Necessidade de Transferência Armazém para CO\n\n" + 
                    "Produto\tQtCO\tQtMin\tQtVendas\tEstq.após\tNecess.\tTransf. de\n" +
                    "\t\t\t\t\tVendas\t\t\tArm p/ CO\n");

                for (int i = 0; i < products.Count; i++)
                {
                    productCode = products[i].Code;
                    qtCO = products[i].Quantity;
                    qtMin = products[i].MinRequiredQuantity;
                    qtSold = GetQtSoldByCode(products[i].Code, sold);
                    qtStockAfterSell = products[i].Quantity - qtSold;
                    qtRepoRequired = products[i].MinRequiredQuantity - qtStockAfterSell;

                    if(qtRepoRequired < 0) qtRepoRequired = 0;
                    qtTransferRequired = qtRepoRequired;

                    if(qtTransferRequired < 10 && qtTransferRequired != 0)
                    qtTransferRequired = 10;

                    streamWriter.WriteLine(
                        "{0}\t{1}\t{2}\t{3}\t\t{4}\t\t{5}\t{6}", 
                        productCode,qtCO,qtMin,qtSold,qtStockAfterSell,qtRepoRequired,qtTransferRequired
                    );
                }
            }
        }

        //Retornando vendas concluidas.
        public static IEnumerable<SellModel> GetQtSold(List<SellModel> sells)
        {
            return sells
            .Where(x=> x.Status <= (StatusModel)102);
        }

        //Somando quantidade vendida por produto.
        private static int GetQtSoldByCode(int code, IEnumerable<SellModel> sold)
        {
            return sold
            .Where(x=> x.Code == code )
            .Sum(x => x.Quantity);
        }

        //Somando quantidade vendida por canal de venda.
        private static int GetQtSoldByChannel(ChannelModel channel, IEnumerable<SellModel> sold)
        {
            return sold
            .Where(x=> x.Channel == channel)
            .Sum(x => x.Quantity);
        }

        //Parsing string para produto.
        private static ProductModel ParseToProduct(string strProduct)
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
        private static SellModel ParseToSell(string strSell)
        {
            int[] strList = Array.ConvertAll(strSell.Split(';'), int.Parse);

            SellModel sell = new SellModel(
                code:       strList[0],
                quantity:   strList[1],
                status:     (StatusModel)strList[2],
                channel:    (ChannelModel)strList[3]
            );
            return sell;
        }
    }
}
