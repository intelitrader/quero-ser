using Teste.Models;
using Teste.Views;

namespace Teste.Controllers
{
    public class HomeController
    {   
        // Models
        HomeModel homeModel = new HomeModel();

        // Views
        HomeView homeView = new HomeView();

        public void Home()
        {
            homeView.Introducao();
            homeModel.Aplicacao();
        }
    }
}