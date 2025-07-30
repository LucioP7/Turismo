using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TurismoServices.Enums;
using TurismoServices.Models;
using TurismoServices.Services;

namespace TurismoDesktop.Views
{
    public partial class VentaView : Form
    {
        private readonly VentaService ventaService = new();
        private readonly GenericService<Cliente> clienteService = new();
        private readonly GenericService<Itinerario> itinerarioService = new();
        private readonly GenericService<Actividad> actividadService = new();

        private List<Venta> listaVentas = new();
        private List<Cliente> listaClientes = new();
        private List<Itinerario> listaItinerarios = new();
        private List<Actividad> listaActividades = new();

        private Venta ventaSeleccionada = null;

        public VentaView()
        {
            InitializeComponent();
            InicializarCombos();
            CargarDatosAsync();
            ConfigurarEventos();
        }

        private void InicializarCombos()
        {
            // Combo MetodoPago
            CBoxMetodoEnum.DataSource = Enum.GetValues(typeof(MetodoPagoEnum));
            // Combo Transporte
            CBoxTransporte.DataSource = Enum.GetValues(typeof(PreferenciaTransporteEnum));
        }

        private async void CargarDatosAsync()
        {
            try
            {
                listaClientes = await clienteService.GetAllAsync() ?? new List<Cliente>();
                listaItinerarios = await itinerarioService.GetAllAsync() ?? new List<Itinerario>();

                CBoxCliente.DataSource = listaClientes;
                CBoxCliente.DisplayMember = "NombreCompleto"; // Asumo que concatenás Nombre + Apellido en Cliente, si no cambialo a ToString
                CBoxCliente.ValueMember = "Id";

                CBoxItinerario.DataSource = listaItinerarios;
                CBoxItinerario.DisplayMember = "Nombre"; // Adaptar según la propiedad real de Itinerario
                CBoxItinerario.ValueMember = "Id";

                // Inicialmente vacio el combo Actividad
                CBoxActividad.DataSource = null;

                await CargarVentasAsync();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando datos: {ex.Message}");
            }
        }

        private async Task CargarVentasAsync(string filtro = "")
        {
            try
            {
                listaVentas = await ventaService.GetAllWithDetailsAsync() ?? new List<Venta>();
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    filtro = filtro.ToLower();
                    listaVentas = listaVentas.Where(v =>
                        v.Cliente != null && (v.Cliente.Nombre.ToLower().Contains(filtro) || v.Cliente.Apellido.ToLower().Contains(filtro))
                        || v.Itinerario != null && v.Itinerario.Nombre.ToLower().Contains(filtro)
                        || (v.Itinerario?.Destino?.Nombre.ToLower().Contains(filtro) ?? false)
                    ).ToList();
                }

                dataGridVentaView.DataSource = listaVentas.Select(v => new
                {
                    v.Id,
                    Cliente = v.Cliente?.ToString(),
                    Itinerario = v.Itinerario?.Nombre,
                    Destino = v.Itinerario?.Destino?.Nombre,
                    Actividad = v.Actividad?.Nombre,
                    v.NumPersona,
                    MetodoPago = v.MetodoPago.ToString(),
                    Transporte = v.Transporte.ToString(),
                    FechaReservacion = v.FechaReservacion.ToShortDateString(),
                    FechaPago = v.FechaPago.ToShortDateString(),
                    Total = v.Total.ToString("C")
                }).ToList();

                LimpiarFormulario();
                tabControl1.SelectedTab = tabPage1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando ventas: {ex.Message}");
            }
        }

        private void ConfigurarEventos()
        {
            txtFiltro.TextChanged += (s, e) =>
            {
                _ = CargarVentasAsync(txtFiltro.Text);
            };

            CBoxItinerario.SelectedIndexChanged += async (s, e) =>
            {
                if (CBoxItinerario.SelectedItem is Itinerario itinerarioSeleccionado)
                {
                    // Cargar actividades por destino del itinerario
                    await CargarActividadesPorDestinoAsync(itinerarioSeleccionado.Id);

                    // Mostrar destino
                    txtDestino.Text = itinerarioSeleccionado.Destino?.Nombre ?? "";
                }
                else
                {
                    CBoxActividad.DataSource = null;
                    txtDestino.Text = "";
                }
                CalcularTotal();
            };

            CBoxActividad.SelectedIndexChanged += (s, e) =>
            {
                CalcularTotal();
            };

            nudCanti.ValueChanged += (s, e) =>
            {
                CalcularTotal();
            };

            btnAgregar.Click += BtnAgregar_Click;
            btnModificar.Click += BtnModificar_Click;
            btnEliminar.Click += BtnEliminar_Click;
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += BtnCancelar_Click;
            btnSalir.Click += (s, e) => Close();

            dataGridVentaView.SelectionChanged += DataGridVentaView_SelectionChanged;
        }

