
using TurismoApp.ViewModels;
using TurismoApp.Views;

namespace TurismoApp
{
    public partial class TurismoShell : Shell
    {
        public TurismoShell()
        {
            InitializeComponent();
            FlyoutItemsPrincipal.IsVisible = false; ;  // Oculta el menú lateral
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            //Registrar ruta de registro y acceso
            Routing.RegisterRoute("Registrarse", typeof(RegistrarseView));

            // Registrar la ruta de AddEditDestination
            Routing.RegisterRoute("AddEditDestination", typeof(AddEditDestinoView));

            // Asegúrate de registrar también la ruta de DestinationList
            Routing.RegisterRoute("DestinationList", typeof(DestinoView));
        }

        public void EnableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Flyout; // Habilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = true; // Muestra el menú lateral
            Shell.Current.GoToAsync("//MainPage"); // Navega a la página principal
            var viewmodel = this.BindingContext as TurismoShellViewModel;
            viewmodel.IsUserLogout = false;
        }
        public void DisableAppAfterLogin()
        {
            FlyoutBehavior = FlyoutBehavior.Disabled; // Deshabilita el FlyOut
            FlyoutItemsPrincipal.IsVisible = false; // Oculta el menú lateral
            Shell.Current.GoToAsync("//Login"); // Navega a la página de login
        }
    }
}
