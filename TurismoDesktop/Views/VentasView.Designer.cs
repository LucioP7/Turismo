namespace TurismoDesktop.Views
{
    partial class VentaView
    {
        private System.ComponentModel.IContainer components = null;
        private ComboBox cbCliente;
        private ComboBox cbDestino;
        private ComboBox cbActividad;
        private ComboBox cbItinerario;
        private ComboBox cbTransporte;
        private NumericUpDown nudPersonas;
        private DataGridView dgvRegistros;
        private Button btnAgregarRegistro;
        private Button btnGuardarVenta;
        private Label lblCliente;
        private Label lblDestino;
        private Label lblActividad;
        private Label lblItinerario;
        private Label lblTransporte;
        private Label lblPersonas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.cbCliente = new ComboBox();
            this.cbDestino = new ComboBox();
            this.cbActividad = new ComboBox();
            this.cbItinerario = new ComboBox();
            this.cbTransporte = new ComboBox();
            this.nudPersonas = new NumericUpDown();
            this.dgvRegistros = new DataGridView();
            this.btnAgregarRegistro = new Button();
            this.btnGuardarVenta = new Button();
            this.lblCliente = new Label();
            this.lblDestino = new Label();
            this.lblActividad = new Label();
            this.lblItinerario = new Label();
            this.lblTransporte = new Label();
            this.lblPersonas = new Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).BeginInit();
            this.SuspendLayout();

            // cbCliente
            this.cbCliente.Location = new Point(100, 20);
            this.cbCliente.Size = new Size(200, 23);

            // cbDestino
            this.cbDestino.Location = new Point(100, 60);
            this.cbDestino.Size = new Size(200, 23);

            // cbActividad
            this.cbActividad.Location = new Point(100, 100);
            this.cbActividad.Size = new Size(200, 23);

            // cbItinerario
            this.cbItinerario.Location = new Point(100, 140);
            this.cbItinerario.Size = new Size(200, 23);

            // cbTransporte
            this.cbTransporte.Location = new Point(100, 180);
            this.cbTransporte.Size = new Size(200, 23);

            // nudPersonas
            this.nudPersonas.Location = new Point(100, 220);
            this.nudPersonas.Size = new Size(80, 23);

            // dgvRegistros
            this.dgvRegistros.Location = new Point(20, 260);
            this.dgvRegistros.Size = new Size(500, 150);

            // btnAgregarRegistro
            this.btnAgregarRegistro.Location = new Point(320, 220);
            this.btnAgregarRegistro.Size = new Size(120, 30);
            this.btnAgregarRegistro.Text = "Agregar Registro";
            this.btnAgregarRegistro.Click += new EventHandler(this.btnAgregarRegistro_Click);

            // btnGuardarVenta
            this.btnGuardarVenta.Location = new Point(20, 420);
            this.btnGuardarVenta.Size = new Size(120, 30);
            this.btnGuardarVenta.Text = "Guardar Venta";
            this.btnGuardarVenta.Click += new EventHandler(this.btnGuardarVenta_Click);

            // Labels
            this.lblCliente.Location = new Point(20, 20);
            this.lblCliente.Text = "Cliente:";
            this.lblDestino.Location = new Point(20, 60);
            this.lblDestino.Text = "Destino:";
            this.lblActividad.Location = new Point(20, 100);
            this.lblActividad.Text = "Actividad:";
            this.lblItinerario.Location = new Point(20, 140);
            this.lblItinerario.Text = "Itinerario:";
            this.lblTransporte.Location = new Point(20, 180);
            this.lblTransporte.Text = "Transporte:";
            this.lblPersonas.Location = new Point(20, 220);
            this.lblPersonas.Text = "Personas:";

            // Form
            this.ClientSize = new Size(550, 470);
            this.Controls.AddRange(new Control[] {
                cbCliente, cbDestino, cbActividad, cbItinerario,
                cbTransporte, nudPersonas, dgvRegistros,
                btnAgregarRegistro, btnGuardarVenta,
                lblCliente, lblDestino, lblActividad, lblItinerario, lblTransporte, lblPersonas
            });
            this.Load += new EventHandler(this.VentaView_Load);
            this.Text = "Registro de Ventas";
            ((System.ComponentModel.ISupportInitialize)(this.nudPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegistros)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
