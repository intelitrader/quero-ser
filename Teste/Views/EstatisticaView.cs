using System;

namespace Teste.Views
{
    public class EstatisticaView
    {
        public void IntroducaoEstatistica()
        {
            Console.WriteLine($"Olá, bem-vindo ao exercício de estatística.");
            Console.WriteLine($"Aqui a minha tarefa é processar uma seqüência de números inteiros para determinar as seguintes estatísticas: \n Valor mínimo \n Valor máximo \n Número de elementos na seqüência \n Valor médio");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"Por exemplo para uma seqüência de números: 6; 9; 15; -2; 92; 11. Temos como saída:");
            Console.WriteLine(" Valor mínimo: -2 \n Valor máximo: 92 \n Número de elementos na seqüência: 6 \n Valor médio: 18.1666666");
            System.Threading.Thread.Sleep(1000);

            Console.WriteLine($"Agora vamos testar! Digite uma sequência de números, separando eles através de ponto e vírgula, por exemplo: 1; 3; -10; 6; 15; -47");
            Console.Write("[#]: ");
            
        }
    }
}