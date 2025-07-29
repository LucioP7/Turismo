namespace TurismoDesktop.Views
{
    partial class ClienteView
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
            dataGridClienteView = new DataGridView();
            tabPageAddEdit = new TabPage();
            textBox1 = new TextBox();
            txtPais = new Label();
            txtProvincia = new Label();
            label10 = new Label();
            txtCiudad = new TextBox();
            textBox5 = new TextBox();
            dtpNac = new DateTimePicker();
            sad = new Label();
            txtTelfdsadasefono = new Label();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            txtEmail = new TextBox();
            label7 = new Label();
            txtDni = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            label2 = new Label();
            txtFiltro = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClienteView).BeginInit();
            tabPageAddEdit.SuspendLayout();
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
            label1.Location = new Point(11, 17);
            label1.Name = "label1";
            label1.Size = new Size(129, 36);
            label1.TabIndex = 0;
            label1.Text = "CLIENTE";
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
            tabPage1.Controls.Add(dataGridClienteView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 286);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lista";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridClienteView
            // 
            dataGridClienteView.AllowUserToAddRows = false;
            dataGridClienteView.AllowUserToDeleteRows = false;
            dataGridClienteView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridClienteView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClienteView.Dock = DockStyle.Fill;
            dataGridClienteView.Location = new Point(3, 3);
            dataGridClienteView.Name = "dataGridClienteView";
            dataGridClienteView.ReadOnly = true;
            dataGridClienteView.Size = new Size(786, 280);
            dataGridClienteView.TabIndex = 1;
            // 
            // tabPageAddEdit
            // 
            tabPageAddEdit.Controls.Add(textBox1);
            tabPageAddEdit.Controls.Add(txtPais);
            tabPageAddEdit.Controls.Add(txtProvincia);
            tabPageAddEdit.Controls.Add(label10);
            tabPageAddEdit.Controls.Add(txtCiudad);
            tabPageAddEdit.Controls.Add(textBox5);
            tabPageAddEdit.Controls.Add(dtpNac);
            tabPageAddEdit.Controls.Add(sad);
            tabPageAddEdit.Controls.Add(txtTelfdsadasefono);
            tabPageAddEdit.Controls.Add(txtTelefono);
            tabPageAddEdit.Controls.Add(txtDireccion);
            tabPageAddEdit.Controls.Add(btnCancelar);
            tabPageAddEdit.Controls.Add(btnGuardar);
            tabPageAddEdit.Controls.Add(txtEmail);
            tabPageAddEdit.Controls.Add(label7);
            tabPageAddEdit.Controls.Add(txtDni);
            tabPageAddEdit.Controls.Add(label6);
            tabPageAddEdit.Controls.Add(label5);
            tabPageAddEdit.Controls.Add(label4);
            tabPageAddEdit.Controls.Add(label3);
            tabPageAddEdit.Controls.Add(txtNombre);
            tabPageAddEdit.Controls.Add(txtApellido);
            tabPageAddEdit.Location = new Point(4, 24);
            tabPageAddEdit.Name = "tabPageAddEdit";
            tabPageAddEdit.Padding = new Padding(3);
            tabPageAddEdit.Size = new Size(792, 286);
            tabPageAddEdit.TabIndex = 1;
            tabPageAddEdit.Text = "Agregar/Editar";
            tabPageAddEdit.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(492, 92);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 23);
            textBox1.TabIndex = 32;
            // 
            // txtPais
            // 
            txtPais.AutoEllipsis = true;
            txtPais.AutoSize = true;
            txtPais.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtPais.Location = new Point(441, 96);
            txtPais.Name = "txtPais";
            txtPais.Size = new Size(36, 19);
            txtPais.TabIndex = 31;
            txtPais.Text = "Pais";
            // 
            // txtProvincia
            // 
            txtProvincia.AutoSize = true;
            txtProvincia.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtProvincia.Location = new Point(420, 55);
            txtProvincia.Name = "txtProvincia";
            txtProvincia.Size = new Size(72, 19);
            txtProvincia.TabIndex = 30;
            txtProvincia.Text = "Provincia";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label10.Location = new Point(421, 19);
            label10.Name = "label10";
            label10.Size = new Size(56, 19);
            label10.TabIndex = 29;
            label10.Text = "Ciudad";
            // 
            // txtCiudad
            // 
            txtCiudad.Location = new Point(492, 19);
            txtCiudad.Name = "txtCiudad";
            txtCiudad.Size = new Size(286, 23);
            txtCiudad.TabIndex = 27;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(492, 55);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(286, 23);
            textBox5.TabIndex = 28;
            // 
            // dtpNac
            // 
            dtpNac.Format = DateTimePickerFormat.Short;
            dtpNac.Location = new Point(141, 128);
            dtpNac.Name = "dtpNac";
            dtpNac.Size = new Size(200, 23);
            dtpNac.TabIndex = 26;
            // 
            // sad
            // 
            sad.AutoSize = true;
            sad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            sad.Location = new Point(6, 225);
            sad.Name = "sad";
            sad.Size = new Size(72, 19);
            sad.TabIndex = 25;
            sad.Text = "Direccion";
            // 
            // txtTelfdsadasefono
            // 
            txtTelfdsadasefono.AutoSize = true;
            txtTelfdsadasefono.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            txtTelfdsadasefono.Location = new Point(7, 189);
            txtTelfdsadasefono.Name = "txtTelfdsadasefono";
            txtTelfdsadasefono.Size = new Size(67, 19);
            txtTelfdsadasefono.TabIndex = 24;
            txtTelfdsadasefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(78, 189);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(286, 23);
            txtTelefono.TabIndex = 22;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(78, 225);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(286, 23);
            txtDireccion.TabIndex = 23;
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
            btnCancelar.Click += btnCancelar_Click;
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
            btnGuardar.Click += btnGuardar_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(78, 160);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(286, 23);
            txtEmail.TabIndex = 17;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(21, 161);
            label7.Name = "label7";
            label7.Size = new Size(45, 19);
            label7.TabIndex = 16;
            label7.Text = "Email";
            // 
            // txtDni
            // 
            txtDni.Location = new Point(93, 92);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(286, 23);
            txtDni.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(7, 128);
            label6.Name = "label6";
            label6.Size = new Size(128, 19);
            label6.TabIndex = 13;
            label6.Text = "Fecha Nacimiento";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(4, 93);
            label5.Name = "label5";
            label5.Size = new Size(86, 19);
            label5.TabIndex = 12;
            label5.Text = "Documento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(21, 55);
            label4.Name = "label4";
            label4.Size = new Size(66, 19);
            label4.TabIndex = 11;
            label4.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(22, 19);
            label3.Name = "label3";
            label3.Size = new Size(65, 19);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(93, 19);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 23);
            txtNombre.TabIndex = 8;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(93, 55);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(286, 23);
            txtApellido.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 78);
            label2.Name = "label2";
            label2.Size = new Size(116, 21);
            label2.TabIndex = 2;
            label2.Text = "Buscar cliente";
            // 
            // txtFiltro
            // 
            txtFiltro.Location = new Point(9, 106);
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(286, 23);
            txtFiltro.TabIndex = 3;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
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
            btnAgregar.Click += btnAgregar_Click;
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
            btnModificar.Click += btnModificar_Click;
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
            btnEliminar.Click += btnEliminar_Click;
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
            btnSalir.Click += btnSalir_Click;
            // 
            // ClienteView
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
            Name = "ClienteView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Destino";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridClienteView).EndInit();
            tabPageAddEdit.ResumeLayout(false);
            tabPageAddEdit.PerformLayout();
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
        private DataGridView dataGridClienteView;
        private TabPage tabPageAddEdit;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private Label label3;
        private TextBox txtEmail;
        private Label label7;
        private TextBox txtDni;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label sad;
        private Label txtTelfdsadasefono;
        private TextBox txtTelefono;
        private TextBox txtDireccion;
        private TextBox textBox1;
        private Label txtPais;
        private Label txtProvincia;
        private Label label10;
        private TextBox txtCiudad;
        private TextBox textBox5;
        private DateTimePicker dtpNac;
    }
}