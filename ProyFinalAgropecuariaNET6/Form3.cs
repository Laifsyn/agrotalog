using DotNext;
using System.Data;
using static proyFinalAgropecuaria.frmClientes;

namespace proyFinalAgropecuaria
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        public enum ClientesError
        {
            Success,
            NombreVacio = 1,
            EmailVacio,
            TipoClienteInvalido
        }

        public enum TipoCliente
        {
            Minorista,
            Mayorista
        }


        public struct Clientes
        {
            public string Nombre;
            public string Direcion;
            public string Telefono;
            public string Email;
            public TipoCliente TipoCliente;

            public static Result<Clientes, ClientesError> Crear(string nombre, string direccion, string telefono, string email, string tipoClienteStr)
            {
                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return new(ClientesError.NombreVacio);
                }
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new(ClientesError.EmailVacio);
                }

                TipoCliente tipoCliente;
                {
                    // FIXME: Parsing should be done in a standalone function
                    switch (tipoClienteStr.ToLower())
                    {
                        case "minorista":
                            tipoCliente = TipoCliente.Minorista;
                            break;
                        case "mayorista":
                            tipoCliente = TipoCliente.Mayorista;
                            break;
                        default:
                            return new(ClientesError.TipoClienteInvalido);
                    }
                }

                return new Clientes
                {
                    Nombre = nombre,
                    Direcion = direccion,
                    Telefono = telefono,
                    Email = email,
                    TipoCliente = tipoCliente
                };
            }
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
            txtId.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            cmbTipoCliente.Text = "";
            btnGuardar.Text = "Guardar";
        }

        public void CargarProductos()
        {
            string sql = "SELECT * FROM Clientes";
            BDAgro bd = BDAgro.FromStatic();
            DataTable dt = bd.EjecutarConsulta(sql);
            dgvClientes.DataSource = dt;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            //    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
            //    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
            //    string.IsNullOrWhiteSpace(txtEmail.Text) ||
            //    string.IsNullOrWhiteSpace(cmbTipoCliente.Text))
            //{
            //    MessageBox.Show("Por favor, complete todos los campos", "Error",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            string sql;
            BDAgro bd = BDAgro.FromStatic();

            var newCliente = Clientes.Crear(
                txtNombre.Text,
                txtDireccion.Text,
                txtTelefono.Text,
                txtEmail.Text,
                cmbTipoCliente.Text
            );

            if (btnGuardar.Text == "Actualizar")
            {
                sql = @"UPDATE Clientes 
               SET nombre = $nombre,
                   direccion = $direccion,
                   telefono = $telefono,
                   email = $email,
                   tipoCliente = $tipoCliente
               WHERE id = $id";

                bool actualizado = bd.EjecutarComandoConResultado(sql,
                    ("$nombre", txtNombre.Text),
                    ("$direccion", txtDireccion.Text),
                    ("$telefono", txtTelefono.Text),
                    ("$email", txtEmail.Text),
                    ("$tipoCliente", cmbTipoCliente.Text),
                    ("$id", txtId.Text)
                );


                if (actualizado)
                {
                    MessageBox.Show("Cliente actualizado correctamente.");
                    CargarProductos();
                }
                else
                {
                    MessageBox.Show("No se encontró el cliente o no se realizaron cambios.");
                }
            }
            else if (btnGuardar.Text == "Guardar")
            {
                if (!newCliente.TryGet(out Clientes clientes))
                {
                    ClientesError error = newCliente.Error!;
                    string errMsg = "";
                    switch (error)
                    {
                        case ClientesError.NombreVacio:
                            errMsg = "El campo de Nombre no puede estar vacío.";
                            break;
                        case ClientesError.EmailVacio:
                            errMsg = "El campo de Email no puede estar vacío.";
                            break;
                        case ClientesError.TipoClienteInvalido:
                            errMsg = $"El Tipo de Cliente `{cmbTipoCliente.Text}` no es válido.";
                            break;
                    }
                    MessageBox.Show(errMsg, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sql = "INSERT INTO Clientes (Nombre, Direccion, Telefono, Email, TipoCliente) VALUES ($nombre,$direccion,$telefono,$email,$tipoCliente)";

                try
                {
                    MessageBox.Show($"Tipo de cliente: `{clientes.TipoCliente}`");
                    bd.EjecutarComando(sql,
                        ("$nombre", clientes.Nombre),
                        ("$direccion", clientes.Direcion),
                        ("$telefono", clientes.Telefono),
                        ("$email", clientes.Email),
                        ("$tipoCliente", clientes.TipoCliente.ToString()));

                    MessageBox.Show("Producto agregado correctamente.");

                    // 🔄 REFRESCAR EL DATAGRIDVIEW
                    CargarProductos();

                    // 4️⃣ Limpiar los campos
                    txtNombre.Clear();
                    txtDireccion.Clear();
                    txtTelefono.Clear();
                    txtEmail.Clear();
                    cmbTipoCliente.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el producto: " + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Lógica que implementará tu compañero
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
            string sql = "DELETE FROM Productos WHERE Id=$id";

            if (!int.TryParse(txtId.Text, out int idCliente))
            {
                MessageBox.Show("Ingrese un ID válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BDAgro BD = BDAgro.FromStatic();

            bool exito = BD.EjecutarComandoConResultado(sql, ("$id", idCliente));
            if (exito)
            {
                MessageBox.Show(this, "Cliente eliminado exitosamente.", "Éxito",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
            }
            else
            {
                MessageBox.Show(this, "Error al eliminar el cliente.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void frmCliente_Load(object sender, EventArgs e)
        {
            CargarProductos();

            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvClientes.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDireccion.Text = dgvClientes.Rows[e.RowIndex].Cells["Direccion"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtEmail.Text = dgvClientes.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                cmbTipoCliente.Text = dgvClientes.Rows[e.RowIndex].Cells["TipoCliente"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
