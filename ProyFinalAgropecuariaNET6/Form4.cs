using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace proyFinalAgropecuaria
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        public struct Proveedor
        {
            public int Id;
            public string Nombre;
            public string Telefono;
            public string Email;
            public string Direccion;
        }

        public void Validar(Proveedor proveedor)
        {
            // 1️⃣ Todos los campos llenos
            if (string.IsNullOrWhiteSpace(proveedor.Nombre) ||
                string.IsNullOrWhiteSpace(proveedor.Telefono) ||
                string.IsNullOrWhiteSpace(proveedor.Email) ||
                string.IsNullOrWhiteSpace(proveedor.Direccion))
            {
                throw new ArgumentException("Todos los campos deben estar llenos.");
            }

            // 2️⃣ Teléfono solo números
            if (!proveedor.Telefono.All(char.IsDigit))
            {
                throw new FormatException("El teléfono solo debe contener números.");
            }
        }

        private BDAgro db()
        {
            BDAgro bd = BDAgro.FromStatic();
            return bd;
        }

        public void CargarProveedor()
        {
            string sql = "SELECT * FROM Proveedores";
            DataTable dt = db().EjecutarConsulta(sql);
            dgvProveedores.DataSource = dt;
        }

        public void AgregarProveedor(Proveedor proveedor)
        {
            string sql = "";

            if (btnGuardar.Text == "Guardar")
            {
                sql = "INSERT INTO Proveedores (Nombre, Telefono, Email, Direccion) VALUES ($nombre,$telefono,$email,$direccion)";
            }
            else if (btnGuardar.Text == "Actualizar")
            {
                sql = "UPDATE Proveedores SET Nombre=$nombre, Telefono=$telefono, Email=$email, Direccion=$direccion WHERE Id=" + proveedor.Id;
            }

            db().EjecutarComando(sql,
                    ("$nombre", proveedor.Nombre),
                    ("$telefono", proveedor.Telefono),
                    ("$email", proveedor.Email),
                    ("$direccion", proveedor.Direccion));
        }

        public bool EliminarProveedor(int id)
        {
            string sql = "DELETE FROM Proveedores WHERE Id=$id";
            return db().EjecutarComandoConResultado(sql, ("$id", id));
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtDireccion.Text = "";
            btnGuardar.Text = "Guardar";
            // Lógica que implementará tu compañero
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var proveedor = new Proveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                Validar(proveedor);
                AgregarProveedor(proveedor);
                CargarProveedor();
                txtId.Text = "";
                txtNombre.Text = "";
                txtTelefono.Text = "";
                txtEmail.Text = "";
                txtDireccion.Text = "";

                MessageBox.Show("Proveedor guardado correctamente");
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos incompletos");
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Formato incorrecto");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado.\n" + ex.Message);
            }

            // Lógica que implementará tu compañero
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtId.Text, out int id))
            {
                bool eliminado = EliminarProveedor(id);
                if (eliminado)
                {
                    MessageBox.Show("Proveedor eliminado correctamente.");
                    CargarProveedor();
                }
                else
                {
                    MessageBox.Show("No se encontró el proveedor o no se pudo eliminar.");
                }
            }
            else
            {
                MessageBox.Show("ID de proveedor inválido.");
            }
            // Lógica que implementará tu compañero
        }
        private void frmProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedor();

            dgvProveedores.ReadOnly = true;
            dgvProveedores.AllowUserToAddRows = false;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvProveedores.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvProveedores.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtTelefono.Text = dgvProveedores.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvProveedores.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                txtDireccion.Text = dgvProveedores.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
        }
    }
}
