namespace TurismoDesktop.Views
{
    partial class VentaView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridVentaView = new DataGridView();
            tabPageAddEdit = new TabPage();
            nudCanti = new NumericUpDown();
            label4 = new Label();
            dtpFechaPago = new DateTimePicker();
            dtpReserva = new DateTimePicker();
            CBoxTransporte = new ComboBox();
            CBoxMetodoEnum = new ComboBox();
            CBoxCliente = new ComboBox();
            label10 = new Label();
            btnCancelar = new Button();
            btnGuardar = new Button();
            label8 = new Label();
            txtTotal = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            labelDestino = new Label();
            CBoxItinerario = new ComboBox();
            labelItinerario = new Label();
            CBoxActividad = new ComboBox();
            labelActividad = new Label();
            label2 = new Label();
            txtFiltro = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            CBoxDestino = new ComboBox();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVentaView).BeginInit();
            tabPageAddEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCanti).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 73);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 17);
            label1.Name = "label1";
            label1.Size = new Size(106, 36);
            label1.TabIndex = 0;
            label1.Text = "VENTA";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPageAddEdit);
            tabControl1.Location = new Point(1, 135);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(800, 314);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dataGridVentaView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 286);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lista";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridVentaView
            // 
            dataGridVentaView.AllowUserToAddRows = false;
            dataGridVentaView.AllowUserToDeleteRows = false;
            dataGridVentaView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridVentaView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVentaView.Dock = DockStyle.Fill;
            dataGridVentaView.Location = new Point(3, 3);
            dataGridVentaView.Name = "dataGridVentaView";
            dataGridVentaView.ReadOnly = true;
            dataGridVentaView.Size = new Size(786, 280);
            dataGridVentaView.TabIndex = 1;
            // 
            // tabPageAddEdit
            // 
            tabPageAddEdit.Controls.Add(CBoxDestino);
            tabPageAddEdit.Controls.Add(nudCanti);
            tabPageAddEdit.Controls.Add(label4);
            tabPageAddEdit.Controls.Add(dtpFechaPago);
            tabPageAddEdit.Controls.Add(dtpReserva);
            tabPageAddEdit.Controls.Add(CBoxTransporte);
            tabPageAddEdit.Controls.Add(CBoxMetodoEnum);
            tabPageAddEdit.Controls.Add(CBoxCliente);
            tabPageAddEdit.Controls.Add(label10);
            tabPageAddEdit.Controls.Add(btnCancelar);
            tabPageAddEdit.Controls.Add(btnGuardar);
            tabPageAddEdit.Controls.Add(label8);
            tabPageAddEdit.Controls.Add(txtTotal);
            tabPageAddEdit.Controls.Add(label7);
            tabPageAddEdit.Controls.Add(label6);
            tabPageAddEdit.Controls.Add(label5);
            tabPageAddEdit.Controls.Add(label3);
            tabPageAddEdit.Controls.Add(labelDestino);
            tabPageAddEdit.Controls.Add(CBoxItinerario);
            tabPageAddEdit.Controls.Add(labelItinerario);
            tabPageAddEdit.Controls.Add(CBoxActividad);
            tabPageAddEdit.Controls.Add(labelActividad);
            tabPageAddEdit.Location = new Point(4, 24);
            tabPageAddEdit.Name = "tabPageAddEdit";
            tabPageAddEdit.Padding = new Padding(3);
            tabPageAddEdit.Size = new Size(792, 286);
            tabPageAddEdit.TabIndex = 1;
            tabPageAddEdit.Text = "Agregar/Editar";
            tabPageAddEdit.UseVisualStyleBackColor = true;
            // 
            // nudCanti
            // 
            nudCanti.Location = new Point(146, 192);
            nudCanti.Name = "nudCanti";
            nudCanti.Size = new Size(120, 23);
            nudCanti.TabIndex = 32;
            nudCanti.UpDownAlign = LeftRightAlignment.Left;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(7, 192);
            label4.Name = "label4";
            label4.Size = new Size(133, 19);
            label4.TabIndex = 31;
            label4.Text = "Cantidad personas";
            // 
            // dtpFechaPago
            // 
            dtpFechaPago.Format = DateTimePickerFormat.Short;
            dtpFechaPago.Location = new Point(102, 158);
            dtpFechaPago.Name = "dtpFechaPago";
            dtpFechaPago.Size = new Size(110, 23);
            dtpFechaPago.TabIndex = 29;
            // 
            // dtpReserva
            // 
            dtpReserva.Format = DateTimePickerFormat.Short;
            dtpReserva.Location = new Point(115, 58);
            dtpReserva.Name = "dtpReserva";
            dtpReserva.Size = new Size(110, 23);
            dtpReserva.TabIndex = 28;
            // 
            // CBoxTransporte
            // 
            CBoxTransporte.FormattingEnabled = true;
            CBoxTransporte.Location = new Point(94, 120);
            CBoxTransporte.Name = "CBoxTransporte";
            CBoxTransporte.Size = new Size(286, 23);
            CBoxTransporte.TabIndex = 27;
            // 
            // CBoxMetodoEnum
            // 
            CBoxMetodoEnum.FormattingEnabled = true;
            CBoxMetodoEnum.Location = new Point(134, 87);
            CBoxMetodoEnum.Name = "CBoxMetodoEnum";
            CBoxMetodoEnum.Size = new Size(246, 23);
            CBoxMetodoEnum.TabIndex = 26;
            // 
            // CBoxCliente
            // 
            CBoxCliente.FormattingEnabled = true;
            CBoxCliente.Location = new Point(67, 23);
            CBoxCliente.Name = "CBoxCliente";
            CBoxCliente.Size = new Size(286, 23);
            CBoxCliente.TabIndex = 24;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(10, 158);
            label10.Name = "label10";
            label10.Size = new Size(86, 19);
            label10.TabIndex = 23;
            label10.Text = "Fecha pago";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.MenuBar;
            btnCancelar.FlatStyle = FlatStyle.Popup;
            btnCancelar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(671, 245);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(87, 35);
            btnCancelar.TabIndex = 21;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = SystemColors.MenuBar;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.Location = new Point(578, 245);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(87, 35);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(7, 221);
            label8.Name = "label8";
            label8.Size = new Size(42, 19);
            label8.TabIndex = 19;
            label8.Text = "Total";
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(67, 221);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(286, 23);
            txtTotal.TabIndex = 17;
            txtTotal.WordWrap = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(7, 56);
            label7.Name = "label7";
            label7.Size = new Size(102, 19);
            label7.TabIndex = 16;
            label7.Text = "Fecha reserva";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(7, 120);
            label6.Name = "label6";
            label6.Size = new Size(81, 19);
            label6.TabIndex = 13;
            label6.Text = "Transporte";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(6, 88);
            label5.Name = "label5";
            label5.Size = new Size(122, 19);
            label5.TabIndex = 12;
            label5.Text = "Metodo de pago";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(6, 23);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 10;
            label3.Text = "Cliente";
            // 
            // labelDestino
            // 
            labelDestino.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelDestino.Location = new Point(426, 16);
            labelDestino.Name = "labelDestino";
            labelDestino.Size = new Size(74, 23);
            labelDestino.TabIndex = 33;
            labelDestino.Text = "Destino";
            // 
            // CBoxItinerario
            // 
            CBoxItinerario.Location = new Point(516, 56);
            CBoxItinerario.Name = "CBoxItinerario";
            CBoxItinerario.Size = new Size(200, 23);
            CBoxItinerario.TabIndex = 35;
            CBoxItinerario.SelectedIndexChanged += CBoxItinerario_SelectedIndexChanged;
            // 
            // labelItinerario
            // 
            labelItinerario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelItinerario.Location = new Point(426, 58);
            labelItinerario.Name = "labelItinerario";
            labelItinerario.Size = new Size(74, 23);
            labelItinerario.TabIndex = 36;
            labelItinerario.Text = "Itinerario";
            // 
            // CBoxActividad
            // 
            CBoxActividad.Location = new Point(516, 97);
            CBoxActividad.Name = "CBoxActividad";
            CBoxActividad.Size = new Size(200, 23);
            CBoxActividad.TabIndex = 37;
            // 
            // labelActividad
            // 
            labelActividad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelActividad.Location = new Point(426, 98);
            labelActividad.Name = "labelActividad";
            labelActividad.Size = new Size(74, 23);
            labelActividad.TabIndex = 38;
            labelActividad.Text = "Actividad";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 78);
            label2.Name = "label2";
            label2.Size = new Size(114, 21);
            label2.TabIndex = 2;
            label2.Text = "Buscar ventas";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(9, 106);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(286, 23);
            txtFiltro.TabIndex = 3;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = SystemColors.MenuBar;
            btnAgregar.FlatStyle = FlatStyle.Popup;
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(399, 97);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(92, 35);
            btnAgregar.TabIndex = 4;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            // 
            // btnModificar
            // 
            btnModificar.BackColor = SystemColors.MenuBar;
            btnModificar.FlatStyle = FlatStyle.Popup;
            btnModificar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificar.Location = new Point(497, 97);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(92, 35);
            btnModificar.TabIndex = 5;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = SystemColors.MenuBar;
            btnEliminar.FlatStyle = FlatStyle.Popup;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(595, 97);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(92, 35);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = SystemColors.MenuBar;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.Location = new Point(693, 97);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(92, 35);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // CBoxDestino
            // 
            CBoxDestino.Location = new Point(516, 15);
            CBoxDestino.Name = "CBoxDestino";
            CBoxDestino.Size = new Size(200, 23);
            CBoxDestino.TabIndex = 39;
            // 
            // VentaView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 474);
            Controls.Add(btnSalir);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(txtFiltro);
            Controls.Add(label2);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "VentaView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "VENTAS";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridVentaView).EndInit();
            tabPageAddEdit.ResumeLayout(false);
            tabPageAddEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCanti).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label1;
        private Label label2;
        private TextBox txtFiltro;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnSalir;
        private DataGridView dataGridVentaView;
        private TabPage tabPageAddEdit;
        private Label label3;
        private TextBox txtTotal;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label8;
        private Label label10;
        private DateTimePicker gtpFechaPago;
        private DateTimePicker dtpReserva;
        private ComboBox CBoxTransporte;
        private ComboBox CBoxMetodoEnum;
        private ComboBox CBoxCliente;
        private NumericUpDown nudCanti;
        private Label label4;
        private ComboBox CBoxItinerario;
        private ComboBox CBoxActividad;
        private Label labelDestino;
        private Label labelItinerario;
        private Label labelActividad;
        private DateTimePicker dtpFechaPago;
        private ComboBox CBoxDestino;
    }
}