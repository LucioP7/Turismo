namespace TurismoDesktop.Views
{
    partial class MainView
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
            menuStrip1 = new MenuStrip();
            cRUDToolStripMenuItem = new ToolStripMenuItem();
            destinoToolStripMenuItem1 = new ToolStripMenuItem();
            actividadToolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            clienteToolStripMenuItem = new ToolStripMenuItem();
            ventaYRegistroToolStripMenuItem = new ToolStripMenuItem();
            ventaToolStripMenuItem = new ToolStripMenuItem();
            registroToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cRUDToolStripMenuItem, ventaYRegistroToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cRUDToolStripMenuItem
            // 
            cRUDToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { destinoToolStripMenuItem1, actividadToolStripMenuItem1, toolStripMenuItem3, clienteToolStripMenuItem });
            cRUDToolStripMenuItem.Name = "cRUDToolStripMenuItem";
            cRUDToolStripMenuItem.Size = new Size(50, 20);
            cRUDToolStripMenuItem.Text = "CRUD";
            // 
            // destinoToolStripMenuItem1
            // 
            destinoToolStripMenuItem1.Name = "destinoToolStripMenuItem1";
            destinoToolStripMenuItem1.Size = new Size(180, 22);
            destinoToolStripMenuItem1.Text = "Destino";
            destinoToolStripMenuItem1.Click += destinoToolStripMenuItem1_Click;
            // 
            // actividadToolStripMenuItem1
            // 
            actividadToolStripMenuItem1.Name = "actividadToolStripMenuItem1";
            actividadToolStripMenuItem1.Size = new Size(180, 22);
            actividadToolStripMenuItem1.Text = "Actividad";
            actividadToolStripMenuItem1.Click += actividadToolStripMenuItem1_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(180, 22);
            toolStripMenuItem3.Text = "Itinerario";
            toolStripMenuItem3.Click += toolStripMenuItem3_Click;
            // 
            // clienteToolStripMenuItem
            // 
            clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            clienteToolStripMenuItem.Size = new Size(180, 22);
            clienteToolStripMenuItem.Text = "Cliente";
            clienteToolStripMenuItem.Click += clienteToolStripMenuItem_Click;
            // 
            // ventaYRegistroToolStripMenuItem
            // 
            ventaYRegistroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ventaToolStripMenuItem, registroToolStripMenuItem });
            ventaYRegistroToolStripMenuItem.Name = "ventaYRegistroToolStripMenuItem";
            ventaYRegistroToolStripMenuItem.Size = new Size(100, 20);
            ventaYRegistroToolStripMenuItem.Text = "Venta y registro";
            // 
            // ventaToolStripMenuItem
            // 
            ventaToolStripMenuItem.Name = "ventaToolStripMenuItem";
            ventaToolStripMenuItem.Size = new Size(180, 22);
            ventaToolStripMenuItem.Text = "Venta";
            // 
            // registroToolStripMenuItem
            // 
            registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            registroToolStripMenuItem.Size = new Size(180, 22);
            registroToolStripMenuItem.Text = "Registro";
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainView";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem itinerarioToolStripMenuItem;
        private ToolStripMenuItem cRUDToolStripMenuItem;
        private ToolStripMenuItem destinoToolStripMenuItem1;
        private ToolStripMenuItem actividadToolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem clienteToolStripMenuItem;
        private ToolStripMenuItem ventaYRegistroToolStripMenuItem;
        private ToolStripMenuItem ventaToolStripMenuItem;
        private ToolStripMenuItem registroToolStripMenuItem;
    }
}