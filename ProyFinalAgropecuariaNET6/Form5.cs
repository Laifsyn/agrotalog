using DotNext;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyFinalAgropecuaria
{
    public partial class frmVentas : Form
    {
        public frmVentas()
        {
            InitializeComponent();
            dgvProductos.Columns.Add("Producto", "Producto");
            dgvProductos.Columns.Add("Cantidad", "Cantidad");
            dgvProductos.Columns.Add("Precio", "Precio");
            dgvProductos.Columns.Add("Subtotal", "Subtotal");
            dgvProductos.AllowUserToAddRows = true;
            dgvProductos.AllowUserToDeleteRows = true;
            dgvProductos.ReadOnly = false;

        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private BDAgro db()
        {
            BDAgro bd = BDAgro.FromStatic();
            return bd;
        }

        private void CargarClientes()
        {
            if (cmbClientes.Text == "Venta")
            {
                string sql = @"SELECT Id, Nombre 
                   FROM Clientes
                   ORDER BY Nombre";

                DataTable dt = db().EjecutarConsulta(sql);

                cmbClientes.DataSource = null;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No hay clientes activos registrados");
                    return;
                }

                cmbClientes.DisplayMember = "Nombre";
                cmbClientes.ValueMember = "Id";
                cmbClientes.DataSource = dt;
                cmbClientes.SelectedIndex = -1;
            }
            else if (cmbClientes.Text == "Compra")
            {
                lblCliente.Text = "Proveedor:";
            }

        }



        private void btnNuevo_Click(object sender, EventArgs e)
        {
            dgvProductos.Columns.Clear();
            if (cmbClientes.Text == "Ventas")
            {
                dgvProductos.Columns.Add("Producto", "Producto");
                dgvProductos.Columns.Add("Cantidad", "Cantidad");
                dgvProductos.Columns.Add("Precio", "Precio");
                dgvProductos.Columns.Add("Subtotal", "Subtotal");
            }
            else if (cmbClientes.Text == "Compras")
            {
                dgvProductos.Columns.Add("Producto", "Producto");
                dgvProductos.Columns.Add("Cantidad", "Cantidad");
                dgvProductos.Columns.Add("Precio", "Precio");
                dgvProductos.Columns.Add("Subtotal", "Subtotal");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
        }

        private void cmbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClientes.Text == "Ventas")
            {
                dgvProductos.Columns.Clear();
                lblCliente.Text = "Cliente:";
            }
            else if (cmbClientes.Text == "Compras")
            {
                dgvProductos.Columns.Clear();
                lblCliente.Text = "Proveedor:";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

namespace CompraVenta
{
    /// <summary>
    /// Placeholder for the Unit Type
    /// </summary>
    class Void { }

    public enum ClientKind
    {
        Minorista,
        Mayorista,
    }


    /// <summary>
    /// Guarda el estado de un cliente dado.
    /// </summary>
    struct ClientHistory
    {
        public string nombre;
        public int clientId;
        public ClientKind kind;
        public List<DetalleFactura> facturas;

        static Result<ClientHistory> FromId(SqliteConnection conn, int clientId)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();

            /// Find the provided Client's data.
            command.CommandText = "Select * from Clientes where Id=$id";
            command.Parameters.AddWithValue("$id", clientId);

            SqliteDataReader reader = command.ExecuteReader();
            // FIXME: Possible off by one error. 
            if (!reader.Read())
            {
                var except = new ArgumentException($"Client's ID {clientId} doesn't exists in the database");
                return new Result<ClientHistory>(except);
            }
            string nombre = reader.GetString("Nombre");
            string clientKind_string = reader.GetString("TipoCliente");
            reader.Close();

            if (!Enum.TryParse(clientKind_string, true, out ClientKind clientKind))
                return new Result<ClientHistory>(new DataException($"the Client Kind `{clientKind_string}` can't be parsed into ClientKind"));

            List<DetalleFacturaVenta> facturas = new();
            // Find the given client's sales history
            {
                // cleanup old parameters
                command.Parameters.Clear();

                command.CommandText = "SELECT * from Ventas where ClienteId=$clientId";
                command.Parameters.AddWithValue("$clientId", clientId);

                // Reuse variable due to inability to shadow old variables.
                reader = command.ExecuteReader();
                var errors = new List<Exception>();
                while (!reader.Read())
                {
                    int ventaId = reader.GetInt32("Id");
                    Result<DetalleFacturaVenta> result = DetalleFacturaVenta.TryFromVentaId(conn, ventaId);
                    if (!result.IsSuccessful)
                        errors.Add(result.Error);
                    else
                        facturas.Add(result.Value);
                }
                // Early return on any single errors. Returning the errors as Aggregates
                if (errors.Count > 0)
                {
                    var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of Facturas", errors);
                    return new Result<ClientHistory>(aggregatedErrors);
                }

            }
            reader.Close();
            var client = new ClientHistory { clientId = clientId, facturas = new List<DetalleFacturaVenta>(), nombre = nombre, kind = clientKind };
            return client;
        }
    }


    /// <summary>
    /// Informacion detallada de un registro de Factura de Venta.
    /// </summary>
    struct DetalleFacturaVenta
    {
        /// <summary>
        ///  ID de la venta.
        /// </summary>
        int ventaId;
        DateTime fecha;
        List<FacturaProducto> listaProductos;


        /// <summary>
        /// Itera la lista de Productos para obtener el total de la factura.
        /// </summary>
        /// <returns></returns>
        public double TotalFactura()
        {
            double accumulator = 0.0;
            foreach (FacturaProducto product in this.listaProductos)
                accumulator += product.cantidad * product.precioUnitario;
            return accumulator;
        }

        public static Result<DetalleFacturaVenta> TryFromVentaId(SqliteConnection conn, int ventaId)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Ventas where Id=$id";
            command.Parameters.Add("$id", ventaId);
        }
    }

    /// <summary>
    /// Los productos registrados en una factura pueden ser 
    /// categorizados como productos registrados en una 
    /// Compra, o en una Venta
    /// </summary>
    public enum FacturaProductType
    {
        Compra, Venta
    }

    /// <summary>
    /// Producto individual de una factura
    /// </summary>
    struct FacturaProducto
    {
        public int productId;
        public string productName;
        public int cantidad;
        public double precioUnitario;
        public FacturaProductType type;
    }
}