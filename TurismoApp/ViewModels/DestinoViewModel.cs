using System.Collections.ObjectModel;
using System.Diagnostics;
using TurismoApp.Class;
using TurismoServices.Interfaces;
using TurismoServices.Models;
using TurismoServices.Services;

namespace TurismoApp.ViewModels
{
    public class DestinoViewModel : ObjectNotification
    {
        GenericService<Destino> destinoservice = new GenericService<Destino>();

        private string filtroDestino;
        public string FiltroDestino
        {
            get { return filtroDestino; }
            set
            {
                filtroDestino = value;
                OnPropertyChanged();
                Filtrodestinos();
            }
        }

        private bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        ObservableCollection<Destino> destinos;
        public ObservableCollection<Destino> Destinos
        {
            get { return destinos; }
            set
            {
                destinos = value;
                OnPropertyChanged();
            }
        }

        public List<Destino>? listaDestinoFiltro;

        private Destino destinoselected;
        public Destino Destinoselected
        {
            get { return destinoselected; }
            set
            {
                destinoselected = value;
                OnPropertyChanged();
                ActualizarDestinoCommand.ChangeCanExecute();
                EliminarDestinoCommand.ChangeCanExecute();
            }
        }

        public Command ObtenerdestinosCommand { get; }
        public Command filtroDestinosCommand { get; }
        public Command AddDestinoCommand { get; }
        public Command ActualizarDestinoCommand { get; }
        public Command EliminarDestinoCommand { get; }

        public DestinoViewModel()
        {
            ObtenerdestinosCommand = new Command(async () => await Obtenerdestinos());
            filtroDestinosCommand = new Command(async () => await Filtrodestinos());
            AddDestinoCommand = new Command(async () => await AddDestino());
            ActualizarDestinoCommand = new Command(async (obj) => await ActualizarDestinos(), AllowEdit);
            EliminarDestinoCommand = new Command(async (obj) => await EliminarDestinos(), AllowEdit);
            Obtenerdestinos();
        }

        private bool AllowEdit(object arg)
        {
            return destinoselected != null;
        }

        private async Task ActualizarDestinos()
        {
            if (destinoselected == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "No hay destino seleccionado para actualizar.", "OK");
                return;
            }

            var navigationParameter = new Dictionary<string, object>
            {
                { "DestinationEdit", destinoselected }
            };
            await Shell.Current.GoToAsync("AddEditDestination", navigationParameter);
        }

        private async Task EliminarDestinos()
        {
            var confirmacion = await App.Current.MainPage.DisplayAlert("Eliminar Destino", "¿Está seguro que desea eliminar el Destino?", "Si", "No");
            if (confirmacion)
            {
                await destinoservice.DeleteAsync(destinoselected.Id);
                destinoselected = null;
                await Obtenerdestinos();
            }
        }

        private async Task AddDestino()
        {
            var navigationParameter = new ShellNavigationQueryParameters
            {
                { "DestinoEdit", null } // Asegúrate de que esto no sea null
            };
            await Shell.Current.GoToAsync("AddEditDestino", navigationParameter);
        }

        private async Task Filtrodestinos()
        {
            var destinoFiltro = listaDestinoFiltro.Where(p => p.Nombre.ToLower().Contains(filtroDestino.ToLower())).ToList();
            destinos = new ObservableCollection<Destino>(destinoFiltro);
        }

        public async Task Obtenerdestinos()
        {
            filtroDestino = string.Empty;
            IsRefreshing = true;
            try
            {
                listaDestinoFiltro = await destinoservice.GetAllAsync();
                if (listaDestinoFiltro == null)
                {
                    Debug.Print("No se encontraron destinos.");
                    destinos = new ObservableCollection<Destino>();
                }
                else
                {
                    destinos = new ObservableCollection<Destino>(listaDestinoFiltro);
                    Debug.Print($"Destinos cargados: {destinos.Count}");
                    foreach (var destination in destinos)
                    {
                        Debug.Print(destination.Nombre);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"Error al obtener destinos: {ex.Message}");
                destinos = new ObservableCollection<Destino>();
            }
            finally
            {
                IsRefreshing = false;
            }
        }
    }
}
