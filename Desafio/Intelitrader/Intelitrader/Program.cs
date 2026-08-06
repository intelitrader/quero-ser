using Intelitrader.Entities;
using Intelitrader.Entities.Enums;
using System.Collections.Generic;
using System.IO;

namespace Intelitrader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string salesPath = @"..\..\..\..\Caso de teste 2\c2_vendas.txt";
            string productsPath = @"..\..\..\..\Caso de teste 2\c2_produtos.txt";
            string transferePath = @"..\..\..\..\Caso de teste 2\transfere.txt";
            string divergencePath = @"..\..\..\..\Caso de teste 2\divergencias.txt";
            string totChannelPath = @"..\..\..\..\Caso de teste 2\totcanais.txt";

            List<Sale> sales = new List<Sale>();
            List<Product> products = new List<Product>();

            using (StreamReader sr = File.OpenText(salesPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] props = line.Split(';');

                    int productCode = int.Parse(props[0]);
                    int soldAmount = int.Parse(props[1]);
                    SaleStatus saleStatus = (SaleStatus)int.Parse(props[2]);
                    SaleChannel saleChannel = (SaleChannel)int.Parse(props[3]);

                    sales.Add(new Sale(productCode, soldAmount, saleStatus, saleChannel));
                }
            }

            using (StreamReader sr = File.OpenText(productsPath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] props = line.Split(';');

                    int code = int.Parse(props[0]);
                    int quantity = int.Parse(props[1]);
                    int minimalForOC = int.Parse(props[2]);
                    List<Sale> thisSales = new List<Sale>();

                    foreach (Sale sale in sales)
                    {
                        if (sale.ProductCode == code)
                            thisSales.Add(sale);
                    }

                    products.Add(new Product(code, quantity, minimalForOC, thisSales));
                }
            }

            // Transfere

            using (StreamWriter sw = File.AppendText(transferePath))
            {
                sw.WriteLine("Necessidade de Transferência Armazém para CO");
                sw.WriteLine();
                sw.WriteLine("Produto     QtCO      QtMin   QtVendas  Estq.após Vendas	Necess.    Transf. de Arm p/ CO");
                sw.WriteLine();

                foreach (Product product in products)
                {
                    sw.Write(product.Code + "       ");
                    sw.Write(product.Quantity + "       ");
                    sw.Write(product.MinimalForOC + "       ");
                    sw.Write(product.TotalSold() + "        ");
                    sw.Write(product.InventoryAmount() + "                  ");
                    sw.Write(product.ReplacementNeeded() + "        ");
                    sw.WriteLine(product.TransferToOC());
                }
            }

            // Relatório de Divergências

            using (StreamWriter sw = File.AppendText(divergencePath))
            {
                List<int> productCodes = new List<int>();

                foreach (Product product in products)
                {
                    productCodes.Add(product.Code);
                }

                for (int i = 1; i < sales.Count; i++)
                {
                    if (!productCodes.Contains(sales[i].ProductCode))
                        sw.WriteLine($"Linha {i + 1} – Código de Produto não encontrado {sales[i].ProductCode}");

                    if (sales[i].SaleStatus == (SaleStatus)135)
                        sw.WriteLine($"Linha {i + 1} – Venda cancelada");

                    if (sales[i].SaleStatus == (SaleStatus)190)
                        sw.WriteLine($"Linha {i + 1} – Venda não finalizada");

                    if (sales[i].SaleStatus == (SaleStatus)999)
                        sw.WriteLine($"Linha {i + 1} – Erro desconhecido. Acionar equipe de TI");
                }
            }

            // Relatório por canais

            using (StreamWriter sw = File.AppendText(totChannelPath))
            {
                int tradeRepresentativeSum = 0;
                int websiteSum = 0;
                int mobileAndroidAppSum = 0;
                int MobileIosAppSum = 0;

                foreach (Sale sale in sales)
                {
                    if (sale.SaleStatus == (SaleStatus)100
                        || sale.SaleStatus == (SaleStatus)102)
                    {
                        if (sale.SaleChannel == (SaleChannel)1)
                            tradeRepresentativeSum += 1;

                        if (sale.SaleChannel == (SaleChannel)2)
                            mobileAndroidAppSum += 1;

                        if (sale.SaleChannel == (SaleChannel)3)
                            mobileAndroidAppSum += 1;

                        if (sale.SaleChannel == (SaleChannel)4)
                            MobileIosAppSum += 1;
                    }
                }

                sw.WriteLine("Quantidades de Vendas por canal");
                sw.WriteLine();
                sw.WriteLine($"1 - Representantes		{tradeRepresentativeSum}");
                sw.WriteLine($"2 - Website			      {websiteSum}");
                sw.WriteLine($"3 - App móvel Android	      {mobileAndroidAppSum}");
                sw.WriteLine($"4 - App móvel iPhone		{MobileIosAppSum}");
            }

        }
    }
}
