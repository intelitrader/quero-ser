using System;
using System.Globalization;
using System.Text.Encodings.Web;

namespace Calcular_troco
{
    class Program
    {
        static void Main(string[] args)
        {
            //Criando arrays com valores das notas e moedas
            float[] Moedas = { 1.00f, 0.50f, 0.25f, 0.10f, 0.05f };
            float[] Notas = { 200, 100, 50, 10, 5, 2 };

            //Pedindo o valor do produto
            Console.WriteLine("Informe o valor do produto: ");
            var ValorProduto = float.Parse(Console.ReadLine());

            //Pedindo o valor recebido
            Console.WriteLine("Valor que o cliente entregou: ");
            var ValorRecebido = float.Parse(Console.ReadLine());

            //Calculando troco
            var Troco = Math.Round(ValorRecebido - ValorProduto, 2);

            //Verificações básicas
            if (ValorRecebido < ValorProduto)
            {
                Console.WriteLine("O valor recebido foi menor do que o valor do produto!");
            }
            else if (ValorRecebido == ValorProduto)
            {
                Console.WriteLine("O valor está correto, não precisa de troco!");
            }
            else
            {
                //Percorrendo array de notas para fazer o cálculo
                foreach (var x in Notas)
                {
                    var notas = (int)(Troco / x);
                    if (notas > 0)
                    {
                        Troco -= Math.Round(notas * x, 2);
                        Console.WriteLine($"O troco deverá ser composto por {notas} nota(s) de {x}: totalizando {x * notas} real(s)");
                    }
                }

                //Percorrendo array de moedas para fazer o cálculo
                foreach (var y in Moedas)
                {
                    var notas = (int)(Troco / y);
                    if (notas > 0)
                    {
                        Troco -= Math.Round(notas * y, 2);
                        Console.WriteLine($"O troco deverá ser composto por {notas} moeda(s) de {y}: totalizando {y * notas} real(s)");
                    }
                }
            }
        }
    }
}
