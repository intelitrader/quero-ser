using System;
using Teste.Controllers;
using Teste.Views;
namespace Teste
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aqui está bem limpo né? Será que mais do que devia?

            HomeController homeController = new HomeController();
            homeController.Home();

            // Entregue o seu caminho ao Senhor; confie nele, e ele agirá.
            // Salmos 37:5
        }
    }
}
