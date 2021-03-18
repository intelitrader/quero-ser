using System;
//https://dojopuzzles.com/problems/troco/
namespace Troco
{
    class Program
    {
        static void Main(string[] args)
        {
            try // tratamento de erros gerais
            {
                double conta, valorPago;
                int[] notas = { 100, 50, 20, 10, 5, 2, 1 }; // colocando em um vetor as notas 
                int[] moedas = { 50, 25, 10, 5, 1 }; // colocando em um vetor as moedas

                Console.Write("Informe o valor da total a ser pago: ");
                conta = double.Parse(Console.ReadLine()); // entrando com o valor a ser pago
                Console.Write("Informe o valor efetivamente pago:  ");
                valorPago = double.Parse(Console.ReadLine()); // entrando com o valor realmente pago

                while (valorPago < conta) // verificando se o valor pago e maior que a conta, caso não seja tem que pagar um valor maior ou igual
                {
                    Console.WriteLine("Valor da Conta não pode ser menor que a conta");
                    Console.WriteLine("Considerando o valor da conta: " + conta);
                    Console.WriteLine("Digite novamente o valor a ser efetivamente pago: ");
                    valorPago = double.Parse(Console.ReadLine());
                }

                double troco = valorPago - conta; // verificando o troco
                string resultado; // variavel que guardara de fato as moedas e notas utilizadas
                int i = 0, valor, qtd; // variaveis para auxiliar a string resultado
                resultado = "Troco = R$ " + troco.ToString("F2") + "\n"; // variavel responsavel pela definição das notas que são necessarias para o troco
                Console.WriteLine(resultado);
                valor = (int)troco;

                while (valor != 0)
                {
                    qtd = valor / notas[i]; //contando a quantidade de notas usadas para o troco
                    if (qtd != 0)
                    {
                        resultado = resultado + (qtd + " notas de R$" + notas[i] + "\n"); // colocar na variavel as notas usadas
                        valor = valor % notas[i];
                    }
                    i = i + 1; // para saber qual nota
                }

                valor = (int)Math.Round((troco - (int)troco) * 100); // Para conseguir calcular as moedas a serem usadas

                i = 0; // resetar a variavel para verificar todas moedas
                while (valor != 0)
                {
                    qtd = valor / moedas[i]; //contando a quantidade de moedas usadas para o troco
                    if (qtd != 0)
                    {
                        resultado = resultado + (qtd + " moedas de " + moedas[i] + " centavos" + "\n");
                        valor = valor % moedas[i];
                    }
                    i = i + 1; // para saber qual moeda
                }

                Console.WriteLine(resultado); //Imprimindo o troco a ser concedido
            }
            catch // caso de erro
            {
                Console.WriteLine("Dados informados invalidos");
            }
        }
    }
}
