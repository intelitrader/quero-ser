using System;
using Troco.Entities;

namespace Troco
{
    class Program
    {
        static void Main(string[] args)
        {
            Caixa cx = new Caixa();
            Console.WriteLine("Entre com o valor total a ser pago: ");
            cx.ValorTotal = double.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o valor recebido: ");
            cx.ValorRecebido = double.Parse(Console.ReadLine());

            cx.GetTroco(cx.ValorTotal, cx.ValorRecebido);
        }
    }
}
