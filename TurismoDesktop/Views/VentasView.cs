using TurismoServices.Enums;
using TurismoServices.Interfaces;
using TurismoServices.Models;

namespace TurismoDesktop.Views
{
    public partial class VentaView : Form
    {
        private readonly IVentaService _ventaService;
        private readonly IGenericService<Cliente> _clienteService;
        private readonly IGenericService<Destino> _destinoService;
        private readonly IGenericService<Actividad> _actividadService;
        private readonly IGenericService<Itinerario> _itinerarioService;

        private readonly List<RegistroVenta> _registros = new();

        public VentaView(
            IVentaService ventaService,
            IGenericService<Cliente> clienteService,
            IGenericService<Destino> destinoService,
            IGenericService<Actividad> actividadService,
            IGenericService<Itinerario> itinerarioService)
        {
            InitializeComponent();
            _ventaService = ventaService;
            _clienteService = clienteService;
            _destinoService = destinoService;
            _actividadService = actividadService;
            _itinerarioService = itinerarioService;
        }

        private async void VentaView_Load(object sender, EventArgs e)
        {
            cbCliente.DataSource = await _clienteService.GetAllAsync(string.Empty);
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "Id";

            cbDestino.DataSource = await _destinoService.GetAllAsync(string.Empty);
            cbDestino.DisplayMember = "Nombre";
            cbDestino.ValueMember = "Id";

            cbActividad.DataSource = await _actividadService.GetAllAsync(string.Empty);
            cbActividad.DisplayMember = "Nombre";
            cbActividad.ValueMember = "Id";

            cbItinerario.DataSource = await _itinerarioService.GetAllAsync(string.Empty);
            cbItinerario.DisplayMember = "Nombre";
            cbItinerario.ValueMember = "Id";

            cbTransporte.DataSource = Enum.GetValues(typeof(PreferenciaTransporteEnum));
        }

        private void btnAgregarRegistro_Click(object sender, EventArgs e)
        {
            var registro = new RegistroVenta
            {
                IdDestino = (int?)cbDestino.SelectedValue,
                IdActividad = (int?)cbActividad.SelectedValue,
                IdItinerario = (int?)cbItinerario.SelectedValue,
                Transporte = (PreferenciaTransporteEnum)cbTransporte.SelectedItem,
                NumPersona = (int)nudPersonas.Value
            };
            _registros.Add(registro);

            dgvRegistros.DataSource = null;
            dgvRegistros.DataSource = _registros;
        }

        private async void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            var venta = new Venta
            {
                ClienteId = (int)cbCliente.SelectedValue,
                FechaReservacion = DateTime.Now,
                EstadoReservacion = EstadoReservacionEnum.Pendiente,
                MetodoPago = MetodoPagoEnum.Efectivo,
                ConfirmacionPago = ConfirmacionPagoEnum.Pendiente,
                FechaPago = DateTime.Now,
                Total = 0 // TODO: calcular si hace falta
            };

            await _ventaService.AddVentaAsync(venta, _registros);
            MessageBox.Show("Venta guardada con éxito");
            Close();
        }
    }
}
