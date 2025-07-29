using TurismoApp.ViewModels;

namespace TurismoApp.Views
{
    public partial class DestinoView : ContentPage
    {

        public DestinoView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewmodel = this.BindingContext as DestinoViewModel;
            if (viewmodel != null)
            {
                viewmodel.Obtenerdestinos();
                viewmodel.Destinoselected = null;
            }
        }
    }
}
