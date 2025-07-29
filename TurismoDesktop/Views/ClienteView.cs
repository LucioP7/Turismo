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
    public partial class ClienteView : Form
    {
        private readonly IGenericService<Cliente> ClienteService = new GenericService<Cliente>();

        private BindingSource ListaCliente = new BindingSource();
        private List<Cliente> FiltroLista = new List<Cliente>();
        private Cliente? ClienteCurrent;

        public ClienteView()
        {
            InitializeComponent();
            dataGridClienteView.DataSource = ListaCliente;

            // Cargar datos cuando el formulario esté listo
            this.Load += async (s, e) => await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadGrid();
        }


        private async Task LoadGrid()
        {
            var Clientes = await ClienteService.GetAllAsync(string.Empty);
            var lista = Clientes?.Where(d => !d.Eliminado).ToList() ?? new List<Cliente>();

            ListaCliente.DataSource = lista;
            FiltroLista = lista;
            //dataGridClienteView.Columns[0].Visible = false;
            //dataGridClienteView.Columns[5].Visible = false;
            //dataGridClienteView.Columns[6].Visible = false;
            //dataGridClienteView.Columns[7].Visible = false;
            dataGridClienteView.Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClienteCurrent = (Cliente)ListaCliente.Current;

            if (ClienteCurrent != null)
            {
                txtNombre.Text = ClienteCurrent.Nombre;
                txtApellido.Text = ClienteCurrent.Apellido;
                txtDni.Text = ClienteCurrent.Documento;
                dtpNac.Value = ClienteCurrent.FechaNac;
                txtEmail.Text = ClienteCurrent.Email;
                txtTelefono.Text = ClienteCurrent.Telefono;
                txtDireccion.Text = ClienteCurrent.Direccion;
                txtCiudad.Text = ClienteCurrent.Ciudad;
                txtProvincia.Text = ClienteCurrent.Provincia;
                txtPais.Text = ClienteCurrent.Pais;

                tabControl1.SelectedTab = tabPageAddEdit;
            }
            else
            {
                MessageBox.Show("Seleccione un Cliente para modificar.");
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ListaCliente.Current is Cliente Cliente)
            {
                var confirmResult = MessageBox.Show(
                    "¿Está seguro de que desea eliminar este Cliente?",
                    "Confirmación de eliminación",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    Cliente.Eliminado = true; // Marcar como eliminado
                    await ClienteService.UpdateAsync(Cliente); // Actualizar el Cliente
                    await LoadGrid(); // Recargar la lista
                }
            }
            else
            {
                MessageBox.Show("Seleccione un Cliente para eliminar.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtDni.Text = string.Empty;
            dtpNac.Value = DateTime.Now;
            txtEmail.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtProvincia.Text = string.Empty;
            txtPais.Text = string.Empty;
            ClienteCurrent = null;

            tabControl1.SelectedTab = tabPageAddEdit;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var Cliente = new Cliente()
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Documento = txtDni.Text,
                FechaNac = dtpNac.Value,
                Email = txtEmail.Text,
                Telefono = txtTelefono.Text,
                Direccion = txtDireccion.Text,
                Ciudad = txtCiudad.Text,
                Provincia = txtProvincia.Text,
                Pais = txtPais.Text,
                Eliminado = false
            };

            //var json = JsonSerializer.Serialize(Cliente, new JsonSerializerOptions { WriteIndented = true });
            //MessageBox.Show(json);


            if (ClienteCurrent != null)
            {
                Cliente.Id = ClienteCurrent.Id;
                await ClienteService.UpdateAsync(Cliente);
                MessageBox.Show("Cliente modificado correctamente.");
            }
            else
            {
                await ClienteService.AddAsync(Cliente);
                MessageBox.Show("Cliente agregado correctamente.");
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
            var filtroCliente = FiltroLista
                .Where(d => d.Nombre.Contains(txtFiltro.Text, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ListaCliente.DataSource = filtroCliente;
            dataGridClienteView.Refresh();
        }

    }
}

