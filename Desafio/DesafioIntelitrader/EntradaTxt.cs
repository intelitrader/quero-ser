using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIntelitrader
{
    //Classe referente aos arquivos de entrada (produtos.txt e venda.txt) 
    internal class EntradaTxt
    {

        String nomeArquivo = "";

        //Metódo responsável por ler os arquivos de entrada e retornar uma lista
        //contendo as suas linhas e o conteúdo presente nelas.
        //Possui como parâmetro um Enum que define qual arquivo de entrada deverá ser lido
        public IList<IList<String>> LerTxt(TipoEntrada tipo)
        {
            IList<IList<String>> listaLinhas = new List<IList<String>>();

            String? linha;

            //Verificando o nome do arquivo a ser lido a partir do Enum informado
            if (tipo == TipoEntrada.Produtos) nomeArquivo = "produtos.txt";
            else if (tipo == TipoEntrada.Vendas) nomeArquivo = "vendas.txt";

            try
            {
                //Acessando o arquivo txt definido, localizado na pasta Arquivos.
                //Como exemplo utilizei os arquivos de produtos e vendas fornecidos no Caso de teste 2 do Desafio
                StreamReader txt = new StreamReader($"..\\..\\..\\Arquivos\\{nomeArquivo}");

                linha = txt.ReadLine();

                //Iterando nas linhas do arquivo, separando seu conteúdo e adicionando eles a uma lista
                while (linha != null)
                {
                    IList<String> itens = linha.Split(';').ToList();
                    listaLinhas.Add(itens);
                    linha = txt.ReadLine();
                }
                txt.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            //Retornando a lista com conteúdo
            return listaLinhas;
        }
    }
    //Enum para definir qual tipo de entrada será lido
    internal enum TipoEntrada
    {
        Produtos,
        Vendas
    }
}
