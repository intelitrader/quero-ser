using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioIntelitrader
{
    //Classe referente ao arquivo de saída totcanais.txt
    internal class VendaCanalTxt
    {
        EntradaTxt entradaTxt = new EntradaTxt();

        //Método responsável por levantar a quantidade
        //de vendas total realizada por cada canal,
        //retornando elas em uma lista
        public IList<String> CalcularTotal()
        {
            IList<IList<String>> listaVendas = entradaTxt.LerTxt(TipoEntrada.Vendas);
            IList<String> listaVendaCanais = new List<String>();

            int vendasRep = 0;
            int vendasWebsite = 0;
            int vendasAndroid = 0;
            int vendasIphone = 0;

            try
            {
                foreach (var venda in listaVendas)
                {
                    if (venda[2] == "100" || venda[2] == "102")
                    {
                        switch (venda[3])
                        {
                            case "1":
                                vendasRep += Int32.Parse(venda[1]);
                                break;
                            case "2":
                                vendasWebsite += Int32.Parse(venda[1]);
                                break;
                            case "3":
                                vendasAndroid += Int32.Parse(venda[1]);
                                break;
                            case "4":
                                vendasIphone += Int32.Parse(venda[1]);
                                break;
                            default:
                                Console.WriteLine("Número de Canal inválido");
                                break;
                        }
                    }
                }
                listaVendaCanais.Add(vendasRep.ToString());
                listaVendaCanais.Add(vendasWebsite.ToString());
                listaVendaCanais.Add(vendasAndroid.ToString());
                listaVendaCanais.Add(vendasIphone.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }

            return listaVendaCanais;
        }

        //Metódo responsável por criar o arquivo totcanais.txt na pasta Arquivos,
        //utilizando as informações retornadas do método CalcularTotal()
        public void CriarTxt()
        {
            try
            {
                IList<String> listaVendasCanais = CalcularTotal();
                StreamWriter sw = new StreamWriter("..\\..\\..\\Arquivos\\totcanais.txt");

                sw.WriteLine("Quantidades de Vendas por canal\r\n\r\n" +
                             "Canal                  QtVendas");
                sw.WriteLine(String.Format("1 - Representantes     {0, 8}\r\n" +
                                           "2 - Website            {1 ,8}\r\n" +
                                           "3 - App móvel Android  {2, 8}\r\n" +
                                           "4 - App móvel iPhone   {3, 8}",
                                           listaVendasCanais[0], listaVendasCanais[1],
                                           listaVendasCanais[2], listaVendasCanais[3]));
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }

    }
}
