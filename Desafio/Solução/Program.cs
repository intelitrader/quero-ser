using System;
using System.IO;
using System.Linq;

namespace QueroSerSol
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathVendas = Console.ReadLine();
            string pathProdutos = Console.ReadLine();
            StreamReader arquivo = new StreamReader(pathProdutos);

            //StreamReader arquivo = new StreamReader(@"..\Caso de teste 1\c1_produtos.txt");
            int i = 0;
            var codigos = new string[100];
            var quantInicial = new int[100];
            var quantMin = new int[100];
            var quantVendida = new int[100];
            var quantAposVendas = new int[100];
            var quantReposicao = new int[100];
            var quantTransf = new int[100];
            var codigosErros = new string[3]{"135","190","999"};
            var quantVendaCanal = new int[4];

            while (!arquivo.EndOfStream)
            {
                string linha = arquivo.ReadLine();
                string[] produto = linha.Split(';', 3);
                codigos[i] = produto[0];
                quantInicial[i] = Convert.ToInt32(produto[1]);
                quantMin[i] = Convert.ToInt32(produto[2]);
                i++;
            }
            arquivo = new StreamReader(pathVendas);
            //arquivo = new StreamReader(@"..\Caso de teste 1\c1_vendas.txt");
            StreamWriter writeError = new StreamWriter(@".\divergencias.txt", false);
            i = 0;
            while (!arquivo.EndOfStream)
            {
                string linha = arquivo.ReadLine();
                string[] vendas = linha.Split(';', 4);
                if(codigosErros.Contains(vendas[2]))
                {
                    switch(vendas[2])
                    {
                        case "135":
                            writeError.WriteLine("Linha "+ (i+1) + " - Venda cancelada");
                            break;
                        case "190":
                    
                            writeError.WriteLine("Linha "+ (i+1) + " -  Venda não finalizada");
                            break;
                        case "999":
                            writeError.WriteLine("Linha "+ (i+1) + " -  Erro desconhecido. Acionar equipe de TI");
                            break;
                    }
                }
                else
                {
                    if(codigos.Contains(vendas[0]))
                    {
                        var j = Array.IndexOf<string>(codigos,vendas[0]);
                        quantVendida[j] += Convert.ToInt32(vendas[1]);
                        quantAposVendas[j] = quantInicial[j] - quantVendida[j];
                        if(quantAposVendas[j] < quantMin[j])
                        {
                            quantReposicao[j] = quantMin[j] - quantAposVendas[j];
                            if(quantReposicao[j] < 10)
                            {
                                quantTransf[j] = 10;
                            }
                            else
                            {
                                quantTransf[j] = quantReposicao[j];
                            }
                        }
                        switch(vendas[3])
                        {
                            case "1":
                                quantVendaCanal[0] += Convert.ToInt32(vendas[1]);
                                break;
                            case "2":
                                quantVendaCanal[1] += Convert.ToInt32(vendas[1]);
                                break;
                            case "3": 
                                quantVendaCanal[2] += Convert.ToInt32(vendas[1]);
                                break;
                            case "4":
                                quantVendaCanal[3] += Convert.ToInt32(vendas[1]);
                                break;
                        }
                    }
                    else
                    {
                        writeError.WriteLine("Linha "+ (i+1) + " - Código de Produto não encontrado " + vendas[0]);
                        
                    }
                }
                i++;
            }

            StreamWriter writeTotal = new StreamWriter(@".\totcanal.txt", false);
            writeTotal.WriteLine("Quantidades de Vendas por canal\n");
            writeTotal.WriteLine("1 - Representantes	    	"+ quantVendaCanal[0]);
            writeTotal.WriteLine("2 - Website					"+ quantVendaCanal[1]);
            writeTotal.WriteLine("3 - App móvel Android		"+ quantVendaCanal[2]);
            writeTotal.WriteLine("4 - App móvel iPhone		"+ quantVendaCanal[3]);

            StreamWriter writeTrasnf = new StreamWriter(@".\transfere.txt", false);
            writeTrasnf.WriteLine("Necessidade de Transferência Armazém para CO\n");
            writeTrasnf.WriteLine("Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.	Transf. de");
            writeTrasnf.WriteLine("				                    Vendas			    Arm p/ CO");
            foreach(var codigo in codigos)
            {
                if(codigo != null)
                {
                    var j = Array.IndexOf<string>(codigos,codigo);
                    var linha = "{0,-7}	{1,-5}	{2,-5}	{3,-8}	{4,-9}	{5,-8}	{6,-5}";
                    var line= String.Format(linha ,codigo, quantInicial[j], quantMin[j], quantVendida[j], quantAposVendas[j], quantReposicao[j], quantTransf[j]);
                    writeTrasnf.WriteLine(line);
                }
            }

            writeTotal.Close();
            writeTrasnf.Close();
            writeError.Close();     
            arquivo.Close();
        }
    }
}
