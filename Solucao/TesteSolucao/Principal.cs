using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TesteSolucao;

class Program
{


    static string caminhoprodutos = @"C:\Users\Administrador\Desktop\Teste\ConsoleTeste\CaseTeste1\c1_produtos.txt";
    static string caminhovendas = @"C:\Users\Administrador\Desktop\Teste\ConsoleTeste\CaseTeste1\c1_vendas.txt";


    static void Main()
    {
        List<Produto> ListaProdutos = new List<Produto>();
        List<Vendas> ListaVendas = new List<Vendas>();

        ListaProdutos = Produto.InserirProdutos(caminhoprodutos);
        ListaVendas = Vendas.InserirVendas(caminhovendas);
        Transfere.Example(ListaProdutos,ListaVendas);
        RelatorioDivergencia.Divergencia(ListaProdutos, ListaVendas);
        RelatorioCanais.Canais(ListaVendas);

    }



}