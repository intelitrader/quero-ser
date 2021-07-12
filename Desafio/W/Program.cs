using W.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace W
{
    public class Program
    {
        private static List<Product> _products = new List<Product>();
        private static List<Sale> _sales = new List<Sale>();
        public static void Main(string[] args)
        {
            ReadProducts(args[0]);
            ReadSales(args[1]);
            ProcessTransfers();
            ProcessDivergences();
            ProcessSaleChannels();
        }

        private static void ProcessSaleChannels()
        {
            int representatives, website, android, ios;
            representatives = website = android = ios = 0;
            foreach (var sale in _sales)
            {
                if (sale.Status is (SaleStatus.ConfirmedAndPaid or SaleStatus.ConfirmedAndAwaitingPayment))
                {
                    switch (sale.Channel)
                    {
                        case SaleChannel.AppAndroid:
                            android += sale.Quantity;
                            break;
                        case SaleChannel.AppIOS:
                            ios += sale.Quantity;
                            break;
                        case SaleChannel.Representative:
                            representatives += sale.Quantity;
                            break;
                        case SaleChannel.Website:
                            website += sale.Quantity;
                            break;
                    }
                }
            }
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Quantidades de Vendas por canal");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("1 - Representantes\t\t{0}", representatives));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("2 - Website\t\t\t{0}", website));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("3 - App móvel Android\t\t{0}", android));
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(string.Format("4 - App móvel iPhone\t\t{0}", ios));
            WriteToFile("./TOTCANAIS.TXT", stringBuilder.ToString());
        }

        private static void ProcessDivergences()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var sale in _sales)
            {
                stringBuilder.Append(sale.Status switch
                {
                    SaleStatus.Error => string.Format("Linha {0} - Erro desconhecido. Acionar equipe de TI", sale.Line),
                    SaleStatus.Canceled => string.Format("Linha {0} - Venda cancelada", sale.Line),
                    SaleStatus.Unfinished => string.Format("Linha {0} - Venda não finalizada", sale.Line),
                    _ => ""
                });
                if ((int)sale.Status >= 135)
                {
                    stringBuilder.Append(Environment.NewLine);
                    continue;
                }
                // LINQ: products.Any(s => s.Id == sale.ProductId);
                bool found = false;
                foreach (var product in _products)
                {
                    if (product.Id == sale.ProductCode)
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    stringBuilder.Append(string.Format("Linha {0} - Código de Produto não encontrado {1}", sale.Line, sale.ProductCode));
                    stringBuilder.Append(Environment.NewLine);
                }
            }
            WriteToFile("./divergencias.txt", stringBuilder.ToString());
        }

        private static void ProcessTransfers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Necessidade de Transferência Armazém para CO");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("Produto\tQtCO\tQtMin\tQtVendas\tEstq.após\tNecess.\tTransf.\tde");
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append("\t\t\t\t\tVendas\t\t\tArm p/ CO");
            stringBuilder.Append(Environment.NewLine);
            foreach (var product in _products)
            {
                int sales = SalesFor(product);
                int postSalesStock = product.InStock - sales;
                int neededForMinimum = product.OperationalMinimum - postSalesStock < 0 ? 0 : product.OperationalMinimum - postSalesStock;
                int neededTransfered = neededForMinimum is (>= 1 and < 10) ? 10 : neededForMinimum;
                stringBuilder.Append(
                    string.Format("{0}\t{1}\t{2}\t{3}\t\t{4}\t\t{5}\t\t{6}",
                    product.Id,
                    product.InStock,
                    product.OperationalMinimum,
                    sales,
                    postSalesStock,
                    neededForMinimum,
                    neededTransfered
                ));
                stringBuilder.Append(Environment.NewLine);
            }
            WriteToFile("./transfere.txt", stringBuilder.ToString());
        }

        private static int SalesFor(Product product)
        {
            int sales = 0;
            foreach (var sale in _sales)
            {
                if (sale.ProductCode == product.Id && sale.Status is SaleStatus.ConfirmedAndPaid or SaleStatus.ConfirmedAndAwaitingPayment)
                    sales += sale.Quantity;
            }
            return sales;
        }

        private static void ReadSales(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format("O arquivo de vendas em \"{0}\" não pôde ser encontrado", path));
            }
            using (var streamReader = new StreamReader(path))
            {
                int line = 1;
                while (streamReader.Peek() >= 0)
                {
                    _sales.Add(new Sale(streamReader.ReadLine(), line));
                    line++;
                }
            }
        }

        private static void ReadProducts(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException(string.Format("O arquivo de produtos em \"{0}\" não pôde ser encontrado", path));
            }
            using (var streamReader = new StreamReader(path))
            {
                while (streamReader.Peek() >= 0)
                {
                    _products.Add(new Product(streamReader.ReadLine()));
                }
            }
        }

        private static void WriteToFile(string path, string content)
        {
            using (var streamWritter = new StreamWriter(path))
            {
                streamWritter.Write(content);
            }
        }
    }
}
