using System;
using Teste.Controllers;

namespace Teste.Models
{
    public class HomeModel
    {
        public int escolhaAvaliador { get; set; }
        
        public void Aplicacao()
        {
            escolhaAvaliador = int.Parse(Console.ReadLine());
            
            switch (escolhaAvaliador)
            {
                case 0:
                {
                    Console.Clear();
                    Console.WriteLine("Obrigado por testar!");
                    
                }
                break;

                case 1:
                {
                    JokenpoController jokenpoController = new JokenpoController();
                    jokenpoController.Jokenpo();
                }
                break;

                case 2:
                {
                    FizzBuzzController fizzBuzzController = new FizzBuzzController();
                    fizzBuzzController.FizzBuzz();
                }
                break;

                case 3:
                {
                    EstatisticaController estatisticaController = new EstatisticaController();
                    estatisticaController.Estatistica();
                }
                break;
                default:
                    break;  
            }
        }
    }
}