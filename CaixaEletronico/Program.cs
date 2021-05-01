using System;
//https://dojopuzzles.com/problems/caixa-eletronico/
namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            try // tratamento de erros gerais
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("------ Caixa Eletrônico ------");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Notas disponiveis para saque: ");
                Console.WriteLine("R$ 100,00");
                Console.WriteLine("R$ 50,00");
                Console.WriteLine("R$ 20,00");
                Console.WriteLine("R$ 10,00");
                Console.WriteLine("------------------------------");
                Console.Write("Digite o Valor a ser sacado: ");
                double valor = double.Parse(Console.ReadLine()); // variavel que guardara o valor a ser sacado

                while (valor % 10 != 0) //verifica se a variavel contem um valor que é divisor de 10
                {
                    Console.WriteLine("\nO valor digitador deve ser divisor de 10");
                    Console.Write("Digite o Valor a ser sacado: ");
                    valor = double.Parse(Console.ReadLine());
                }

                int qtdNotas; // para verificar a qtd notas a serem usadas

                qtdNotas = (int)valor / 100; // conta as notas de 100 reais a serem usadas
                if (qtdNotas != 0) // para imprimir a saida apenas se tiver nota de 100 reais
                    Console.WriteLine(qtdNotas + " notas de R$ 100,00");
                valor = valor - qtdNotas * 100; // retira o valor ja "sacado"

                qtdNotas = (int)valor / 50; // conta as notas de 50 reais a serem usadas
                if (qtdNotas != 0) // para imprimir a saida apenas se tiver nota de 50 reais
                    Console.WriteLine(qtdNotas + " notas de R$ 50,00");
                valor = valor - qtdNotas * 50; // retira o valor ja "sacado"

                qtdNotas = (int)valor / 20; // conta as notas de 20 reais a serem usadas
                if (qtdNotas != 0) // para imprimir a saida apenas se tiver nota de 20 reais
                    Console.WriteLine(qtdNotas + " notas de R$ 20,00");
                valor = valor - qtdNotas * 20; // retira o valor ja "sacado"

                qtdNotas = (int)valor / 10; // conta as notas de 10 reais a serem usadas
                if (qtdNotas != 0) // para imprimir a saida apenas se tiver nota de 10 reais
                    Console.WriteLine(qtdNotas + " notas de R$ 10,00");
                valor = valor - qtdNotas * 10; // retira o valor ja "sacado"
            }
            catch // caso de erro
            {
                Console.WriteLine("Dados informador invalidos!!"); 
            }
        }
    }
}
