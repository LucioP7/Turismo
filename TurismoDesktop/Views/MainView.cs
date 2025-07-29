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

        private void destinoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DestinoView destinoView = new DestinoView();
            destinoView.ShowDialog();
        }
    }
}
