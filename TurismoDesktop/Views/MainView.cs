using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TurismoDesktop.Views
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void destinoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DestinoView destinoView = new DestinoView();
            destinoView.ShowDialog();
        }

        private void actividadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ActividadView actividadView = new ActividadView();
            actividadView.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ItinerarioView itinerarioView = new ItinerarioView();
            itinerarioView.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClienteView clienteView = new ClienteView();
            clienteView.ShowDialog();
        }
    }
}
