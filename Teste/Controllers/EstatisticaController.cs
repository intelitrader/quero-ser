using Teste.Models;
using Teste.Views;

namespace Teste.Controllers
{
    public class EstatisticaController
    {
        // Models
        EstatisticaModel estatistica = new EstatisticaModel();

        // Views
        EstatisticaView estatisticaView = new EstatisticaView();

        public void Estatistica()
        {
            estatisticaView.IntroducaoEstatistica();
            estatistica.Estatistica();
        }
    }
}