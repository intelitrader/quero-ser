using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Número incorreto de argumentos.");
            Console.WriteLine("Modo correto de uso: Solução.exe <caminho do arquivo vendas> <caminho do arquivo produtos>.");
            Console.WriteLine("Exemplos:\nSolução.exe vendas.txt produtos.txt.\nSolução.exe \"../caminho/relativo/vendas.txt\" \"../caminho/relativo/produtos.txt\"\nSolução.exe \"C:/Caminho/Absoluto/vendas.txt\" \"C:/Caminho/Absoluto/produtos.txt\"");
            return;
        }
        string vendasPath = Path.GetFullPath(args[0]);
        string produtosPath = Path.GetFullPath(args[1]);
        if (!File.Exists(produtosPath))
        {
            Console.WriteLine("Arquivo {0} não encontrado. Aplicação encerrada.", produtosPath);
            return;
        }
        else if (!File.Exists(vendasPath))
        {
            Console.WriteLine("Arquivo {0} não encontrado. Aplicação encerrada.", vendasPath);
            return;
        }
        string filePath = Directory.GetParent(produtosPath).FullName;

        List<int[]> produtosList = new(ReadFileValues(produtosPath));
        List<int[]> vendasList = new(ReadFileValues(vendasPath));

        PrintTransfere(SetTransfereList(vendasList, produtosList), filePath);
        PrintDivergencias(vendasList, produtosList, filePath);
        PrintTotCanais(vendasList, filePath);
    }

    public static List<int[]> ReadFileValues(string filePath)
    {
        List<int[]> fileValuesList = File.ReadLines(filePath)
                          .Select(line => line.Split(';'))
                          .Select(x => x.Select(int.Parse).ToArray())
                          .ToList();

        return fileValuesList;
    }

    public static int GetQtdCO(List<int[]> produtos, int codigo)
    {
        int qtdCO = 0;
        for (int i = 0; i < produtos.Count; i++)
        {
            if (codigo == produtos[i][0])
            {
                qtdCO += produtos[i][1];
                return qtdCO;
            }
        }
        return qtdCO;
    }

    public static int GetQtdMin(List<int[]> produtos, int codigo)
    {
        int qtdMin = 0;
        for (int i = 0; i < produtos.Count; i++)
        {
            if (codigo == produtos[i][0])
            {
                qtdMin += produtos[i][2];
                return qtdMin;
            }
        }
        return qtdMin;
    }

    public static int GetVendasPorCodigo(List<int[]> vendas, int codigo)
    {
        int qtdVendasPorCodigo = 0;
        for (int i = 0; i < vendas.Count; i++)
        {
            if (codigo == vendas[i][0])
            {
                if (vendas[i][2] == 100 || vendas[i][2] == 102)
                {
                    qtdVendasPorCodigo += vendas[i][1];
                }
            }
        }
        return qtdVendasPorCodigo;
    }

    public static int GetEstoqueAposVendas(List<int[]> vendas, List<int[]> produtos, int codigo)
    {
        int qtdCO, qtdVendas, estoqueAposVendas;

        qtdCO = GetQtdCO(produtos, codigo);
        qtdVendas = GetVendasPorCodigo(vendas, codigo);
        estoqueAposVendas = qtdCO - qtdVendas;

        return estoqueAposVendas;
    }

    public static int GetNecessidade(List<int[]> vendas, List<int[]> produtos, int codigo)
    {
        int necessidade;

        necessidade = Math.Max(0, (GetQtdMin(produtos, codigo) - GetEstoqueAposVendas(vendas, produtos, codigo)));

        return necessidade;
    }

    public static int GetTransfDeArmParaCO(List<int[]> vendas, List<int[]> produtos, int codigo)
    {
        int transfParaArmCO, necessidade;

        necessidade = GetNecessidade(vendas, produtos, codigo);

        if (necessidade > 1 && necessidade < 10)
        {
            transfParaArmCO = 10;
        }
        else
        {
            transfParaArmCO = necessidade;
        }

        return transfParaArmCO;
    }

    public static int GetVendasPorCanal(List<int[]> vendas, int canal)
    {
        int qtdVendasPorCanal = 0;
        for (int i = 0; i < vendas.Count; i++)
        {
            if (canal == vendas[i][3])
            {
                if (vendas[i][2] == 100 || vendas[i][2] == 102)
                {
                    qtdVendasPorCanal += vendas[i][1];
                }
            }
        }
        return qtdVendasPorCanal;
    }

    public static List<List<int>> SetTransfereList(List<int[]> vendas, List<int[]> produtos)
    {
        List<List<int>> transfereList = new();
        List<int> produtosList = new();
        List<int> qtdCOList = new();
        List<int> qtdMinList = new();
        List<int> qtdVendasList = new();
        List<int> estoqueAposVendasList = new();
        List<int> necessidadeList = new();
        List<int> transfDeArmParaCOList = new();

        for (int i = 0; i < produtos.Count; i++)
        {
            produtosList.Add(produtos[i][0]);
            qtdCOList.Add(GetQtdCO(produtos, produtos[i][0]));
            qtdMinList.Add(GetQtdMin(produtos, produtos[i][0]));
            qtdVendasList.Add(GetVendasPorCodigo(vendas, produtos[i][0]));
            estoqueAposVendasList.Add(GetEstoqueAposVendas(vendas, produtos, produtos[i][0]));
            necessidadeList.Add(GetNecessidade(vendas, produtos, produtos[i][0]));
            transfDeArmParaCOList.Add(GetTransfDeArmParaCO(vendas, produtos, produtos[i][0]));
        }
        transfereList.Add(produtosList);
        transfereList.Add(qtdCOList);
        transfereList.Add(qtdMinList);
        transfereList.Add(qtdVendasList);
        transfereList.Add(estoqueAposVendasList);
        transfereList.Add(necessidadeList);
        transfereList.Add(transfDeArmParaCOList);

        return transfereList;
    }

    public static void PrintTransfere(List<List<int>> transfereList, string filePath)
    {
        string writePath = filePath + "\\transfere.txt";
        string header = "Necessidade de Transferência Armazém para CO\n\n";
        List<string> columns = new() { "Produto", "QtCO", "QtMin", "QtVendas", "Estq. após", "Necess.", "Transf. de", "", "Vendas", "Arm p/ CO" };

        string columns1 = String.Format("{0}{1}{2}{3}{4}{5}{6}\n", columns[0].PadRight(columns[0].Length + 2), columns[1].PadRight(columns[1].Length + 2), columns[2].PadRight(columns[2].Length + 2), columns[3].PadRight(columns[3].Length + 2), columns[4].PadRight(columns[4].Length + 2), columns[5].PadRight(columns[5].Length + 2), columns[6]);
        string columns2 = String.Format("{0}{1}{2}\n", columns[7].PadRight(columns[7].Length + 35), columns[8].PadRight(columns[8].Length + 12), columns[9]);

        using StreamWriter writetext = new(writePath);
        writetext.Write(header);
        writetext.Write(columns1);
        writetext.Write(columns2);
        for (int i = 0; i < transfereList[0].Count; i++)
        {
            for (int j = 0; j < transfereList.Count; j++)
            {
                writetext.Write(String.Format("{0}", transfereList[j][i].ToString().PadRight(columns[j].Length + 2)));
            }
            writetext.WriteLine();
        }
        writetext.Close();
        Console.WriteLine("Tabela de Necessidade de transferência salva em: {0}", writePath);
    }

    public static void PrintDivergencias(List<int[]> vendas, List<int[]> produtos, string filePath)
    {
        string writePath = filePath + "\\divergencias.txt";
        bool exists;

        using StreamWriter writetext = new(writePath);
        for (int i = 0; i < vendas.Count; i++)
        {
            exists = false;
            if (vendas[i][2] == 135)
            {
                writetext.WriteLine("Linha {0} – Venda cancelada", i + 1);
            }
            else if (vendas[i][2] == 190)
            {
                writetext.WriteLine("Linha {0} – Venda não finalizada", i + 1);
            }
            else if (vendas[i][2] == 999)
            {
                writetext.WriteLine("Linha {0} – Erro desconhecido. Acionar equipe de TI", i + 1);
            }
            for (int j = 0; j < produtos.Count; j++)
            {
                if (produtos[j][0] == vendas[i][0])
                {
                    exists = true;
                }
            }
            if (!exists)
            {
                writetext.WriteLine("Linha {0} – Código de Produto não encontrado {1}", i + 1, vendas[i][0]);
            }
        }
        writetext.Close();
        Console.WriteLine("Tabela de divergências salva em: {0}", writePath);
    }

    public static void PrintTotCanais(List<int[]> vendas, string filePath)
    {
        string writePath = filePath + "\\totcanais.txt";
        string row;
        List<Tuple<int, int>> vendasPorCanal = new();
        int qtdCanaisDisponiveis = 4;
        Dictionary<int, string> canaisDictionary = new()
        {
            { 1, "Representantes" },
            { 2, "Website" },
            { 3, "App móvel Android" },
            { 4, "App móvel iPhone" }
        };

        string header = "Quantidades de Vendas por canal\n";
        string header2 = String.Format("{0}{1}", "Canal".PadRight(canaisDictionary[3].Length * 2), "QtVendas");

        for (int i = 1; i <= qtdCanaisDisponiveis; i++)
        {
            vendasPorCanal.Add(new Tuple<int, int>(i, GetVendasPorCanal(vendas, i)));
        }

        using StreamWriter writetext = new(writePath);
        writetext.WriteLine(header);
        writetext.WriteLine(header2);
        foreach (var canais in vendasPorCanal)
        {
            row = String.Format("{0} - {1}{2}", canais.Item1, canaisDictionary[canais.Item1].PadRight(canaisDictionary[3].Length * 2), canais.Item2);
            writetext.WriteLine(row);
        }
        writetext.Close();
        Console.WriteLine("Tabela de quantidades de vendas por canal salva em: {0}", writePath);
    }
}
