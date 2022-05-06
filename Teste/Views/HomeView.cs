using System;

namespace Teste.Views
{
    public class HomeView
    {
        public void Introducao()
        {
            Console.WriteLine("Seja bem-vindo caro avaliador.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Essa mini aplicação contém os três testes a minha escolha que foram pedidos como forma de avaliação, sendo eles: Jokenpo, FizzBuzz e Estatísticas.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Sinta-se à vontade para testar e olhar o código como quiser! :)");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine($"");
            

            Console.WriteLine("Por qual deseja começar?");
            Console.WriteLine("[1] Jokenpo");
            Console.WriteLine("[2] FizzBuzz");
            Console.WriteLine("[3] Estatísticas");
            Console.WriteLine("[0] Sair");
            Console.Write("[#]: ");
        }
    }
}