namespace TurismoDesktop.Views
{
    partial class ActividadView
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
            dataGridActividadView = new DataGridView();
            tabPageAddEdit = new TabPage();
            label7 = new Label();
            txtDescripcion = new TextBox();
            label6 = new Label();
            label4 = new Label();
            nudCosto = new NumericUpDown();
            numMeses = new NumericUpDown();
            btnCancelar = new Button();
            btnGuardar = new Button();
            label8 = new Label();
            CBoxDestino = new ComboBox();
            txtUrl = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txtNombre = new TextBox();
            label2 = new Label();
            txtFiltro = new TextBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridActividadView).BeginInit();
            tabPageAddEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCosto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMeses).BeginInit();
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
            label1.Size = new Size(172, 36);
            label1.TabIndex = 0;
            label1.Text = "ACTIVIDAD";
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
            tabPage1.Controls.Add(dataGridActividadView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 286);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Lista";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridActividadView
            // 
            dataGridActividadView.AllowUserToAddRows = false;
            dataGridActividadView.AllowUserToDeleteRows = false;
            dataGridActividadView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridActividadView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridActividadView.Dock = DockStyle.Fill;
            dataGridActividadView.Location = new Point(3, 3);
            dataGridActividadView.Name = "dataGridActividadView";
            dataGridActividadView.ReadOnly = true;
            dataGridActividadView.Size = new Size(786, 280);
            dataGridActividadView.TabIndex = 1;
            // 
            // tabPageAddEdit
            // 
            tabPageAddEdit.Controls.Add(label7);
            tabPageAddEdit.Controls.Add(txtDescripcion);
            tabPageAddEdit.Controls.Add(label6);
            tabPageAddEdit.Controls.Add(label4);
            tabPageAddEdit.Controls.Add(nudCosto);
            tabPageAddEdit.Controls.Add(numMeses);
            tabPageAddEdit.Controls.Add(btnCancelar);
            tabPageAddEdit.Controls.Add(btnGuardar);
            tabPageAddEdit.Controls.Add(label8);
            tabPageAddEdit.Controls.Add(CBoxDestino);
            tabPageAddEdit.Controls.Add(txtUrl);
            tabPageAddEdit.Controls.Add(label5);
            tabPageAddEdit.Controls.Add(label3);
            tabPageAddEdit.Controls.Add(txtNombre);
            tabPageAddEdit.Location = new Point(4, 24);
            tabPageAddEdit.Name = "tabPageAddEdit";
            tabPageAddEdit.Padding = new Padding(3);
            tabPageAddEdit.Size = new Size(792, 286);
            tabPageAddEdit.TabIndex = 1;
            tabPageAddEdit.Text = "Agregar/Editar";
            tabPageAddEdit.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.Location = new Point(6, 181);
            label7.Name = "label7";
            label7.Size = new Size(87, 19);
            label7.TabIndex = 27;
            label7.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(94, 180);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(286, 88);
            txtDescripcion.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(38, 135);
            label6.Name = "label6";
            label6.Size = new Size(47, 19);
            label6.TabIndex = 25;
            label6.Text = "Costo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(38, 95);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 24;
            label4.Text = "Meses";
            // 
            // nudCosto
            // 
            nudCosto.DecimalPlaces = 2;
            nudCosto.Location = new Point(94, 135);
            nudCosto.Maximum = new decimal(new int[] { -727379968, 232, 0, 0 });
            nudCosto.Name = "nudCosto";
            nudCosto.Size = new Size(286, 23);
            nudCosto.TabIndex = 23;
            nudCosto.TextAlign = HorizontalAlignment.Right;
            // 
            // numMeses
            // 
            numMeses.Location = new Point(94, 95);
            numMeses.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numMeses.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numMeses.Name = "numMeses";
            numMeses.Size = new Size(286, 23);
            numMeses.TabIndex = 22;
            numMeses.TextAlign = HorizontalAlignment.Right;
            numMeses.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.Location = new Point(407, 22);
            label8.Name = "label8";
            label8.Size = new Size(59, 19);
            label8.TabIndex = 19;
            label8.Text = "Destino";
            // 
            // CBoxDestino
            // 
            CBoxDestino.FormattingEnabled = true;
            CBoxDestino.Location = new Point(484, 18);
            CBoxDestino.Name = "CBoxDestino";
            CBoxDestino.Size = new Size(286, 23);
            CBoxDestino.TabIndex = 18;
            // 
            // txtUrl
            // 
            txtUrl.Location = new Point(94, 57);
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(286, 23);
            txtUrl.TabIndex = 14;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(5, 58);
            label5.Name = "label5";
            label5.Size = new Size(83, 19);
            label5.TabIndex = 12;
            label5.Text = "Url Imagen";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(23, 18);
            label3.Name = "label3";
            label3.Size = new Size(65, 19);
            label3.TabIndex = 10;
            label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(94, 18);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(286, 23);
            txtNombre.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(5, 78);
            label2.Name = "label2";
            label2.Size = new Size(135, 21);
            label2.TabIndex = 2;
            label2.Text = "Buscar actividad";
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
            // ActividadView
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
            Name = "ActividadView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Actividades";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridActividadView).EndInit();
            tabPageAddEdit.ResumeLayout(false);
            tabPageAddEdit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCosto).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMeses).EndInit();
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
        private DataGridView dataGridActividadView;
        private TabPage tabPageAddEdit;
        private TextBox txtNombre;
        private Label label3;
        private TextBox txtUrl;
        private Label label5;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label8;
        private ComboBox CBoxDestino;
        private NumericUpDown numMeses;
        private Label label4;
        private NumericUpDown nudCosto;
        private Label label7;
        private TextBox txtDescripcion;
        private Label label6;
    }
}