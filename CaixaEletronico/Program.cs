using System;
using static System.Console;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine($"Bem-vindo ao Caixa Eletrônico.\n" +
                $"Digite 1 para sacar seu dinheiro ou outra tecla para sair.\n");

            int opUser = int.Parse(ReadLine());

            while (opUser == 1)
            {
                WriteLine("\nInsira o valor que deseja retirar.");
                int valorSaque = int.Parse(ReadLine());
                int printSaque = valorSaque;

                int cedulaCem = valorSaque / 100;
                int cedulaCinquenta = (valorSaque % 100) / 50;
                int cedulaVinte = (valorSaque % 100) % 50 / 20;
                int cedulaDez = (valorSaque % 100) % 50 % 20 / 10;
                int valor = valorSaque % 100 % 50 % 20 % 10;
                if (valor != 0)
                {
                    WriteLine("\nValor inválido! Informe um valor que possa ser entregue em:\n" +
                        "Cédulas de R$ 100,00, R$ 50,00, R$ 20,00 e R$ 10,00.");
                    opUser = 1;
                    continue;
                }
                WriteLine($"\nValor do saque: {printSaque}\n" +
                    $"Entregar {cedulaCem} nota(s) de 100\n" +
                    $"Entregar {cedulaCinquenta} notas(s) de 50\n" +
                    $"Entregar {cedulaVinte} notas(s) de 20\n" +
                    $"Entregar {cedulaDez} notas(s) de R$ 10,00;");

                WriteLine("\nDeseja sair realizar mais alguma operação?\n" +
                    "Digite 1 para continuar e outra tecla para sair.");
                opUser = int.Parse(ReadLine());
            }
            if (opUser != 1)
            {
                WriteLine("\nObrigado por usar nosso caixa eletrônico, volte sempre!");
            }

        }




    }
}
