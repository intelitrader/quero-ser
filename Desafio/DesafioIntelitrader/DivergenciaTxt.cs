using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIntelitrader
{
    //Classe referente ao arquivo de saída divergencias.txt
    internal class DivergenciaTxt
    {
        EntradaTxt entradaTxt = new EntradaTxt();

        //Método responsável por pesquisar e organizar as divergências
        //existentes no arquivo vendas.txt, e retornar uma lista
        //com cada ocorrência.
        public IList<String> PesquisarDivergencias()
        {
            IList<IList<String>> listaProdutos = entradaTxt.LerTxt(TipoEntrada.Produtos);
            IList<IList<String>> listaVendas = entradaTxt.LerTxt(TipoEntrada.Vendas);
            IList<String> listaCodigos = new List<String>();
            IList<String> listaDivergencias = new List<String>();

            try
            {
                foreach (var produto in listaProdutos)
                {
                    listaCodigos.Add(produto[0]);
                }
                int i = 0;

                foreach (var venda in listaVendas)
                {
                    String situacao = "";
                    i++;

                    if (listaCodigos.Contains(venda[0]) || venda[2] == "999")
                    {
                        switch (venda[2])
                        {
                            case "135":
                                situacao = $"Linha {i} – Venda cancelada";
                                break;
                            case "190":
                                situacao = $"Linha {i} – Venda não finalizada";
                                break;
                            case "999":
                                situacao = $"Linha {i} – Erro desconhecido. Acionar equipe de TI";
                                break;
                            default:
                                break;
                        }
                    }
                    else situacao += $"Linha {i} - Código de Produto não encontrado {venda[0]}";

                    if (situacao != "") listaDivergencias.Add(situacao);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return listaDivergencias;

        }

        //Metódo responsável por criar o arquivo divergencias.txt na pasta Arquivos,
        //utilizando as informações retornadas do método PesquisarDivergencias()
        public void CriarTxt()
        {
            try
            {
                StreamWriter sw = new StreamWriter("..\\..\\..\\Arquivos\\divergencias.txt");

                foreach (var item in PesquisarDivergencias())
                {
                    sw.WriteLine(item);
                }
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
