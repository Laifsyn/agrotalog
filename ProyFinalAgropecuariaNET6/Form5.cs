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
        private BDAgro db = BDAgro.FromStatic();
        private int? selectedItemId;
        /// <summary>
        /// Binds the list type for Compras and Ventas
        /// </summary>
        private ReceiptKind selectedReceiptKind = ReceiptKind.Compra;
        public frmVentas()
        {
            InitializeComponent();
            this.cmbReceiptKind.SelectedIndex = 0; // Set Default to first item
            this.cmbReceiptKind_SelectedIndexChanged(this, EventArgs.Empty);
            this.dgvVentas.AutoGenerateColumns = false;
            this.LoadDgvVentasColumns();


            // For dgvItems
            this.dgvItems.AutoGenerateColumns = false;

            this.dgvItems.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colId",
                HeaderText = "Item Id",
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



            Result<List<ClientHistory>> clientsResult = ClientHistory.Load(this.db.new_connection());

            if (!clientsResult.IsSuccessful)
            {
                MessageBox.Show($"Error loading clients: {clientsResult.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.clients = new();
            }
            else
                this.clients = new(clientsResult.Value);

            Result<List<ProviderHistory>> providersResult = ProviderHistory.LoadFromConn(this.db.new_connection());
            if (!providersResult.IsSuccessful)
            {
                MessageBox.Show($"Error loading providers: {providersResult.Error.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.providers = new();
                return;
            }
            else
                this.providers = new(providersResult.Value);


            this.listClientes.DataSource = this.clients;
            this.listClientes.DisplayMember = "nombre";
            this.listClientes.ValueMember = "clientId";
        }

        void LoadDgvVentasColumns()
        {
            this.dgvVentas.Columns.Clear();

            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Venta:
                    this.dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "colVentaId",
                        HeaderText = "ID Venta",
                        DataPropertyName = "ventaId"
                    });
                    break;
                case ReceiptKind.Compra:
                    this.dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
                    {
                        Name = "colCompraId",
                        HeaderText = "ID Compra",
                        DataPropertyName = "compraId"
                    });
                    break;
            }

            this.dgvVentas.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFecha",
                HeaderText = "Fecha",
                DataPropertyName = "fecha"
            });

            this.dgvVentas.Refresh();
        }

        private void listClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listClientes.SelectedItem is null) return;
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    ProviderHistory selectedProvider = (ProviderHistory)this.listClientes.SelectedItem;
                    this.dgvVentas.DataSource = selectedProvider.facturas;
                    break;
                case ReceiptKind.Venta:
                    ClientHistory selectedClient = (ClientHistory)this.listClientes.SelectedItem;
                    this.dgvVentas.DataSource = selectedClient.facturas;
                    break;
            }
            this.dgvVentas.Refresh();

        }

        private void dgvVentas_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvVentas.SelectedRows.Count > 0)
            {

                DataGridViewRow selectedRow = this.dgvVentas.SelectedRows[0];
                if (selectedRow.DataBoundItem is null) return;
                
                switch (this.selectedReceiptKind)
                {
                    case ReceiptKind.Compra:
                        DetalleCompra selectedCompra = (DetalleCompra)selectedRow.DataBoundItem;
                        this.dgvItems.DataSource = selectedCompra.listaProductos;
                        break;
                    case ReceiptKind.Venta:
                        DetalleVenta selectedVenta = (DetalleVenta)selectedRow.DataBoundItem;
                        this.dgvItems.DataSource = selectedVenta.listaProductos;
                        break;
                }
                this.UpdateTotalLabel();
                this.dgvItems.Refresh();
                this.dgvItems_CellClick(this.dgvItems, new DataGridViewCellEventArgs(0, 0));
            }
        }

        void UpdateTotalLabel()
        {
            if (this.dgvVentas.SelectedRows.Count == 0) return;
            DataGridViewRow selectedRow = this.dgvVentas.SelectedRows[0];
            if (selectedRow.DataBoundItem is null) return;

            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    DetalleCompra selectedCompra = (DetalleCompra)selectedRow.DataBoundItem;
                    this.lblTotal.Text = $"Total: ${selectedCompra.TotalFactura().ToString("#,##0.00")}";
                    break;
                case ReceiptKind.Venta:
                    DetalleVenta selectedVenta = (DetalleVenta)selectedRow.DataBoundItem;
                    this.lblTotal.Text = $"Total: ${selectedVenta.TotalFactura().ToString("#,##0.00")}";
                    break;
            }
        }

        private void cmbReceiptKind_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (this.cmbReceiptKind.SelectedItem is null) return;
            // Mostrar Historial de Ventas
            else if (this.cmbReceiptKind.SelectedItem.ToString() == "Venta")
            {
                this.selectedReceiptKind = ReceiptKind.Venta;
                this.listClientes.DataSource = this.clients;
                this.listClientes.DisplayMember = "nombre";
                this.listClientes.ValueMember = "clientId";
                this.lblSaleList.Text = "Historial de Ventas";
                this.lblItemDetails.Text = "Detalles de la Venta";
            }
            // Mostrar Historial de Compras
            else if (this.cmbReceiptKind.SelectedItem.ToString() == "Compra")
            {
                this.selectedReceiptKind = ReceiptKind.Compra;
                // Actualizar la lista de clientes a Lista de proveedores
                this.listClientes.DataSource = this.providers;
                this.listClientes.DisplayMember = "nombre";
                this.listClientes.ValueMember = "providerId";
                this.lblSaleList.Text = "Historial de Compras";
                this.lblItemDetails.Text = "Detalles de la Compra";
            }
            else
            {
                MessageBox.Show(Text = "Tipo de recibo no válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDgvVentasColumns();
            this.listClientes.Refresh();
        }

        private void btDetailsAdd_Click(object sender, EventArgs e)
        {
            int cantidad = int.Parse(this.txtDetailCantidad.Text);
            int productId = int.Parse(this.txtDetailProductId.Text);
            SqliteConnection conn = this.db.new_connection();
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Nombre, Descripcion, Precio FROM Productos where Id=$prodId";
            command.Parameters.AddWithValue("$prodId", productId);
            SqliteDataReader reader = command.ExecuteReader();
            reader.Read();

            string productName = reader.GetString("Nombre");
            double precioUnitario = reader.GetDouble("Precio");
            reader.Close();
            command.Parameters.Clear();

            // Register item to the database
            {
                switch (this.selectedReceiptKind)
                {
                    case ReceiptKind.Compra:
                        var currentPurchase = (DetalleCompra)this.dgvVentas.SelectedRows[0].DataBoundItem;
                        command.CommandText = "INSERT INTO DetalleCompras (ProductoId, CompraId, Cantidad, PrecioUnitario, Subtotal) VALUES ($prodId, $cantidad, $precioUnitario) RETURNING *";
                        command.Parameters.AddWithValue("$prodId", productId);
                        command.Parameters.AddWithValue("$compraId", currentPurchase.compraId);
                        command.Parameters.AddWithValue("$cantidad", cantidad);
                        command.Parameters.AddWithValue("$precioUnitario", precioUnitario);
                        command.Parameters.AddWithValue("$subTotal", cantidad * precioUnitario);
                        reader = command.ExecuteReader();
                        break;
                    case ReceiptKind.Venta:
                        var currentSale = (DetalleVenta)this.dgvVentas.SelectedRows[0].DataBoundItem;
                        command.CommandText = "INSERT INTO DetalleVentas (ProductoId, VentaId, Cantidad, PrecioUnitario, Subtotal) VALUES ($prodId, $ventaId, $cantidad, $precioUnitario, $subTotal) RETURNING *";
                        command.Parameters.AddWithValue("$prodId", productId);
                        command.Parameters.AddWithValue("$ventaId", currentSale.ventaId);
                        command.Parameters.AddWithValue("$cantidad", cantidad);
                        command.Parameters.AddWithValue("$precioUnitario", precioUnitario);
                        command.Parameters.AddWithValue("$subTotal", cantidad * precioUnitario);
                        reader = command.ExecuteReader();
                        break;
                }
            }
            // get the item's id
            reader.Read();
            int itemId = reader.GetInt32("Id");
            this.selectedItemId = itemId;
            reader.Close();
            FacturaItem newItem = new FacturaItem
            {
                id = itemId,
                productId = productId,
                productName = productName,
                cantidad = cantidad,
                precioUnitario = precioUnitario,
                type = this.selectedReceiptKind
            };

            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Venta:
                    var currentVenta = (DetalleVenta)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    currentVenta.listaProductos.Add(newItem);
                    break;
                case ReceiptKind.Compra:
                    var currentCompra = (DetalleCompra)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    currentCompra.listaProductos.Add(newItem);
                    break;
            }

            this.UpdateTotalLabel();
        }


        private void txtDetailProductId_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtDetailProductId.Text, out int productId))
            {
                SqliteConnection conn = this.db.new_connection();
                conn.Open();
                SqliteCommand command = conn.CreateCommand();
                command.CommandText = "SELECT count(*) FROM Productos where Id=$prodId";
                command.Parameters.AddWithValue("$prodId", productId);
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show($"El producto con Id `{productId}` no existe en la base de datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDetailProductId.Focus();
                }

            }
        }

        private void txtDetailCantidad_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(this.txtDetailCantidad.Text, out int cantidad))
            {
                if (cantidad <= 0)
                {
                    MessageBox.Show("La cantidad debe ser un número positivo mayor que cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDetailCantidad.Focus();
                }
            }
            else
            {
                MessageBox.Show("La cantidad debe ser un número entero válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDetailCantidad.Focus();
            }
        }

        private void btnDetailsUpdate_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId is null)
            {
                MessageBox.Show("No hay ningún ítem seleccionado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int cantidad = int.Parse(this.txtDetailCantidad.Text);
            int productId = int.Parse(this.txtDetailProductId.Text);
            double precioUnitario = double.Parse(this.txtDetailPrecio.Text);
            SqliteConnection conn = this.db.new_connection();
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    command.CommandText = "UPDATE DetalleCompras SET Cantidad=$cantidad WHERE Id=$itemId";
                    break;
                case ReceiptKind.Venta:
                    command.CommandText = "UPDATE DetalleVentas SET Cantidad=$cantidad WHERE Id=$itemId";
                    break;
            }
            int itemId = this.selectedItemId.Value;
            command.Parameters.AddWithValue("$cantidad", cantidad);
            command.Parameters.AddWithValue("$itemId", itemId);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                MessageBox.Show("No se pudo actualizar el ítem en la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FacturaItem itemToUpdate;
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    var currentCompra = (DetalleCompra)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    itemToUpdate = currentCompra.listaProductos.First(item => item.id == itemId);
                    itemToUpdate.cantidad = cantidad;

                    if (itemToUpdate.precioUnitario != precioUnitario)
                        MessageBox.Show("El precio unitario solo se puede modificar con la versión paga.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case ReceiptKind.Venta:
                    var currentVenta = (DetalleVenta)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    itemToUpdate = currentVenta.listaProductos.First(item => item.id == itemId);
                    itemToUpdate.cantidad = cantidad;

                    if (itemToUpdate.precioUnitario != precioUnitario)
                        MessageBox.Show("El precio unitario solo se puede modificar con la versión paga.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            this.dgvItems.Refresh();
            this.UpdateTotalLabel();


        }

        private void btDetailsDelete_Click(object sender, EventArgs e)
        {
            if (this.selectedItemId is null)
            {
                MessageBox.Show("No hay ningún ítem seleccionado para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SqliteConnection conn = this.db.new_connection();
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    command.CommandText = "DELETE FROM DetalleCompras WHERE Id=$itemId";
                    break;
                case ReceiptKind.Venta:
                    command.CommandText = "DELETE FROM DetalleVentas WHERE Id=$itemId";
                    break;
            }
            int itemId = this.selectedItemId.Value;
            command.Parameters.AddWithValue("$itemId", itemId);
            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                MessageBox.Show($"No se pudo eliminar el ítem {itemId} de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Remove from databind
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    var currentCompra = (DetalleCompra)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    var itemToRemove = currentCompra.listaProductos.First(item => item.id == itemId);
                    if (itemToRemove != null)
                        currentCompra.listaProductos.Remove(itemToRemove);
                    break;
                case ReceiptKind.Venta:
                    var currentVenta = (DetalleVenta)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    var itemToRemoveVenta = currentVenta.listaProductos.First(item => item.id == itemId);
                    if (itemToRemoveVenta != null)
                        currentVenta.listaProductos.Remove(itemToRemoveVenta);
                    break;
            }
            this.UpdateTotalLabel();

        }

        private void btnAgregarVentaCompra_Click(object sender, EventArgs e)
        {
            if (this.listClientes.SelectedItem is null) return;
            // Get the current databindList for Compra/Venta
            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    var selectedProvider = (ProviderHistory)this.listClientes.SelectedItem;
                    var newCompra = new DetalleCompra
                    {
                        compraId = 0, // Placeholder, will be set by DB
                        fecha = DateTime.Now,
                        listaProductos = new BindingList<FacturaItem>()
                    };
                    // Insert into DB
                    {
                        SqliteConnection conn = this.db.new_connection();
                        conn.Open();
                        SqliteCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO Compras (ProveedorId, Fecha, Total) VALUES ($providerId, $fecha, $total) RETURNING *";
                        command.Parameters.AddWithValue("$providerId", selectedProvider.providerId);
                        command.Parameters.AddWithValue("$fecha", newCompra.fecha);
                        command.Parameters.AddWithValue("$total", 0.0); // Initial total is 0.0
                        SqliteDataReader reader = command.ExecuteReader();
                        reader.Read();
                        newCompra.compraId = reader.GetInt32("Id");
                        reader.Close();
                    }
                    selectedProvider.facturas.Add(newCompra);
                    break;
                case ReceiptKind.Venta:
                    var selectedClient = (ClientHistory)this.listClientes.SelectedItem;
                    var newVenta = new DetalleVenta
                    {
                        ventaId = 0, // Placeholder, will be set by DB
                        fecha = DateTime.Now,
                        listaProductos = new BindingList<FacturaItem>()
                    };
                    // Insert into DB
                    {
                        SqliteConnection conn = this.db.new_connection();
                        conn.Open();
                        SqliteCommand command = conn.CreateCommand();
                        command.CommandText = "INSERT INTO Ventas (ClienteId, Fecha, Total) VALUES ($clientId, $fecha, $total) RETURNING *";
                        command.Parameters.AddWithValue("$clientId", selectedClient.clientId);
                        command.Parameters.AddWithValue("$fecha", newVenta.fecha);
                        command.Parameters.AddWithValue("$total", 0.0); // Initial total is 0.0
                        SqliteDataReader reader = command.ExecuteReader();
                        reader.Read();
                        newVenta.ventaId = reader.GetInt32("Id");
                        reader.Close();
                    }
                    selectedClient.facturas.Add(newVenta);
                    break;
            }
            this.dgvVentas.Refresh();
            this.UpdateTotalLabel();
        }

        private void btnQuitarCompraVenta_Click(object sender, EventArgs e)
        {
            if (this.listClientes.SelectedItem is null) return;
            // do work on the currently selected Client/Provider Databind List

            switch (this.selectedReceiptKind)
            {
                case ReceiptKind.Compra:
                    var selectedProvider = (ProviderHistory)this.listClientes.SelectedItem;
                    if (this.dgvVentas.SelectedRows.Count == 0) return;
                    var selectedCompra = (DetalleCompra)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    // Avoid orphaning Item Details records
                    if (selectedCompra.listaProductos.Count != 0)
                    {
                        MessageBox.Show("No se puede eliminar una venta que aún tiene productos asociados. Por favor, elimine primero los productos de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Delete from DB
                    {
                        SqliteConnection conn = this.db.new_connection();
                        conn.Open();
                        SqliteCommand command = conn.CreateCommand();
                        command.CommandText = "DELETE FROM Compras WHERE Id=$compraId";
                        command.Parameters.AddWithValue("$compraId", selectedCompra.compraId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No se pudo eliminar la compra de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    selectedProvider.facturas.Remove(selectedCompra);
                    break;
                case ReceiptKind.Venta:
                    var selectedClient = (ClientHistory)this.listClientes.SelectedItem;
                    if (this.dgvVentas.SelectedRows.Count == 0) return;
                    var selectedVenta = (DetalleVenta)this.dgvVentas.SelectedRows[0].DataBoundItem;
                    // Avoid orphaning Item Details records
                    if (selectedVenta.listaProductos.Count != 0)
                    {
                        MessageBox.Show("No se puede eliminar una venta que aún tiene productos asociados. Por favor, elimine primero los productos de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Delete from DB
                    {
                        SqliteConnection conn = this.db.new_connection();
                        conn.Open();
                        SqliteCommand command = conn.CreateCommand();
                        command.CommandText = "DELETE FROM Ventas WHERE Id=$ventaId";
                        command.Parameters.AddWithValue("$ventaId", selectedVenta.ventaId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("No se pudo eliminar la venta de la base de datos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    selectedClient.facturas.Remove(selectedVenta);
                    break;
            }
            this.dgvVentas.Refresh();
        }

        protected void dgvItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = this.dgvItems.Rows[e.RowIndex];
                if (selectedRow.DataBoundItem is null) return;
                FacturaItem selectedItem = (FacturaItem)selectedRow.DataBoundItem;
                this.selectedItemId = selectedItem.id;
                this.txtDetailCantidad.Text = selectedItem.cantidad.ToString();
                this.txtDetailProductId.Text = selectedItem.productId.ToString();
                this.txtDetailPrecio.Text = selectedItem.precioUnitario.ToString();
            }
        }

        private void txtDetailPrecio_Leave(object sender, EventArgs e)
        {
            if (double.TryParse(this.txtDetailPrecio.Text, out double precio))
            {
                if (precio <= 0.0)
                {
                    MessageBox.Show("El precio debe ser un número positivo mayor que cero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtDetailPrecio.Focus();
                }
            }
            else
            {
                MessageBox.Show("El precio debe ser un número válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtDetailPrecio.Focus();
            }
        }
    }
}

namespace CompraVenta
{
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
        public required BindingList<DetalleVenta> facturas { get; set; } = new();

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
            return ((double)decimal.Round((decimal)accumulator, 2, MidpointRounding.ToEven));
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
        public required BindingList<DetalleCompra> facturas { get; set; } = new();

        public static Result<List<ProviderHistory>> LoadFromConn(SqliteConnection conn)
        {
            conn.Open();
            SqliteCommand command = conn.CreateCommand();
            command.CommandText = "SELECT Id from Proveedores";
            SqliteDataReader reader = command.ExecuteReader();
            List<ProviderHistory> providers = new();
            var errors = new List<Exception>();
            while (reader.Read())
            {
                int providerId = reader.GetInt32("Id");
                Result<Optional<ProviderHistory>> result = ProviderHistory.TryFromId(conn, providerId);
                if (!result.IsSuccessful)
                    errors.Add(result.Error);
                else if (result.Value.HasValue)
                    providers.Add(result.Value.Value);
            }
            if (errors.Count > 0)
            {
                var aggregatedErrors = new AggregateException("Encountered errors while coalescing a list of Providers", errors);
                return new Result<List<ProviderHistory>>(aggregatedErrors);
            }
            return providers;
        }

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

            var providerHistory = new ProviderHistory { facturas = facturas, id = id, providerId = providerId, nombre = nombre };
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

        public double TotalFactura()
        {
            double accumulator = 0.0;
            foreach (FacturaItem product in this.listaProductos)
                accumulator += product.cantidad * product.precioUnitario;
            return ((double)decimal.Round((decimal)accumulator, 2, MidpointRounding.ToEven));
        }
    }
}