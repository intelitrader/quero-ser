using Teste.Models;
using Teste.Views;

namespace Teste.Controllers
{
    public class FizzBuzzController
    {
        // Models
        FizzBuzzModel fizzBuzzModel = new FizzBuzzModel();

        // Views
        FizzBuzzView fizzBuzzView = new FizzBuzzView();

        public void FizzBuzz()
        {
            fizzBuzzView.IntroducaoFizzBuzz();
            fizzBuzzModel.FizzBuzz();
        }
    }
}