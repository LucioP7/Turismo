using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using TurismoServices.Interfaces;
using TurismoServices.Models;
using TurismoServices.Services;

namespace TurismoDesktop.Views
{
    public partial class DestinoView : Form
    {
        private readonly IGenericService<Destino> destinoService = new GenericService<Destino>();
        private readonly IGenericService<Itinerario> itinerarioService = new GenericService<Itinerario>();

        private BindingSource ListaDestino = new BindingSource();
        private List<Destino> FiltroLista = new List<Destino>();
        private Destino? DestinoCurrent;

        public DestinoView()
        {
            InitializeComponent();
            dataGridDestinoView.DataSource = ListaDestino;

            // Cargar datos cuando el formulario esté listo
            this.Load += async (s, e) => await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadGrid();
            await LoadComboBox();
        }

        private async Task LoadComboBox()
        {
            var itinerarios = await itinerarioService.GetAllAsync(string.Empty);

            CBoxItinerario.DataSource = itinerarios;
            CBoxItinerario.DisplayMember = "Nombre";
            CBoxItinerario.ValueMember = "Id";

            if (itinerarios?.Count > 1)
                CBoxItinerario.SelectedIndex = 1;
            else if (itinerarios?.Count > 0)
                CBoxItinerario.SelectedIndex = 0;
        }

