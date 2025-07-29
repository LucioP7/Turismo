using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using System.Net.Http.Headers;

namespace TourismApp.ViewModels
{
    public partial class RegistrarseViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private const string FirebaseApiKey = "AIzaSyCPZO7rfcyvcEQgDohrFeV69rqx043Sg6c";
        private const string RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

        public IRelayCommand RegistrarseCommand { get; }

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string mail;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string verifyPassword;

        public RegistrarseViewModel()
        {
            RegistrarseCommand = new RelayCommand(Registrarse);
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = "tourismarg.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }

        private async void Registrarse()
        {
            if (password != verifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Las contraseñas ingresadas no coinciden", "Ok");
                return;
            }

            try
            {
                var user = await _clientAuth.CreateUserWithEmailAndPasswordAsync(mail, password, nombre);
                await SendVerificationEmailAsync(user.User.GetIdTokenAsync().Result);
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Cuenta creada!", "Ok");
            }
            catch (FirebaseAuthException error) // Use alias here 
            {
                await Application.Current.MainPage.DisplayAlert("Registrarse", "Ocurrió un problema:" + error.Reason, "Ok");
            }
        }

        public static async Task SendVerificationEmailAsync(string idToken)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(RequestUri, content);
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
