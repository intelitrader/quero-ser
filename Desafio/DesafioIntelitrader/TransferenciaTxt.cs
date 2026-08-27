using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIntelitrader
{
    //Classe referente ao arquivo de saída transfere.txt
    internal class TransferenciaTxt
    {
        EntradaTxt entradaTxt = new EntradaTxt();

        //Método que será responsável por estruturar as informações e
        //fazer os cálculos referentes as vendas confirmadas e as transferências
        //de produtos necessários, retornando uma lista com esses dados
        public IList<IList<String>> CalcularTransferencia()
        {
            IList<IList<String>> listaProdutos = entradaTxt.LerTxt(TipoEntrada.Produtos);
            IList<IList<String>> listaVendas = entradaTxt.LerTxt(TipoEntrada.Vendas);

            int i = 0;

            try
            {
                foreach (var produto in listaProdutos)
                {
                    int qtVendas = 0;
                    int estqPosVenda = 0;
                    int qtNecRepo = 0;
                    int qtTransf = 0;

                    foreach (var venda in listaVendas)
                    {
                        if ((produto[0] == venda[0]) && ((venda[2] == "100") || (venda[2] == "102")))
                        {
                            qtVendas += Int32.Parse(venda[1]);
                        }
                    }
                    int qtdMin = Int32.Parse(produto[2]);
                    estqPosVenda = Int32.Parse(produto[1]) - qtVendas;
                    qtNecRepo = estqPosVenda < qtdMin ? qtdMin - estqPosVenda : 0;
                    qtTransf = qtNecRepo > 1 && qtNecRepo < 10 ? 10 : qtNecRepo;
                    listaProdutos[i].Add(qtVendas.ToString());
                    listaProdutos[i].Add(estqPosVenda.ToString());
                    listaProdutos[i].Add(qtNecRepo.ToString());
                    listaProdutos[i].Add(qtTransf.ToString());
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            return listaProdutos;
        }

        //Metódo responsável por criar o arquivo transfere.txt na pasta Arquivos,
        //utilizando as informações retornadas do método CalcularTransferencia()
        public void CriarTxt()
        {
            try
            {
                StreamWriter sw = new StreamWriter("..\\..\\..\\Arquivos\\transfere.txt");

                sw.WriteLine("Necessidade de Transferência Armazém para CO\r\n\r\n" +
                             "Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de\r\n" +
                             "                                   Vendas            Arm p/ CO");

                foreach (var item in CalcularTransferencia())
                {
                    sw.WriteLine(String.Format("{0, -7}  {1, 4}  {2, 5}  {3, 8}  {4, 9}  {5, 7}  {6, 10}",
                    item[0], item[1], item[2], item[3], item[4], item[5], item[6]));
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
