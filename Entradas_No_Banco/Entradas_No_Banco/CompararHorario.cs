using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Entradas_No_Banco
{
    public class CompararHorario : ICompararHorario
    {
        public string MyProperty { get; set; }
        
        List<ListaDeLogs> lista = new List<ListaDeLogs>();

        public void Comparar(DateTime dataAtual)
        {
            var hora = dataAtual.Hour;
            bool statusPorta = false;
            CompararHorario _comaparar = new CompararHorario();

            //Horario de Inicio
            if (hora >= 10 )
            {
                //Horaroi de termino
                while(hora <= 15)
                {
                    //simular uma entrada de dados
                    //ATENÇÃO : está simulação causa um loop infinito
                    /*statusPorta = true;*/

                    while (statusPorta == true)
                    {
                        lista.Add(new ListaDeLogs() { RetornoPadrao = " - Abertura da Porta OK", DataAtual = DateTime.Now });
                        statusPorta = false;

                        //visualizar se esta retornando o log
                        /*foreach (ListaDeLogs forList in lista)
                        {
                            Console.WriteLine(forList);
                        }*/
                    }
                }
            }
            else { Console.WriteLine("O horario atual não esta dentro do solicitado, pelo poblema"); }

            foreach(ListaDeLogs forList in lista)
            {
                Console.WriteLine(forList);
            }
        }
    }
    public class ListaDeLogs : IEquatable<ListaDeLogs>
    {
        public string RetornoPadrao { get; set; }
        public DateTime DataAtual { get; set; }
        public bool Equals([AllowNull] ListaDeLogs other)
        {
            throw new NotImplementedException();
        }
    }
}
