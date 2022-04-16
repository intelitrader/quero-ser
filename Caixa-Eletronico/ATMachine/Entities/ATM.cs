using System;
using ATMachine.Entities.Cedulas;
using ATMachine.Services;

namespace ATMachine.Entities
{
    public class ATM
    {
        public int valorDisponivel = 0;
        public int EntregarNotas10 = 0;
        public int EntregarNotas20 = 0;
        public int EntregarNotas50 = 0;
        public int EntregarNotas100 = 0;

        NotaDe10 nota10 = new NotaDe10();
        NotaDe20 nota20 = new NotaDe20();
        NotaDe50 nota50 = new NotaDe50();
        NotaDe100 nota100 = new NotaDe100();

        public void AtualizarValorDisponivel()
        {
            valorDisponivel = nota10.Valor * nota10.quantidade + nota20.Valor * nota20.quantidade + nota50.Valor * nota50.quantidade + nota100.Valor * nota100.quantidade;
        }
        public void Saque(int valorDeSaque)
        {
            AtualizarValorDisponivel();
            int restante = valorDeSaque;

            if (valorDeSaque <= valorDisponivel)
            {

                while (restante != 0)
                {
                    if (restante >= 100 && nota100.quantidade > 0)
                    {
                        nota100.quantidade -= 1;
                        restante -= 100;
                        EntregarNotas100++;
                    }

                    else if (restante >= 50 && nota50.quantidade > 0)
                    {
                        nota50.quantidade -= 1;
                        restante -= 50;
                        EntregarNotas50++;
                    }

                    else if (restante >= 20 && nota20.quantidade > 0)
                    {
                        nota20.quantidade -= 1;
                        restante -= 20;
                        EntregarNotas20++;
                    }

                    else if (restante >= 10 && nota10.quantidade > 0)
                    {
                        nota10.quantidade -= 1;
                        restante -= 10;
                        EntregarNotas10++;
                    }

                    else
                    {
                        Console.WriteLine("Valor Inválido");
                    }
                }

                PrintService print = new PrintService();
                print.PrintNotas(EntregarNotas100, EntregarNotas50, EntregarNotas20, EntregarNotas10);
            }

            else
            {
                Console.WriteLine("Valor Indisponível no Caixa");
            }
        }
    }
}