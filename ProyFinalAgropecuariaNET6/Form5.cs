using CompraVenta;
using DotNext;
using Microsoft.Data.Sqlite;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static proyFinalAgropecuaria.frmClientes;

namespace proyFinalAgropecuaria
{
    public partial class frmVentas : Form
    {
        private BindingList<DetalleVenta> ventas = new();
        private BindingList<ClientHistory> clients;
        private BindingList<ProviderHistory> providers;
        /// <summary>
        /// Binds the list type for Compras and Ventas
        /// </summary>
        private ReceiptKind selectedReceiptKind = ReceiptKind.Venta;
        public frmVentas()
        {
            InitializeComponent();
            this.selectedReceiptKind= ReceiptKind.Venta;

            this.dgvVentas.AutoGenerateColumns = false;
            this.dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colVentaId",
                HeaderText = "ID",
                DataPropertyName = "ventaId"
            });

            this.dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "fecha"
            });


            // For dgvItems
            this.dgvItems.AutoGenerateColumns = false;

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "IdProducto",
                DataPropertyName = "id"
            });

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCantidad",
                HeaderText = "Cantidad",
                DataPropertyName = "cantidad"
            });

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrecioUnitario",
                HeaderText = "Precio",
                DataPropertyName = "precioUnitario"
            });

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductName",
                HeaderText = "Nombre",
                DataPropertyName = "productName"
            });

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductId",
                HeaderText = "Producto Id",
                DataPropertyName = "productId"
            });
            Result<List<ClientHistory>> clientsResult = ClientHistory.Load(BDAgro.FromStatic().new_connection());

            if (!clientsResult.IsSuccessful)
            {
                MessageBox.Show($"Error loading clients: {clientsResult.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.clients = new();
                return;
            }

            this.clients = new BindingList<ClientHistory>(clientsResult.Value);
            this.listClientes.DataSource = this.clients;
            this.listClientes.DisplayMember = "nombre";
            this.listClientes.ValueMember = "clientId";
        }

        private void listClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listClientes.SelectedItem is null) return;
            ClientHistory selectedClient = (ClientHistory)this.listClientes.SelectedItem;
            this.dgvVentas.DataSource = selectedClient.facturas;
            this.dgvVentas.Refresh();
        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvVentas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = this.dgvVentas.SelectedRows[0];

                DetalleVenta selectedVenta = (DetalleVenta)selectedRow.DataBoundItem;
                this.dgvItems.DataSource = selectedVenta.listaProductos;
                this.dgvItems.Refresh();
            }
        }

        private void cmbReceiptKind_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cmbReceiptKind.SelectedItem is null) return;
            else if (this.cmbReceiptKind.SelectedItem.ToString() == "Ventas")
            {
                this.selectedReceiptKind = ReceiptKind.Venta;
            }
            else if (this.cmbReceiptKind.SelectedItem.ToString() == "Compras")
            {
                this.selectedReceiptKind = ReceiptKind.Compra;
            }

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
    /// Historial de un cliente
    /// </summary>
    class ClientHistory
    {
        public required string nombre { get; set; } = "";
        public required int clientId { get; set; }
        public required ClientKind kind;
        public required BindingList<DetalleVenta> facturas = new();

        public static Result<List<ClientHistory>> Load(SqliteConnection conn)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();

            command.CommandText = "SELECT Id from Clientes";
            SqliteDataReader reader = command.ExecuteReader();
            List<ClientHistory> clients = new();
            var errors = new List<Exception>();
            while (reader.Read())
            {
                int clientId = reader.GetInt32("Id");
                Result<Optional<ClientHistory>> result = ClientHistory.FromId(conn, clientId);
                if (!result.IsSuccessful)
                    errors.Add(result.Error);
                else if (result.Value.HasValue)
                    clients.Add(result.Value.Value);
            }
            if (errors.Count > 0)
            {
                var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of Clients", errors);
                return new Result<List<ClientHistory>>(aggregatedErrors);
            }
            return clients;
        }

        static Result<Optional<ClientHistory>> FromId(SqliteConnection conn, int clientId)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();

            // Find the provided Client's data.
            command.CommandText = "Select * from Clientes where Id=$id";
            command.Parameters.AddWithValue("$id", clientId);

            SqliteDataReader reader = command.ExecuteReader();
            // FIXME: Possible off by one error. 
            if (!reader.Read())
            {
                var except = new ArgumentException($"Client's ID {clientId} doesn't exists in the database");
                return Optional.None<ClientHistory>();
            }
            string nombre = reader.GetString("Nombre");
            string clientKind_string = reader.GetString("TipoCliente");
            reader.Close();

            if (!Enum.TryParse(clientKind_string, true, out ClientKind clientKind))
                return new Result<Optional<ClientHistory>>(new DataException($"the Client Kind `{clientKind_string}` can't be parsed into ClientKind"));

            BindingList<DetalleVenta> facturas = new();
            // Find the given client's sales history
            {
                // Cleanup old parameters to avoid conflict
                command.Parameters.Clear();
                command.CommandText = "SELECT * from Ventas where ClienteId=$clientId";
                command.Parameters.AddWithValue("$clientId", clientId);

                // Reuse variable
                reader = command.ExecuteReader();
                var errors = new List<Exception>();
                while (reader.Read())
                {
                    int ventaId = reader.GetInt32("Id");
                    Result<Optional<DetalleVenta>> result = DetalleVenta.TryFromVentaId(conn, ventaId);
                    if (!result.IsSuccessful)
                        errors.Add(result.Error);
                    else if (result.Value.HasValue)
                        facturas.Add(result.Value.Value);
                }
                // If any errors, aggregate them up and return.
                if (errors.Count > 0)
                {
                    var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of Facturas", errors);
                    return new Result<Optional<ClientHistory>>(aggregatedErrors);
                }

            }
            reader.Close();

            var client = new ClientHistory { clientId = clientId, facturas = facturas, nombre = nombre, kind = clientKind };
            return Optional.Some(client);
        }
    }


    /// <summary>
    /// Informacion detallada de un registro de Factura de Venta.
    /// </summary>
    struct DetalleVenta
    {
        /// <summary>
        ///  ID de la venta.
        /// </summary>
        public required int ventaId { get; set; }
        public required DateTime fecha { get; set; }
        public required BindingList<FacturaItem> listaProductos;


        /// <summary>
        /// Itera la lista de Productos para obtener el total de la factura.
        /// </summary>
        /// <returns></returns>
        public double TotalFactura()
        {
            double accumulator = 0.0;
            foreach (FacturaItem product in this.listaProductos)
                accumulator += product.cantidad * product.precioUnitario;
            return accumulator;
        }

        public static Result<Optional<DetalleVenta>> TryFromVentaId(SqliteConnection conn, int ventaId)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Ventas where Id=$id";
            command.Parameters.AddWithValue("$id", ventaId);

            SqliteDataReader reader = command.ExecuteReader();
            // Return if not found
            if (!reader.Read())
                return Optional.None<DetalleVenta>();

            DateTime fecha = reader.GetDateTime("Fecha");
            reader.Close();
            // Retrieve list of products
            BindingList<FacturaItem> productos = new();
            command.Parameters.Clear();
            command.CommandText = "SELECT * FROM DetalleVentas where VentaId=$ventaId";
            command.Parameters.AddWithValue("$ventaId", ventaId);
            reader = command.ExecuteReader();
            var errors = new List<Exception>();
            while (reader.Read())
            {
                int productId = reader.GetInt32("Id");
                Result<Optional<FacturaItem>> result = FacturaItem.TryFromId(conn, productId, ReceiptKind.Venta);
                if (!result.IsSuccessful)
                    errors.Add(result.Error);
                else if (result.Value.HasValue)
                    productos.Add(result.Value.Value);
            }
            reader.Close();

            if (errors.Count > 0)
            {
                var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of FacturaItems", errors);
                return new Result<Optional<DetalleVenta>>(aggregatedErrors);
            }

            return Optional.Some(new DetalleVenta
            {
                ventaId = ventaId,
                fecha = fecha,
                listaProductos = productos
            });


        }
    }

    /// <summary>
    /// Los productos registrados en una factura pueden ser 
    /// categorizados como productos registrados en una 
    /// Compra, o en una Venta
    /// </summary>
    public enum ReceiptKind { Compra, Venta }

    /// <summary>
    /// Producto individual de una factura
    /// </summary>
    class FacturaItem
    {
        public required int id { get; set; }
        public required int productId { get; set; }
        public required string productName { get; set; }
        public required int cantidad { get; set; }
        public required double precioUnitario { get; set; }
        public required ReceiptKind type;

        public static Result<Optional<FacturaItem>> TryFromId(SqliteConnection conn, int itemId, ReceiptKind type)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            if (type == ReceiptKind.Compra)
                command.CommandText = "SELECT * FROM DetalleCompras where Id=$id";
            else if (type == ReceiptKind.Venta)
                command.CommandText = "SELECT * FROM DetalleVentas where Id=$id";
            else
                return new Result<Optional<FacturaItem>>(new ArgumentException($"El tipo de producto `{type}` no es válido"));
            command.Parameters.AddWithValue("$id", itemId);
            SqliteDataReader reader = command.ExecuteReader();
            // Return if not found
            if (!reader.Read())
                return Optional.None<FacturaItem>();
            int cantidad = reader.GetInt32("Cantidad");
            double precioUnitario = reader.GetDouble("PrecioUnitario");
            int productId = reader.GetInt32("ProductoId");
            reader.Close();

            // Retrieve product name
            command.Parameters.Clear();
            command.CommandText = "SELECT Nombre, Descripcion FROM Productos where Id=$prodId";
            command.Parameters.AddWithValue("$prodId", itemId);
            reader = command.ExecuteReader();
            if (!reader.Read())
                return new Result<Optional<FacturaItem>>(new DataException($"El producto con Id `{itemId}` no existe en la base de datos"));
            string productName = reader.GetString("Nombre");
            reader.Close();


            var product = new FacturaItem
            {
                id = itemId,
                productId = productId,
                cantidad = cantidad,
                productName = productName,
                precioUnitario = precioUnitario,
                type = type // FIXME: Maybe we don't need to attach the type?
            };
            return Optional.Some(product);
        }

        public double Total()
        {
            return this.cantidad * this.precioUnitario;
        }
    }

    class ProviderHistory
    {
        public required string nombre { get; set; }
        public required int id { get; set; }
        public required int providerId { get; set; }
        public required BindingList<DetalleCompra> facturas = new();

        public static Result<Optional<ProviderHistory>> TryFromId(SqliteConnection conn, int providerId)
        {

            conn.Open();
            SqliteCommand command = conn.CreateCommand();

            // Find the provided Provider's data.
            command.CommandText = "Select * from Proveedores where Id=$id";
            command.Parameters.AddWithValue("$id", providerId);

            SqliteDataReader reader = command.ExecuteReader();
            if (!reader.Read())
                return Optional.None<ProviderHistory>();
            string nombre = reader.GetString("Nombre");
            int id = reader.GetInt32("Id");
            reader.Close();

            BindingList<DetalleCompra> facturas = new();
            // Find the given provider's sales history
            {
                // Cleanup old parameters to avoid conflict
                command.Parameters.Clear();
                command.CommandText = "SELECT * from Compras where ProveedorId=$providerId";
                command.Parameters.AddWithValue("$providerId", providerId);

                // Reuse variable
                reader = command.ExecuteReader();
                var errors = new List<Exception>();
                while (reader.Read())
                {
                    // Collect each compra's ID
                    int compraId = reader.GetInt32("Id");
                    Result<Optional<DetalleCompra>> result = DetalleCompra.TryFromCompraId(conn, compraId);
                    if (!result.IsSuccessful)
                        errors.Add(result.Error);
                    else if (result.Value.HasValue)
                        facturas.Add(result.Value.Value);
                }

                // If any errors, aggregate them up and return.
                if (errors.Count > 0)
                {
                    var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of Facturas", errors);
                    return new Result<Optional<ProviderHistory>>(aggregatedErrors);
                }
            }
            reader.Close();

            var providerHistory = new ProviderHistory { facturas = facturas, id = id, providerId = providerId, nombre = nombre};
            return Optional.Some(providerHistory);
        }
    }

    class DetalleCompra
    {
        public required int compraId { get; set; }
        public required DateTime fecha { get; set; }
        public required BindingList<FacturaItem> listaProductos;

        public static Result<Optional<DetalleCompra>> TryFromCompraId(SqliteConnection conn, int compraId)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT * FROM Compras where Id=$id";
            command.Parameters.AddWithValue("$id", compraId);
            SqliteDataReader reader = command.ExecuteReader();

            // Return if not found
            if (!reader.Read())
                return Optional.None<DetalleCompra>();
            DateTime fecha = reader.GetDateTime("Fecha");

            reader.Close();
            // Retrieve list of products
            BindingList<FacturaItem> productos = new();
            command.Parameters.Clear();
            command.CommandText = "SELECT * FROM DetalleCompras where CompraId=$compraId";
            command.Parameters.AddWithValue("$compraId", compraId);
            reader = command.ExecuteReader();
            var errors = new List<Exception>();
            while (reader.Read())
            {
                int productId = reader.GetInt32("Id");
                Result<Optional<FacturaItem>> result = FacturaItem.TryFromId(conn, productId, ReceiptKind.Compra);
                if (!result.IsSuccessful)
                    errors.Add(result.Error);
                else if (result.Value.HasValue)
                    productos.Add(result.Value.Value);
            }
            reader.Close();
            if (errors.Count > 0)
            {
                var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of FacturaItems", errors);
                return new Result<Optional<DetalleCompra>>(aggregatedErrors);
            }
            return Optional.Some(new DetalleCompra
            {
                compraId = compraId,
                fecha = fecha,
                listaProductos = productos
            });
        }

        public double Total()
        {
            double accumulator = 0.0;
            foreach (FacturaItem product in this.listaProductos)
                accumulator += product.cantidad * product.precioUnitario;
            return accumulator;
        }
    }
}