        private async Task LoadGrid()
        {
            var destinos = await destinoService.GetAllAsync(string.Empty);
            var lista = destinos?.Where(d => !d.Eliminado).ToList() ?? new List<Destino>();

            ListaDestino.DataSource = lista;
            FiltroLista = lista;
            dataGridDestinoView.Columns[0].Visible = false;
            dataGridDestinoView.Columns[5].Visible = false;
            dataGridDestinoView.Columns[6].Visible = false;
            dataGridDestinoView.Columns[7].Visible = false;
            dataGridDestinoView.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DestinoCurrent = (Destino)ListaDestino.Current;

            if (DestinoCurrent != null)
            {
                txtNombre.Text = DestinoCurrent.Nombre;
                txtDescripcion.Text = DestinoCurrent.Descripcion;
                txtUrl.Text = DestinoCurrent.URL_image;
                txtCategoria.Text = DestinoCurrent.Categoria;
                txtPais.Text = DestinoCurrent.Pais;

                // Cargar el itinerario seleccionado en el ComboBox (si tiene uno asociado)
                if (DestinoCurrent.Itinerario != null && DestinoCurrent.Itinerario.Any())
                    CBoxItinerario.SelectedValue = DestinoCurrent.Itinerario.First().Id;

                tabControl1.SelectedTab = tabPageAddEdit;
            }
            else
            {
                MessageBox.Show("Seleccione un destino para modificar.");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListaDestino.Current is Destino destino)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este destino?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    destino.Eliminado = true; // Marcar como eliminado
                    await destinoService.UpdateAsync(destino); // Actualizar el destino
                    await LoadGrid(); // Recargar la lista
                }
            }
            else
            {
                MessageBox.Show("Seleccione un destino para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtCategoria.Text = string.Empty;
            txtPais.Text = string.Empty;
            DestinoCurrent = null;

            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int? IdItinerario = (int?)CBoxItinerario.SelectedValue;
            var itinerarioSeleccionado = CBoxItinerario.SelectedItem as Itinerario;


            var destino = new Destino()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                URL_image = txtUrl.Text,
                Categoria = txtCategoria.Text,
                Pais = txtPais.Text,
                Itinerario = IdItinerario.HasValue
                    ? new List<Itinerario>
                      {
              new Itinerario
              {
                  Id = IdItinerario.Value,
                  Nombre = itinerarioSeleccionado?.Nombre
              }
                      }
                    : new List<Itinerario>(),
                Eliminado = false
            };

            //var json = JsonSerializer.Serialize(destino, new JsonSerializerOptions { WriteIndented = true });
            //MessageBox.Show(json);


            if (DestinoCurrent != null)
            {
                destino.Id = DestinoCurrent.Id;
                await destinoService.UpdateAsync(destino);
                MessageBox.Show("Destino modificado correctamente.");
            }
            else
            {
                await destinoService.AddAsync(destino);
                MessageBox.Show("Destino agregado correctamente.");
            }

            await LoadGrid();
            tabControl1.SelectedTab = tabPageAddEdit; // Cambia a la pestaña de lista después de guardar
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Operación cancelada");
            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            var filtroDestino = FiltroLista
                .Where(d => d.Nombre.Contains(txtFiltro.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ListaDestino.DataSource = filtroDestino;
            dataGridDestinoView.Refresh();
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Forms;
//using TurismoServices.Interfaces;
//using TurismoServices.Models;
//using TurismoServices.Services;

//namespace TurismoDesktop.Views
//{
//    public partial class DestinoView : Form
//    {
//        IDestinoService destinoService = new DestinoService();
//        IItinerarioService itinerarioService = new ItinerarioService();

//        BindingSource ListaDestino = new BindingSource();
//        List<Destino> FiltroLista = new List<Destino>();
//        Destino? DestinoCurrent;

//        public DestinoView()
//        {
//            InitializeComponent();
//            dataGridDestinoView.DataSource = ListaDestino;
//            this.Load += async (s, e) => await LoadDataAsync();
//        }

//        private async Task LoadDataAsync()
//        {
//            await LoadGrid();
//            await LoadComboBox();
//        }

//        private async Task LoadComboBox()
//        {
//            CBoxItinerario.DataSource = await itinerarioService.GetAllAsync();
//            CBoxItinerario.DisplayMember = "Nombre";
//            CBoxItinerario.ValueMember = "Id";
//            CBoxItinerario.SelectedIndex = 0;
//        }

//        private async Task LoadGrid()
//        {
//            var destinos = await destinoService.GetAllAsync(string.Empty);
//            ListaDestino.DataSource = destinos?.Where(d => !d.Eliminado).ToList();
//            FiltroLista = (List<Destino>)ListaDestino.DataSource;
//            //dataGridDestinoView.Columns[0].Visible = false;
//            //dataGridDestinoView.Columns[5].Visible = false;
//            //dataGridDestinoView.Columns[6].Visible = false;
//        }

//        private void btnSalir_Click(object sender, EventArgs e)
//        {
//            this.Close();
//        }

//        private void btnModificar_Click(object sender, EventArgs e)
//        {
//            DestinoCurrent = (Destino)ListaDestino.Current;
//            if (DestinoCurrent != null)
//            {
//                txtNombre.Text = DestinoCurrent.Nombre;
//                txtDescripcion.Text = DestinoCurrent.Descripcion;
//                txtUrl.Text = DestinoCurrent.URL_image;
//                txtCategoria.Text = DestinoCurrent.Categoria;
//                txtPais.Text = DestinoCurrent.Pais;
//                // Cargar el itinerario seleccionado en el ComboBox
//                CBoxItinerario.SelectedValue = DestinoCurrent.Itinenario;
//                tabPageList.SelectTab(tabPageAddEdit);
//            }
//            else
//            {
//                MessageBox.Show("Seleccione un destino para modificar.");
//            }
//        }

//        private void btnEliminar_Click(object sender, EventArgs e)
//        {
//            if (ListaDestino.Current is Destino destino)
//            {
//                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este destino?", "Confirmación de eliminación", MessageBoxButtons.YesNo);
//                if (confirmResult == DialogResult.Yes)
//                {
//                    destino.Eliminado = true; // Marcar como eliminado
//                    destinoService.UpdateAsync(destino).Wait(); // Actualizar el destino
//                    LoadGrid(); // Recargar la lista
//                }
//            }
//            else
//            {
//                MessageBox.Show("Seleccione un destino para eliminar.");
//            }
//        }

//        private void btnAgregar_Click(object sender, EventArgs e)
//        {
//            txtNombre.Text = string.Empty;
//            txtDescripcion.Text = string.Empty;
//            txtUrl.Text = string.Empty;
//            txtCategoria.Text = string.Empty;
//            txtPais.Text = string.Empty;
//            tabPageList.SelectTab(tabPageAddEdit);
//        }

//        private async void btnGuardar_Click(object sender, EventArgs e)
//        {
//            int? IdItinerario = (int?)CBoxItinerario.SelectedValue;

//            var destino = new Destino()
//            {
//                Nombre = txtNombre.Text,
//                Descripcion = txtDescripcion.Text,
//                URL_image = txtUrl.Text,
//                Categoria = txtCategoria.Text,
//                Pais = txtPais.Text,
//                Itinenario = IdItinerario.HasValue ? new List<Itinerario> { new Itinerario { Id = IdItinerario.Value } } : new List<Itinerario>(),
//                Eliminado = false,
//            };

//            if (DestinoCurrent != null)
//            {
//                destino.Id = DestinoCurrent.Id;
//                destinoService.UpdateAsync(destino).Wait();
//                MessageBox.Show("Destino modificado correctamente.");
//            }
//            else
//            {
//                destinoService.AddAsync(destino).Wait();
//                MessageBox.Show("Destino agregado correctamente.");
//            }

//            LoadGrid(); // Quitar await, ya que el método es void
//            tabPageList.SelectTab(tabPageList.SelectedIndex); // Usar SelectedIndex para cambiar de pestaña
//        }

//        private void btnCancelar_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show("Operación cancelada");
//            tabPageList.SelectTab(tabPageList.SelectedIndex);
//        }

//        private void txtFiltro_TextChanged(object sender, EventArgs e)
//        {
//            var filtroDestino = FiltroLista.Where(d => d.Nombre.Contains(txtFiltro.Text, StringComparison.OrdinalIgnoreCase)).ToList();
//            ListaDestino.DataSource = filtroDestino;
//            dataGridDestinoView.DataSource = ListaDestino;
//            // Actualizar la fuente de datos del DataGridView
//            dataGridDestinoView.Refresh(); // Refrescar el DataGridView para mostrar los cambios
//        }
//    }
//}
