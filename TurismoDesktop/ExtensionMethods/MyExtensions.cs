using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.ExtensionMethods
{
    public static class MyExtensions
    {

        public static int IdSeleccionado(this ComboBox combo)
        {
            if (combo.SelectedValue != null && combo.SelectedValue.GetType() == typeof(int))
            {
                return (int)combo.SelectedValue;
            }
            else
                return 0;
        }
        public static string ObtenerColumna(this DataGridView grid, string columna)
        {
            if (grid.CurrentRow != null && grid.RowCount > 0)
                return grid.CurrentRow.Cells[columna].Value.ToString();
            else
                return "";
        }


        public static void MensajeAdvertenciaDeSalida(this Form form)
        {
            var respuesta = MessageBox.Show($"¿Está seguro que desea salir del formulario {form.Text}", "Atención", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
                form.Close();
        }
        public static int IdSeleccionado(this DataGridView grid)
        {
            return int.Parse(grid.CurrentRow.Cells[0].Value.ToString());
        }
        //método sobre las grillas que oculta las columnas que normalmente no se muestran




        public static void DarColorAFilas(this DataGridView grid, int nroColumna, Func<decimal, bool> condicion, Color color)
        {
            foreach (DataGridViewRow row in grid.Rows)
                if (row.Cells.Count > nroColumna &&
                    condicion(Convert.ToDecimal(row.Cells[nroColumna].Value)))
                {
                    row.DefaultCellStyle.BackColor = color;
                }
        }
        public static void SeleccionarFilaNuevaOEditada(this DataGridView grid, int id)
        {
            foreach (DataGridViewRow fila in grid.Rows)
            {
                if ((int)fila.Cells[0].Value == id)
                {
                    grid.CurrentCell = fila.Cells[0];
                    break;
                }
            }
        }

        public static void OcultarColumnas(this DataGridView grid, string[] columnasAOcultar)
        {
            //form.EstaVisible() &&
            if (grid.RowCount > 0)
            {
                //oculta siempre las columnas que terminan con Id, ejemplo UsuarioId
                foreach (string columnaAOcultar in columnasAOcultar)
                {
                    foreach (DataGridViewColumn columna in grid.Columns)
                    {
                        if (columna.Name == columnaAOcultar)
                        {
                            columna.Visible = false;
                        }
                    }
                }
            }
        }



        public static void EstablecerAnchoDeColumnas(this DataGridView grid, int[] anchos)
        {
            //form.EstaVisible() &&
            if (grid.ColumnCount > 0)
            {
                int i = 0;
                foreach (int ancho in anchos)
                {
                    grid.Columns[i].Width = ancho;
                    i++;
                }
            }
        }





        public static bool EstaVisible(this Form form)
        {
            return Application.OpenForms.OfType<Form>().Where(f => f.Name == form.Name).SingleOrDefault() != null;
        }

        public static void CopyPropertiesTo<T>(this T source, T destination)
        {
            if (source == null || destination == null)
            {
                throw new ArgumentNullException("Objeto de origen o destino son nulos");
            }

            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (property.CanRead && property.CanWrite)
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(destination, value, null);
                }
            }
        }



    }
}
