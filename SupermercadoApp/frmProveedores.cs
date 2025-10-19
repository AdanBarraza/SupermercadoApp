using SupermercadoApp.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SupermercadoApp
{
    public partial class frmProveedores : Form
    {
        Datos data = new Datos();
        public frmProveedores()
        {
            InitializeComponent();
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
        }

        private void btnCargarProv_Click(object sender, EventArgs e)
        {
            CargarProveedores();
        }
        private void CargarProveedores()
        {
            // Ajusta los nombres si tu DDL usa otros (ej. nro_tel_princ en vez de telefono)
            string sql = @"SELECT id_proveedor, empresa, tipo_productos, telefono, email
                           FROM proveedores
                           ORDER BY id_proveedor;";
            try
            {
                dgvProveedores.DataSource = data.GetDataTable(sql);
            }
            catch
            {
                // Plan B si los nombres no coinciden
                dgvProveedores.DataSource = data.GetDataTable("SELECT * FROM proveedores ORDER BY 1;");
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null) return;

            // Intenta por nombre de columna:
            try
            {
                txtEmpresa.Text = dgvProveedores.CurrentRow.Cells["empresa"]?.Value?.ToString() ?? "";
                txtTipoProductos.Text = dgvProveedores.CurrentRow.Cells["tipo_productos"]?.Value?.ToString() ?? "";
                txtTelefono.Text = dgvProveedores.CurrentRow.Cells["telefono"]?.Value?.ToString() ?? "";
                txtEmail.Text = dgvProveedores.CurrentRow.Cells["email"]?.Value?.ToString() ?? "";
            }
            catch
            {
                // Si falla por nombres, intenta por índice (ajusta si hay más/menos columnas)
                if (dgvProveedores.CurrentRow.Cells.Count >= 5)
                {
                    // [0]=id, [1]=empresa, [2]=tipo_productos, [3]=telefono, [4]=email
                    txtEmpresa.Text = dgvProveedores.CurrentRow.Cells[1]?.Value?.ToString() ?? "";
                    txtTipoProductos.Text = dgvProveedores.CurrentRow.Cells[2]?.Value?.ToString() ?? "";
                    txtTelefono.Text = dgvProveedores.CurrentRow.Cells[3]?.Value?.ToString() ?? "";
                    txtEmail.Text = dgvProveedores.CurrentRow.Cells[4]?.Value?.ToString() ?? "";
                }
            }
        }

        private void btnAgregarProv_Click(object sender, EventArgs e)
        {
            try
            {
                string empresa = txtEmpresa.Text.Trim();
                string tipoProductos = txtTipoProductos.Text.Trim();
                string telefono = txtTelefono.Text.Trim(); // o nro_tel_princ
                string email = txtEmail.Text.Trim();

                string sql = $@"
INSERT INTO proveedores (empresa, tipo_productos, telefono, email)
VALUES ('{empresa}', '{tipoProductos}', '{telefono}', '{email}');";

                bool ok = data.ExecuteQuery(sql);
                MessageBox.Show(ok ? "Proveedor agregado" : "No se agregó");
                if (ok) CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica los datos. " + ex.Message);
            }
        }

        private void btnActualizarProv_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proveedor.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id_proveedor"].Value);

                string empresa = txtEmpresa.Text.Trim();
                string tipoProductos = txtTipoProductos.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();

                string sql = $@"
UPDATE proveedores
   SET empresa        = '{empresa}',
       tipo_productos = '{tipoProductos}',
       telefono       = '{telefono}',
       email          = '{email}'
 WHERE id_proveedor   = {id};";

                bool ok = data.ExecuteQuery(sql);
                MessageBox.Show(ok ? "Proveedor actualizado" : "No se actualizó");
                if (ok) CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verifica los datos. " + ex.Message);
            }
        }

        private void btnEliminarProv_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proveedor.");
                return;
            }

            int id = Convert.ToInt32(dgvProveedores.CurrentRow.Cells["id_proveedor"].Value);

            var r = MessageBox.Show("¿Eliminar el proveedor seleccionado?", "Confirmar",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;

            string sql = $"DELETE FROM proveedores WHERE id_proveedor = {id};";
            bool ok = data.ExecuteQuery(sql);
            MessageBox.Show(ok ? "Proveedor eliminado" : "No se eliminó");
            if (ok) CargarProveedores();
        }
    }
}

