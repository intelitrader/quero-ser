using Teste.Models;
using Teste.Views;

namespace Teste.Controllers
{
    public class FizzBuzzController
    {
        // Models
        FizzBuzzModel fizzBuzz = new FizzBuzzModel();

        // Views
        FizzBuzzView fizzBuzzView = new FizzBuzzView();

        public void FizzBuzz()
        {
            fizzBuzzView.IntroducaoFizzBuzz();
            fizzBuzz.FizzBuzz();
            // fizzBuzzView.FizzBuzzOperacao
        }
    }
}