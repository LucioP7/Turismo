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
    public partial class ActividadView : Form
    {
        private readonly IGenericService<Actividad> actividadService = new GenericService<Actividad>();
        private readonly IGenericService<Destino> destinoService = new GenericService<Destino>();

        private BindingSource ListaActividad = new BindingSource();
        private List<Actividad> FiltroLista = new List<Actividad>();

        private Actividad? ActividadCurrent;

        public ActividadView()
        {
            InitializeComponent();
            dataGridActividadView.DataSource = ListaActividad;

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
            var actividad = await actividadService.GetAllAsync(string.Empty);
            var lista = actividad?.Where(d => !d.Eliminado).ToList() ?? new List<Actividad>();

            ListaActividad.DataSource = lista;
            FiltroLista = lista;

            // Corrección: la propiedad correcta es Columns, no columns, y Visible, no visible.
            // Además, DefaultCellStyle.Format debe usarse en la columna correspondiente.
            dataGridActividadView.Columns[0].Visible = false;
            dataGridActividadView.Columns[6].Visible = false;
            dataGridActividadView.Columns[7].Visible = false;
            dataGridActividadView.Columns[4].DefaultCellStyle.Format = "n2";
            dataGridActividadView.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ActividadCurrent = (Actividad)ListaActividad.Current;

            if (ActividadCurrent != null)
            {
                txtNombre.Text = ActividadCurrent.Nombre;
                txtUrl.Text = ActividadCurrent.URL_Image;
                numMeses.Value = ActividadCurrent.Duracion;
                nudCosto.Value = ActividadCurrent.Costo;
                txtDescripcion.Text = ActividadCurrent.Descripcion;
                tabControl1.SelectedTab = tabPageAddEdit;
            }
            else
            {
                MessageBox.Show("Seleccione una actividad para modificar.");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListaActividad.Current is Actividad actividad)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar esta actividad?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    actividad.Eliminado = true; // Marcar como eliminado
                    await actividadService.UpdateAsync(actividad); // Actualizar el destino
                    await LoadGrid(); // Recargar la lista
                }
            }
            else
            {
                MessageBox.Show("Seleccione una actividad para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtUrl.Text = string.Empty;
            numMeses.Value = 1;
            nudCosto.Value = 0;
            CBoxDestino.SelectedIndex = 1;

            tabControl1.SelectedTab = tabPageAddEdit;
        }

        // Código corregido para el método btnGuardar_Click:
        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            int? idDestino = (int?)CBoxDestino.SelectedValue;

            var actividad = new Actividad()
            {
                Nombre = txtNombre.Text,
                URL_Image = txtUrl.Text,
                Duracion = (int)numMeses.Value,
                Costo = (int)nudCosto.Value,
                Descripcion = txtDescripcion.Text,
                IdDestino = idDestino,
                Eliminado = false
            };

            if (ActividadCurrent != null)
            {
                actividad.Id = ActividadCurrent.Id;
                await actividadService.UpdateAsync(actividad);
                MessageBox.Show("Actividad modificada correctamente.");
            }
            else
            {
                await actividadService.AddAsync(actividad);
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
            var filtroActividad = FiltroLista
                .Where(d => d.Nombre.Contains(txtFiltro.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ListaActividad.DataSource = filtroActividad;
            dataGridActividadView.Refresh();
        }
    }
}
