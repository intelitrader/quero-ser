using System;

namespace Troco
{
    class Program
    {
        static void Main(string[] args)
        {

            // Desafio reaizado por Fernando V C Araujo

            // Entrada padrão para continuar o processo
            string continuarVenda = "S";
            
            // Estrutura de repetição para a entrega do troco
            while(continuarVenda.Equals("S")){
                Console.Clear();

                Console.WriteLine("Mercearia do Sr. Fernando Araujo\n");
                
                // Entrada dos dados utilizando duas casas decimais após a virgula
                Console.Write("Qual o valor total da compra? R$");
                double valorCompra = Math.Round(Double.Parse(Console.ReadLine()), 2);

                Console.Write("Qual o valor pago? R$");
                double valorPago = Math.Round(Double.Parse(Console.ReadLine()), 2);
                
                // Calculo da diferença do valor total da compra do valor pago, igual ao troco
                double troco = Math.Round(valorPago - valorCompra, 2);

                // Verifica se há troco a devolver ao cliente
                // Também se o valor pago é realmente maior do que o valor total da compra,  
                if(troco < 0){
                    double valorACobrar = troco * -1;
                    
                    Console.WriteLine($"\nValor insuficiente para a compra! Cobre R${valorACobrar} do cliente");
                    Environment.Exit(0);
                }  

                // Exibe em verde o valor total do troco
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"\nO troco é de {troco.ToString("C")}");
                Console.ResetColor(); 
                
                // Calculo para distribuir a menor quantidade de notas e moedas possiveis no troco
                int nota100 = (int)(troco / 100);
                troco = troco - nota100 * 100;

                int nota50 = (int)(troco / 50);
                troco = troco - nota50 * 50;

                int nota10 = (int)(troco / 10);
                troco = troco - nota10 * 10;

                int nota5 = (int)(troco / 5);
                troco = troco - nota5 * 5;

                int nota1 = (int)(troco / 1);
                troco = troco - nota1 * 1;
                
                int moeda50 = (int)(troco / 0.50);
                troco = troco -  moeda50 * 0.5;
                
                int moeda10 = (int)(troco / 0.10);
                troco = troco - moeda10 * 0.1;
                
                int moeda5 = (int)(troco / 0.05);
                troco = troco - moeda5 * 0.05;

                // Exibe a quantidade de notas e moedas do troco
                Console.Write($"\n{nota100} notas de R$100\n");
                Console.Write($"{nota50} notas de R$50\n");
                Console.Write($"{nota10} notas de R$10\n");
                Console.Write($"{nota5} notas de R$5\n");
                Console.Write($"{nota1} notas de R$1\n");
                Console.Write($"{moeda50} moeda de R$0.50\n");
                Console.Write($"{moeda10} moeda de R$0.10\n");
                Console.Write($"{moeda5} moeda de R$0.05 \n");

                // Repetir o processo de entrega de troco
                Console.Write("\nDeseja continuar (S/N)? ");
                continuarVenda = Console.ReadLine().ToUpper();

                // Confirmar se a entrada é corresponde a S ou N, se não encerra o processo
                if(continuarVenda != "N"){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nAção Indisponível. Responda S para Sim e N para Não\n");
                Console.ResetColor();
                }
            }
        }
    }
}
