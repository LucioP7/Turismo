using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;

namespace TurismoApp.ViewModels
{
    public partial class IniciarSesionViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string mail;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(LoginCommand))]
        private string password;

        [ObservableProperty]
        private bool rememberPassword;

        public IRelayCommand LoginCommand { get; }
        public IRelayCommand RegisterCommand { get; }

        public IniciarSesionViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyCPZO7rfcyvcEQgDohrFeV69rqx043Sg6c",
                AuthDomain = "tourismarg.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("Clinica");
            ChequearSiHayUsuarioAlmacenado();
            LoginCommand = new RelayCommand(Login, AllowLogin);
            RegisterCommand = new RelayCommand(Register);
        }

        private async void Register()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        private void ChequearSiHayUsuarioAlmacenado()
        {
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                var tourismShell = (TurismoShell)App.Current.MainPage;
                tourismShell.EnableAppAfterLogin();
            }
        }

        public bool AllowLogin() => !string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(password);

        public async void Login()
        {
            try
            {
                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(mail, password);
                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    return;
                }

                if (rememberPassword)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                var tourismShell = (TurismoShell)App.Current.MainPage;
                tourismShell.EnableAppAfterLogin();

            }
            catch (FirebaseAuthException error)
            {
                await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema:" + error.Reason, "Ok");

             }
        }
    }
}
