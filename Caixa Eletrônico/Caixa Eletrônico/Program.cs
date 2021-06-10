using System;

namespace Caixa_Eletrônico
{
    public class Program
    {
        //https://dojopuzzles.com/problems/caixa-eletronico/
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-Vindo ao Caixa eletronico");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Por favor insira um valor para calcularmos retorno de notas");
            int valor = int.Parse(Console.ReadLine());
            Calcular calculaar = new Calcular();
            calculaar.CalculadorDeNotas(valor);
            Console.WriteLine("Deseja Inserir outro valor? Se sim digite sim");
            var repetir = Console.ReadLine();
            while(repetir == "sim")
            {
                Console.WriteLine("Por favor insira um valor para calcularmos retorno de notas");
                valor = int.Parse(Console.ReadLine());
                calculaar.CalculadorDeNotas(valor);
                Console.WriteLine("Deseja Inserir outro valor? Se sim digite sim");
                repetir = Console.ReadLine();
            }
        }
    }
}