        private async Task CargarActividadesPorDestinoAsync(int destinoId)
        {
            try
            {
                listaActividades = await actividadService.GetAllAsync($"destinoId={destinoId}") ?? new List<Actividad>();
                CBoxActividad.DataSource = listaActividades;
                CBoxActividad.DisplayMember = "Nombre"; // Asumo que Actividad tiene Nombre
                CBoxActividad.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando actividades: {ex.Message}");
            }
        }

        private void CalcularTotal()
        {
            if (CBoxActividad.SelectedItem is Actividad actividad && actividad.Costo > 0)
            {
                decimal costo = actividad.Costo;
                int cantidad = (int)nudCanti.Value;
                decimal total = costo * cantidad;
                txtTotal.Text = total.ToString("F2");
            }
            else
            {
                txtTotal.Text = "0.00";
            }
        }

        private void LimpiarFormulario()
        {
            ventaSeleccionada = null;
            CBoxCliente.SelectedIndex = -1;
            CBoxItinerario.SelectedIndex = -1;
            CBoxActividad.DataSource = null;
            CBoxMetodoEnum.SelectedIndex = 0;
            CBoxTransporte.SelectedIndex = 0;
            dtpReserva.Value = DateTime.Today;
            gtpFechaPago.Value = DateTime.Today;
            nudCanti.Value = 1;
            txtTotal.Text = "0.00";
            txtDestino.Text = "";
            tabControl1.SelectedTab = tabPage1;
        }

        private void CargarVentaEnFormulario(Venta v)
        {
            if (v == null) return;

            ventaSeleccionada = v;

            CBoxCliente.SelectedValue = v.ClienteId;
            CBoxItinerario.SelectedValue = v.ItinerarioId;

            // Cargar actividades por destino y seleccionar la actividad correspondiente
            if (v.Itinerario != null && v.Itinerario.IdDestino.HasValue)
            {
                _ = CargarActividadesPorDestinoAsync(v.Itinerario.IdDestino.Value).ContinueWith(_ =>
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        CBoxActividad.SelectedValue = v.ActividadId;
                    });
                });
            }
            else
            {
                CBoxActividad.DataSource = null;
            }

            CBoxMetodoEnum.SelectedItem = v.MetodoPago;
            CBoxTransporte.SelectedItem = v.Transporte;
            dtpReserva.Value = v.FechaReservacion;
            gtpFechaPago.Value = v.FechaPago;
            nudCanti.Value = v.NumPersona > 0 ? v.NumPersona : 1;
            CalcularTotal();
            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private async void BtnAgregar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private async void BtnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridVentaView.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione una venta para modificar");
                return;
            }

            var id = (int)dataGridVentaView.CurrentRow.Cells["Id"].Value;
            var venta = listaVentas.FirstOrDefault(v => v.Id == id);

            if (venta == null)
            {
                MessageBox.Show("Venta no encontrada");
                return;
            }

            CargarVentaEnFormulario(venta);
        }

        private async void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridVentaView.CurrentRow?.DataBoundItem == null)
            {
                MessageBox.Show("Seleccione una venta para eliminar");
                return;
            }

            var id = (int)dataGridVentaView.CurrentRow.Cells["Id"].Value;

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar esta venta?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await ventaService.DeleteAsync(id);
                await CargarVentasAsync(txtFiltro.Text);
                MessageBox.Show("Venta eliminada");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}");
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var venta = new Venta
                {
                    Id = ventaSeleccionada?.Id ?? 0,
                    ClienteId = (int)CBoxCliente.SelectedValue,
                    ItinerarioId = (int)CBoxItinerario.SelectedValue,
                    ActividadId = (int)CBoxActividad.SelectedValue,
                    MetodoPago = (MetodoPagoEnum)CBoxMetodoEnum.SelectedItem,
                    Transporte = (PreferenciaTransporteEnum)CBoxTransporte.SelectedItem,
                    FechaReservacion = dtpReserva.Value.Date,
                    FechaPago = gtpFechaPago.Value.Date,
                    NumPersona = (int)nudCanti.Value,
                    Total = decimal.Parse(txtTotal.Text),
                    Eliminado = false
                };

                if (venta.Id == 0)
                {
                    // Alta
                    await ventaService.AddAsync(venta);
                }
                else
                {
                    // Modificación
                    await ventaService.UpdateAsync(venta);
                }

                await CargarVentasAsync(txtFiltro.Text);
                MessageBox.Show("Venta guardada correctamente");
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error guardando venta: {ex.Message}");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void DataGridVentaView_SelectionChanged(object sender, EventArgs e)
        {
            // Podés poner lógica si querés que algo pase cuando se selecciona fila
        }

        private bool ValidarFormulario()
        {
            if (CBoxCliente.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un cliente");
                return false;
            }
            if (CBoxItinerario.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un itinerario");
                return false;
            }
            if (CBoxActividad.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar una actividad");
                return false;
            }
            if (nudCanti.Value <= 0)
            {
                MessageBox.Show("La cantidad de personas debe ser mayor que cero");
                return false;
            }
            return true;
        }

        private void CBoxItinerario_SelectedIndexChanged(object sender, EventArgs e)
        {

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
