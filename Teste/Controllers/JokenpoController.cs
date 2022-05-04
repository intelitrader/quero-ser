using Teste.Models;
using Teste.Views;

namespace Teste.Controllers
{
    public class JokenpoController
    {
        // Models
        JokenpoModel jokenpo = new JokenpoModel();

        // Views
        JokenpoView jokenpoView = new JokenpoView();

        public void Jokenpo()
        {
            jokenpoView.IntroducaoJokenpo();
            jokenpo.Jokenpo();
            // jokenpoView.Operacao();
        }
    }
}