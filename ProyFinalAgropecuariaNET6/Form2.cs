using DotNext;
using System.Data;

namespace proyFinalAgropecuaria
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Errors related to Product instantiation
        public enum ProductError
        {
            Success,
            BlankName = 1,
            NegativePrice,
        }

        public struct Productos
        {
            public string Nombre;
            public string Descripcion;
            public double Precio;
            public int Stock;
            public string Unidad;

            public static Result<Productos, ProductError> New(string nombre, string descripcion, double precio)
            {
                if (precio < 0.0)
                {
                    return new(ProductError.NegativePrice);
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    return new(ProductError.BlankName);
                }

                var producto = new Productos
                {
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Precio = precio
                };
                return producto;
            }

            public void Deconstruct(out string nombre, out string descripcion,
                                    out double precio, out int stock, out string unidad)
            {

                nombre = this.Nombre;
                descripcion = this.Descripcion;
                precio = this.Precio;
                stock = this.Stock;
                unidad = this.Unidad;
            }

        }

        // 2️⃣ Método para agregar producto
        public void AgregarProducto(Productos product_to_add)
        {

            // Destructure the struct
            var (nombre, descripcion, precio, stock, unidad) = product_to_add;
            string sql = "INSERT INTO Productos (Nombre, Descripcion, Precio) VALUES ($nombre,$descripcion,$precio)";
            BDAgro bd = BDAgro.FromStatic();
            bd.EjecutarComando(sql,
                ("$nombre", nombre),
                ("$descripcion", descripcion),
                ("$precio", precio));
        }

        public void CargarProductos()
        {
            string sql = "SELECT * FROM Productos";
            BDAgro bd = BDAgro.FromStatic();
            DataTable dt = bd.EjecutarConsulta(sql);
            dgvProductos.DataSource = dt;
        }

        // 4️⃣ Nuevo producto
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            btnGuardar.Text = "Guardar";
        }

        // 3️⃣ Guardar el producto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            //    string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
            //    string.IsNullOrWhiteSpace(txtPrecio.Text) ||
            //    string.IsNullOrWhiteSpace(txtStock.Text) ||
            //    string.IsNullOrWhiteSpace(txtUnidad.Text))
            //{
            //    MessageBox.Show("Por favor, complete todos los campos", "Error",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if(btnGuardar.Text == "Actualizar")
            {
                BDAgro bd = BDAgro.FromStatic();
                String sql = "UPDATE Productos SET Nombre=$nombre, Descripcion=$descripcion, Precio=$precio WHERE Id=$id";
                bool actualizado = bd.EjecutarComandoConResultado(sql,
                    ("$nombre", txtNombre.Text),
                    ("$descripcion", txtDescripcion.Text),
                    ("$precio", decimal.Parse(txtPrecio.Text)),
                    ("$id", int.Parse(txtId.Text))
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
                Result<Productos, ProductError> productResult = Productos.New(
                txtNombre.Text,
                txtDescripcion.Text,
                double.Parse(txtPrecio.Text)
                );

                if (productResult.TryGet(out Productos producto) is false)
                {
                    switch (productResult.Error!)
                    {
                        case ProductError.NegativePrice:
                            MessageBox.Show("El precio no puede ser negativo.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case ProductError.BlankName:
                            MessageBox.Show("El nombre no puede estar vacío.", "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                    return;
                }


                try
                {
                    AgregarProducto(producto);

                    MessageBox.Show("Producto agregado correctamente.");

                    // 🔄 REFRESCAR EL DATAGRIDVIEW
                    CargarProductos();

                    // 4️⃣ Limpiar los campos
                    txtNombre.Clear();
                    txtDescripcion.Clear();
                    txtPrecio.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el producto: " + ex.Message);
                }
            }
        }
        // 5️⃣ Eliminar producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Productos WHERE Id=$id";

            if (!int.TryParse(txtId.Text, out int idProducto))
            {
                MessageBox.Show("Ingrese un ID válido.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            BDAgro bd = new BDAgro();

            bool eliminado = bd.EjecutarComandoConResultado(sql, ("$id", idProducto));

            if (eliminado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
                CargarProductos();
            }
            else
            {
                MessageBox.Show("No se encontró el ID. Ingrese un ID válido.");
            }
        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }


        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvProductos.Rows[e.RowIndex].Cells["Id"].Value.ToString();
                txtNombre.Text = dgvProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvProductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dgvProductos.Rows[e.RowIndex].Cells["Precio"].Value.ToString();
                btnGuardar.Text = "Actualizar";
            }
        }

    }
}
