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
    public partial class ItinerarioView : Form
    {
        private readonly IGenericService<Itinerario> itinerarioService = new GenericService<Itinerario>();
        private readonly IGenericService<Destino> destinoService = new GenericService<Destino>();

        private BindingSource ListaItinerario = new BindingSource();
        private List<Itinerario> FiltroLista = new List<Itinerario>();

        private Itinerario? ItinerarioCurrent;

        public ItinerarioView()
        {
            InitializeComponent();
            dataGridItinerarioView.DataSource = ListaItinerario;

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
            var destinos = await destinoService.GetAllAsync(string.Empty);

            CBoxDestino.DataSource = destinos;
            CBoxDestino.DisplayMember = "Nombre";
            CBoxDestino.ValueMember = "Id";

            if (destinos?.Count > 1)
                CBoxDestino.SelectedIndex = 1;
            else if (destinos?.Count > 0)
                CBoxDestino.SelectedIndex = 0;
        }

        private async Task LoadGrid()
        {
            var Itinerario = await itinerarioService.GetAllAsync(string.Empty);
            var lista = Itinerario?.Where(d => !d.Eliminado).ToList() ?? new List<Itinerario>();

            ListaItinerario.DataSource = lista;
            FiltroLista = lista;

            dataGridItinerarioView.Columns[0].Visible = false;
            dataGridItinerarioView.Columns[5].Visible = false;
            dataGridItinerarioView.Columns[7].Visible = false;
            //dataGridItinerarioView.Columns[4].DefaultCellStyle.Format = "n2";
            dataGridItinerarioView.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ItinerarioCurrent = (Itinerario)ListaItinerario.Current;

            if (ItinerarioCurrent != null)
            {
                txtNombre.Text = ItinerarioCurrent.Nombre;
                txtDescripcion.Text = ItinerarioCurrent.Descripcion;
                dtpInicio.Value = ItinerarioCurrent.FechaInicio;
                dtpFin.Value = ItinerarioCurrent.FechaFin;
                
                tabControl1.SelectedTab = tabPageAddEdit;
            }
            else
            {
                MessageBox.Show("Seleccione una Itinerario para modificar.");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListaItinerario.Current is Itinerario Itinerario)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar esta Itinerario?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    Itinerario.Eliminado = true; // Marcar como eliminado
                    await itinerarioService.UpdateAsync(Itinerario); // Actualizar el destino
                    await LoadGrid(); // Recargar la lista
                }
            }
            else
            {
                MessageBox.Show("Seleccione una Itinerario para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;
            CBoxDestino.SelectedIndex = 1;

            tabControl1.SelectedTab = tabPageAddEdit;
        }

        // Código corregido para el método btnGuardar_Click:
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int? idDestino = (int?)CBoxDestino.SelectedValue;

            var Itinerario = new Itinerario()
            {
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                FechaInicio = dtpInicio.Value,
                FechaFin = dtpFin.Value,
                IdDestino = idDestino,
                Eliminado = false
            };

            if (ItinerarioCurrent != null)
            {
                Itinerario.Id = ItinerarioCurrent.Id;
                await itinerarioService.UpdateAsync(Itinerario);
                MessageBox.Show("Itinerario modificada correctamente.");
            }
            else
            {
                await itinerarioService.AddAsync(Itinerario);
                MessageBox.Show("Itinerario agregado correctamente.");
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
            var filtroItinerario = FiltroLista
                .Where(d => d.Nombre.Contains(txtFiltro.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ListaItinerario.DataSource = filtroItinerario;
            dataGridItinerarioView.Refresh();
        }
    }
}
