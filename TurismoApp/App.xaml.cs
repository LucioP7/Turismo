using TurismoApp.Views;
using TurismoApp.ViewModels;

namespace TurismoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TurismoShell();
        }
    }
}
