using System;

namespace Entradas_No_Banco
{
    public class Program
    {
        //https://dojopuzzles.com/problems/entradas-no-banco/
        static void Main(string[] args)
        {
            DateTime horaAtual = new DateTime();
            horaAtual = DateTime.Now;
            CompararHorario compara = new CompararHorario();
            compara.Comparar(horaAtual);

        }
    }
}
