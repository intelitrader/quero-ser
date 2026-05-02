using System;
using Solucao.Models;
class Program
{
    static void Main(string[] args)
    {
        // Uso de lista para armazenar os objetos 
        List<Produtos> produtos = new();
        List<Vendas> vendas = new();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Antes de utilizar, por favor colocar os arquivo contendo os produtos na pasta 'Produtos', Localizada dentro do diretório 'Solucao'");
        Console.WriteLine("Antes de utilizar, por favor colocar os arquivo contendo as vendas na pasta 'Vendas', Localizada dentro do diretório 'Solucao'!");
        Console.ResetColor();

        Console.WriteLine("Por favor, coloque o nome (exatamento igual) do arquivo de Vendas");
        Console.Write("R: ");
        string? nomeArquivoVendas = Console.ReadLine();

        Console.WriteLine("");

        Console.WriteLine("Por favor, coloque o nome (exatamento igual) do arquivo de Vendas");
        Console.Write("R: ");
        string? nomeArquivoProdutos = Console.ReadLine();


        List<string> linhasProdutos = LerTodasAsLinhasTxt($"C:\\Users\\Vinicius\\Desktop\\quero-ser-intelitrader\\Solucao\\Produtos\\{nomeArquivoProdutos}");
        List<string> linhasVendas = LerTodasAsLinhasTxt($"C:\\Users\\Vinicius\\Desktop\\quero-ser-intelitrader\\Solucao\\Vendas\\{nomeArquivoVendas}");


        #region Adiciona produtos na lista de Produtos
        for (int index = 0; index < linhasProdutos.Count; index++)
        {
            Produtos novoProduto = new()
            {
                CodProduto = Convert.ToInt32(linhasProdutos[index].Split(';')[0]),
                QtdEmEstoque = Convert.ToInt32(linhasProdutos[index].Split(';')[1]),
                QtdMinCO = Convert.ToInt32(linhasProdutos[index].Split(';')[2])
            };

            produtos.Add(novoProduto);
        }

        #endregion

        #region Adiciona as vendas na lista de vendas
        for (int index = 0; index < linhasVendas.Count; index++)
        {
            Vendas novaVenda = new()
            {
                Linha = index + 1,
                CodProduto = Convert.ToInt32(linhasVendas[index].Split(';')[0]),
                QtdVendida = Convert.ToInt32(linhasVendas[index].Split(';')[1]),
                SituacaoVenda = Convert.ToInt32(linhasVendas[index].Split(';')[2]),
                CanalDeVenda = Convert.ToInt32(linhasVendas[index].Split(';')[3])
            };

            vendas.Add(novaVenda);
        }
        #endregion


        EscreverTotCanais(vendas);
        EscreverDivergencias(vendas, produtos);

        List<Vendas> VendasConfirmadas = new();

        #region Separa as vendas confirmadas das vendas em geral
        foreach (var item in vendas)
        {
            if (item.SituacaoVenda == 100 || item.SituacaoVenda == 102) // 100 e 102 Status de vendas confirmadas
            {
                if (!VendasConfirmadas.Exists(v => v.CodProduto == item.CodProduto)) // Para evitar a repetição na tabela de transferências, verifique se já existe alguma venda com o mesmo código
                {
                    VendasConfirmadas.Add(item);
                }
                else
                {
                    var vendaAchada = VendasConfirmadas.FirstOrDefault(v => v.CodProduto == item.CodProduto);

                    if (vendaAchada != null)
                    {
                        vendaAchada.QtdVendida += item.QtdVendida;

                    }
                }
            }

        }
        #endregion

        List<Transferencias> novasTransferencias = new();

        #region Criando transferências
        foreach (var item in VendasConfirmadas)
        {
            var produtoAchado = produtos.FirstOrDefault(p => p.CodProduto == item.CodProduto);

            if (produtoAchado != null)
            {
                int estoqueAposVendas = produtoAchado.QtdEmEstoque - item.QtdVendida;
                int necessidade = (produtoAchado.QtdMinCO - estoqueAposVendas) < 1 ? 0 : produtoAchado.QtdMinCO - estoqueAposVendas; // Caso o valor seja negativo coloque 0

                Transferencias novaTransferencia = new()
                {
                    Produto = item.CodProduto,
                    QtdCO = Convert.ToInt32(produtoAchado.QtdEmEstoque),
                    QtMin = Convert.ToInt32(produtoAchado.QtdMinCO),
                    QtdVendas = item.QtdVendida,
                    EstoqueAposVendas = estoqueAposVendas,
                    Necessario = necessidade
                };

                if (necessidade >= 1 && necessidade <= 10)
                {
                    novaTransferencia.TrasnfDeArmParaCO = 10;
                }
                else
                {
                    novaTransferencia.TrasnfDeArmParaCO = necessidade;
                }

                novasTransferencias.Add(novaTransferencia);
            }

        }
        #endregion

        EscreverTransfer(novasTransferencias);

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(";) Olhe a dentro da pasta Solucao!!");
        Console.ResetColor();
    }

