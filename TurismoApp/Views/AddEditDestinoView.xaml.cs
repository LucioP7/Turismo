using TurismoServices.Models;
using TurismoApp.ViewModels;

namespace TurismoApp.Views;

[QueryProperty(nameof(Destino), "DestinoEdit")]
public partial class AddEditDestinoView : ContentPage
{
    public Destino Destino
    {
        set
        {
            var Destino = value;
            var viewModel = this.BindingContext as AddEditDestinoViewModel;
            viewModel.EditDestino = Destino;
        }
    }
    public AddEditDestinoView()
    {
        InitializeComponent();
    }

    public AddEditDestinoView(Destino DestinoEdit)
    {
        InitializeComponent();
        var viewModel = this.BindingContext as AddEditDestinoViewModel;
        viewModel.EditDestino = DestinoEdit;
    }
}
