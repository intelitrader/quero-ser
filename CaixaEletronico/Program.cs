using System;
using System.Threading;

namespace CaixaEletronico
{
    class Program
    {
        static void Main(string[] args)
        {

            // Desafio reaizado por Fernando V C Araujo
            
            // Calcular a menor quantidade de notas para efetuar o saque
            void FazerSaque(){
                int valorTotal = Int32.Parse(Console.ReadLine());

                // Verifica se o saldo é um numero superior a 0
                if(valorTotal <= 0){
                    Console.WriteLine("Seu saldo está negativo ou é igual a zero. Não há como sacar!");
                    Environment.Exit(0);
                }
                // Se saldo é positivo, realiza o cálculo
                else{ 

                    // Simula tempo de espera para contagem das notas    
                    Console.WriteLine("aguarde a contagem das notas... \n");
                    Thread.Sleep(5000);

                    int nota100 = valorTotal/100;
                    valorTotal = valorTotal - nota100 * 100;

                    int nota50 =  valorTotal/50;
                    valorTotal = valorTotal - nota50 * 50;
                        
                    int nota20 = valorTotal/20;
                    valorTotal = valorTotal - nota20 * 20;
                        
                    int nota10 = valorTotal/10;
                    valorTotal = valorTotal - nota10 * 10;

                    // Exibe a quantidade de notas entregues       
                    Console.Write($"{nota100} notas de R$100 \n");
                    Console.Write($"{nota50} notas de R$50 \n");
                    Console.Write($"{nota20} notas de R$20 \n");
                    Console.Write($"{nota10} notas de R$10 \n");                

                    // Exibe valor em saldo que não foi possível sacar
                    Console.Write($"Valor restante R${valorTotal},00 \n\n");
                }
            }

            // Entrada padrão para continuar o processo
            string continuarSaque = "S";

            // Estrutura de repetição do saque
            while(continuarSaque.Equals("S")){
                Console.Clear();
                
                // Boas vindas do sistema
                Console.WriteLine("Caixa Eletrônico 24/7 \n");
                Console.Write("Seu saldo disponível para saque é de R$ ");
                
                // Cálculo
                FazerSaque();

                // Repetir o processo de saque
                Console.Write("Deseja realizar mais um saque (S/N)? \n");
                continuarSaque = Console.ReadLine().ToUpper();

                // Confirmar se a entrada é corresponde a S ou N, se não encerra o processo 
                if(continuarSaque != "N"){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAção Indisponível. Responda S para Sim e N para Não\n");
                Console.ResetColor();
                }
                
                // Encerra o processo 
                Console.WriteLine("O Caixa Eletrônico 24/7 agradece a sua preferência\n");
            }

        }
    }
}
