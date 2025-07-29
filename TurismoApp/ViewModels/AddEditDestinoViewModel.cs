using System.Collections.ObjectModel;
using TurismoApp.Class;
using TurismoServices.Models;
using TurismoServices.Services;

namespace TurismoApp.ViewModels
{
    public class AddEditDestinoViewModel : ObjectNotification
    {
        private readonly GenericService<Destino> destinoService = new GenericService<Destino>();
        private readonly GenericService<Itinerario> itinerarioService = new GenericService<Itinerario>();

        #region Propiedades

        private Destino editDestino;
        public Destino EditDestino
        {
            get { return editDestino; }
            set
            {
                editDestino = value;
                OnPropertyChanged();
                // Si las listas ya están cargadas, llama a SettingData.
                if (ListaItinerarios != null && ListaItinerarios.Any())
                {
                    SettingData();
                }
            }
        }

        private void SettingData()
        {
            if (editDestino != null)
            {
                Nombre = editDestino.Nombre;
                Descripcion = editDestino.Descripcion;
                URLImage = editDestino.URL_image;
                Categoria = editDestino.Categoria;
                Pais = editDestino.Pais;
                Eliminado = editDestino.Eliminado;

                ItinerarioSelected = ListaItinerarios?.FirstOrDefault(i => i.Id == IdItinerario);
            }
            else
            {
                Nombre = string.Empty;
                Descripcion = string.Empty;
                URLImage = string.Empty;
                Categoria = string.Empty;
                Pais = string.Empty;
                IdItinerario = null;
                ItinerarioSelected = null;
                Eliminado = false;
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged();
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return Descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged();
            }
        }

        private string urlImage;
        public string URLImage
        {
            get { return urlImage; }
            set
            {
                urlImage = value;
                OnPropertyChanged();
            }
        }

        private string categoria;
        public string Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged();
            }
        }

        private string pais;
        public string Pais
        {
            get { return pais; }
            set
            {
                pais = value;
                OnPropertyChanged();
            }
        }

        private bool eliminado;
        public bool Eliminado
        {
            get { return eliminado; }
            set
            {
                eliminado = value;
                OnPropertyChanged();
            }
        }

        private int? idItinerario;
        public int? IdItinerario
        {
            get { return idItinerario; }
            set
            {
                idItinerario = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Itinerario> listaItinerarios = new ObservableCollection<Itinerario>();
        public ObservableCollection<Itinerario> ListaItinerarios
        {
            get { return listaItinerarios; }
            set
            {
                listaItinerarios = value;
                OnPropertyChanged();
            }
        }

        private Itinerario itinerarioSelected;
        public Itinerario ItinerarioSelected
        {
            get { return itinerarioSelected; }
            set
            {
                itinerarioSelected = value;
                OnPropertyChanged();

                // Actualiza el ID del itinerario seleccionado
                if (itinerarioSelected != null)
                {
                    IdItinerario = itinerarioSelected.Id;
                }
            }
        }

        #endregion

        #region Commands
        public Command GuardarDestinoCommand { get; }
        public Command AtrasCommand { get; }
        #endregion

        // Plan paso a paso (pseudocódigo):
        // 1. Cambiar el constructor a 'public AddEditDestinoViewModel' (corregir el nombre y el tipo de retorno, problema CS1520)
        // 2. Inicializar todos los campos no anulables en el constructor para evitar CS8618
        // 3. Hacer que la llamada a LoadItinerarios sea awaitable en el constructor (problema CS4014)
        // 4. El constructor no puede ser async, así que usar una función InitAsync y llamarla desde la vista, o ignorar el warning y documentar el motivo
        // 5. Corregir el nombre del constructor para que coincida con el nombre de la clase
        // 6. Inicializar los campos: editDestino, nombre, descripcion, urlImage, categoria, pais, itinerarioSelected

        public AddEditDestinoViewModel()
        {
            GuardarDestinoCommand = new Command(async () => await SaveDestino());
            AtrasCommand = new Command(async () => await IrAtrasToList());

            // Inicializa los campos no anulables
            editDestino = null!;
            nombre = string.Empty;
            descripcion = string.Empty;
            urlImage = string.Empty;
            categoria = string.Empty;
            pais = string.Empty;
            itinerarioSelected = null!;

            // Inicializa la colección de itinerarios
            ListaItinerarios = new ObservableCollection<Itinerario>();
            // No se puede usar await en el constructor, así que se ignora el warning CS4014
            _ = LoadItinerarios();
        }

        private async Task LoadItinerarios()
        {
            try
            {
                var itinerarios = await itinerarioService.GetAllAsync();
                ListaItinerarios = new ObservableCollection<Itinerario>(itinerarios);

                if (editDestino != null)
                {
                    SettingData();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudieron cargar los datos: {ex.Message}", "OK");
            }
        }

        private async Task SaveDestino()
        {
            if (editDestino != null)
            {
                editDestino.Nombre = Nombre;
                editDestino.Descripcion = Descripcion;
                editDestino.URL_image = URLImage;
                editDestino.Categoria = Categoria;
                editDestino.Pais = Pais;

                editDestino.Eliminado = Eliminado;

                await destinoService.UpdateAsync(editDestino);
            }
            else
            {
                var destino = new Destino()
                {
                    Nombre = Nombre,
                    Descripcion = Descripcion,
                    URL_image = URLImage,
                    Categoria = Categoria,
                    Pais = Pais,
                    Eliminado = Eliminado
                };

                await destinoService.AddAsync(destino);
            }

            await IrAtrasToList();
        }

        private async Task IrAtrasToList()
        {
            editDestino = null;
            await Shell.Current.GoToAsync("/DestinoLista");
        }
    }
}