    static void EscreverTransfer(List<Transferencias> transferencias)
    {
        string nomeArquivo = "transfere.txt";

        StreamWriter sw = new(nomeArquivo);
        sw.WriteLine("Necessidade de Transferência Armazém para CO");
        sw.WriteLine("");
        sw.WriteLine(@"Produto	QtCO	QtMin	QtVendas	Estq.após	Necess.  Transf. de Vendas Arm p / CO");


        foreach (var item in transferencias)
        {
            sw.WriteLine($@"{item.Produto}	{item.QtdCO}     {item.QtMin}       {item.QtdVendas}        {item.EstoqueAposVendas}       {item.Necessario}           {item.TrasnfDeArmParaCO}");
        }

        sw.Close();
    }

    /// <summary>
    /// Cria o Arquivo de Divergencias 
    /// </summary>
    /// <param name="Vendas">Lista de vendas</param>
    /// <param name="Produtos">Lista de produtos</param>
    static void EscreverDivergencias(List<Vendas> Vendas, List<Produtos> Produtos)
    {
        string nomeArquivo = "DIVERGENCIAS.txt";

        if (!File.Exists(nomeArquivo))
        {
            File.Create(nomeArquivo).Close();
        }

        foreach (var item in Vendas)
        {
            if (item.SituacaoVenda == 135)
            {
                using StreamWriter sw = File.AppendText(nomeArquivo);
                sw.WriteLine($"Linha {item.Linha} - Venda Cancelada");
                sw.Close();
            }
            else if (item.SituacaoVenda == 190)
            {
                using StreamWriter sw = File.AppendText(nomeArquivo);
                sw.WriteLine($"Linha {item.Linha} - Venda não finalizada");
                sw.Close();
            }
            else if (item.SituacaoVenda == 999)
            {
                using StreamWriter sw = File.AppendText(nomeArquivo);
                sw.WriteLine($"Linha {item.Linha} - Erro desconhecido.Acionar equipe de TI");
                sw.Close();
            }
            else if (!Produtos.Exists(p => p.CodProduto == item.CodProduto))
            {
                using StreamWriter sw = File.AppendText(nomeArquivo);
                sw.WriteLine($"Linha {item.Linha} – Código de Produto não encontrado {item.CodProduto}");
                sw.Close();
            }


        }
    }

    /// <summary>
    /// Escreve o Arquivo ToTCanais
    /// </summary>
    /// <param name="vendas">Lista contendo os valores das vendas</param>
    static void EscreverTotCanais(List<Vendas> vendas)
    {
        string nomeArquivo = "TOTCANAIS.txt";

        int representantes = 0;
        int website = 0;
        int appMovelAndroid = 0;
        int appMovelIphone = 0;

        foreach (var item in vendas)
        {
            if (item.SituacaoVenda == 100 || item.SituacaoVenda == 102)
            {
                switch (item.CanalDeVenda)
                {
                    case 1:
                        representantes += item.QtdVendida;
                        break;
                    case 2:
                        website += item.QtdVendida;
                        break;
                    case 3:
                        appMovelAndroid += item.QtdVendida;
                        break;
                    case 4:
                        appMovelIphone += item.QtdVendida;
                        break;
                    default:
                        break;
                }

            }
        }

        using StreamWriter sw = File.AppendText(nomeArquivo);
        sw.WriteLine(
@$"Quantidades de Vendas por canal

1 - Representantes	{representantes}
2 - Website			{website}
3 - App móvel Android  {appMovelAndroid}
4 - App móvel iPhone   {appMovelIphone}");
    }

    /// <summary>
    /// Lê todas as linhas do arquivo txt
    /// </summary>
    /// <param name="_caminho">caminho do arquivo txt</param>
    /// <returns>Uma lista com todas as linhas do txt</returns>
    static List<string> LerTodasAsLinhasTxt(string _caminho)
    {
        List<string> linhas = new List<string>();
        using (StreamReader file = new StreamReader(_caminho))
        {
            string? linha;
            while ((linha = file.ReadLine()) != null)
            {
                linhas.Add(linha);
            }
        }

        return linhas;
    }
}
