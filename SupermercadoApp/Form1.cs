using System;
using System.Globalization;
using System.Windows.Forms;
using SupermercadoApp.Data;

namespace SupermercadoApp
{
    public partial class Form1 : Form
    {
        Datos data = new Datos();
        public Form1()
        {
            InitializeComponent();

            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            // INTENTO 1: columnas más comunes del repo.
            string sql = "SELECT id_producto, id_categoria, nombre, precio, stock FROM productos ORDER BY 1;";

            // Si tu DDL usa otros nombres, cambia 'precio' o 'stock' por los reales.
            // Como respaldo, si falla por columnas, probamos con SELECT *:
            try
            {
                dgvProductos.DataSource = data.GetDataTable(sql);
            }
            catch
            {
                dgvProductos.DataSource = data.GetDataTable("SELECT * FROM productos ORDER BY 1;");
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            // Carga por NOMBRE de columna (ajusta si nombres difieren en tu DDL)
            try
            {
                txtIdCategoria.Text = dgvProductos.CurrentRow.Cells["id_categoria"]?.Value?.ToString() ?? "";
                txtNombre.Text = dgvProductos.CurrentRow.Cells["nombre"]?.Value?.ToString() ?? "";
                txtPrecio.Text = dgvProductos.CurrentRow.Cells["precio"]?.Value?.ToString() ?? "";
                txtStock.Text = dgvProductos.CurrentRow.Cells["stock"]?.Value?.ToString() ?? "";
            }
            catch
            {
                // Si nombres no coinciden, usa por ÍNDICE como plan B
                // (0=id, 1=posible id_categoria, 2=nombre, 3=precio, 4=stock... depende de tu DDL)
                if (dgvProductos.CurrentRow.Cells.Count >= 5)
                {
                    txtIdCategoria.Text = dgvProductos.CurrentRow.Cells[1]?.Value?.ToString() ?? "";
                    txtNombre.Text = dgvProductos.CurrentRow.Cells[2]?.Value?.ToString() ?? "";
                    txtPrecio.Text = dgvProductos.CurrentRow.Cells[3]?.Value?.ToString() ?? "";
                    txtStock.Text = dgvProductos.CurrentRow.Cells[4]?.Value?.ToString() ?? "";
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // OJO: ajusta nombres exactos si en tu DDL se llaman distinto (ej. precio_unitario / existencia)
            try
            {
                int idCat = int.Parse(txtIdCategoria.Text);
                string nombre = txtNombre.Text.Trim();
                decimal precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
                int stock = int.Parse(txtStock.Text);

                string sql = $@"
INSERT INTO productos (id_categoria, nombre, precio, stock)
VALUES ({idCat}, '{nombre}', {precio.ToString(CultureInfo.InvariantCulture)}, {stock});";

                bool ok = data.ExecuteQuery(sql);
                MessageBox.Show(ok ? "Producto agregado" : "No se agregó");
                if (ok) CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica los datos. " + ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un registro.");
                return;
            }

            try
            {
                // Toma el ID de la PRIMERA columna (o por nombre si existe 'id_producto')
                int id;
                try
                {
                    id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id_producto"].Value);
                }
                catch
                {
                    id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
                }

                int idCat = int.Parse(txtIdCategoria.Text);
                string nombre = txtNombre.Text.Trim();
                decimal precio = decimal.Parse(txtPrecio.Text, CultureInfo.InvariantCulture);
                int stock = int.Parse(txtStock.Text);

                string sql = $@"
UPDATE productos
   SET id_categoria = {idCat},
       nombre       = '{nombre}',
       precio       = {precio.ToString(CultureInfo.InvariantCulture)},
       stock        = {stock}
 WHERE id_producto = {id};";

                bool ok = data.ExecuteQuery(sql);
                MessageBox.Show(ok ? "Producto actualizado" : "No se actualizó");
                if (ok) CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica los datos. " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un registro.");
                return;
            }

            int id;
            try
            {
                id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["id_producto"].Value);
            }
            catch
            {
                id = Convert.ToInt32(dgvProductos.CurrentRow.Cells[0].Value);
            }

            var r = MessageBox.Show("¿Eliminar el producto seleccionado?", "Confirmar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;

            string sql = $"DELETE FROM productos WHERE id_producto = {id};";
            bool ok = data.ExecuteQuery(sql);
            MessageBox.Show(ok ? "Producto eliminado" : "No se eliminó");
            if (ok) CargarProductos();
        }
    }
}
    

