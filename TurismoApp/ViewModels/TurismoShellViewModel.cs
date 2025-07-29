using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TurismoApp;

namespace TurismoApp.ViewModels
{
    public partial class TurismoShellViewModel : ObservableObject
    {
        public IRelayCommand LogoutCommand { get; }

        [ObservableProperty]
        private bool isUserLogout = true;

        public TurismoShellViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Logout()
        {
            isUserLogout = true;
            (App.Current.MainPage as TurismoShell).DisableAppAfterLogin();
        }
    }
}
