using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DotNext;
using Microsoft.Data.Sqlite;

namespace proyFinalAgropecuaria
{
    public partial class frmInventario : Form
    {
        BDAgro db = new BDAgro();
        FormState state = new();

        public frmInventario()
        {
            InitializeComponent();
            CargarListaInventario();
        }

        /// <summary>
        /// Sincroniza la tabla con la información del inventario
        /// </summary>
        public void CargarListaInventario()
        {
            string sql = "SELECT * FROM Inventario";

            DataTable dt = this.db.EjecutarConsulta(sql);
            dgvInventario.DataSource = dt;
        }

        /// <summary>
        /// Validates the current state of the form, filling with the relevant defaults
        /// </summary>
        private void PopulateState()
        {
            if (this.state.productId is null)
            {
                this.state.alreadyExists = false;
                return;
            }
            else
                this.state.alreadyExists = this.ProductIdExists(this.state.productId.Value);
            this.state.Populate();
        }

        /// <summary>
        /// Checks if the given productId exists in the table of products
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        private bool ProductIdExists(int productId)
        {
            string find_sql = "SELECT COUNT(*) FROM Productos WHERE Id=$id";
            SqliteConnection conn = this.db.new_connection();

            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = find_sql;
            cmd.Parameters.AddWithValue("$id", productId);
            long count = (long)cmd.ExecuteScalar()!;
            if (count > 0)
                return true;
            else
                return false;
        }

        private bool ProductIdHasInventory(int productId)
        {

            string find_sql = "SELECT COUNT(*) FROM Inventario WHERE ProductoId=$id";
            SqliteConnection conn = this.db.new_connection();

            conn.Open();
            SqliteCommand cmd = conn.CreateCommand();
            cmd.CommandText = find_sql;
            cmd.Parameters.AddWithValue("$id", productId);
            long count = (long)cmd.ExecuteScalar()!;
            if (count > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Actualiza la lista de inventario, o actualiza el inventario de un producto
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (this.state.productId is null)
            {
                MessageBox.Show("No se definió ID de producto a actualizar");
            }
            else if (this.ProductIdHasInventory(state.productId!.Value))
            {
                // Update Product Inventory

                var result = this.SyncEntries();
                if (!result.IsSuccessful)
                {
                    var exception = result.Error;
                    MessageBox.Show($"Error Registrando: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.actualizarInventario(this.state);
            }
            else
            {
                // Register Product Inventory
                this.registrarProducto(this.state);

            }
            CargarListaInventario();

        }

        /// <summary>
        /// Registra el cambio al producto
        /// </summary>
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            var result = this.SyncEntries();
            if (!result.IsSuccessful)
            {
                var exception = result.Error;
                MessageBox.Show($"Error Registrando: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.registrarProducto(this.state);
            this.txtProductoId.Clear();
            this.state.productId = null;
            this.txtCantidad.Clear();
            this.txtStockMinimo.Clear();
            this.CargarListaInventario();
        }

        /// <summary>
        /// Registra el inventario de un producto.
        /// </summary>
        private void registrarProducto(FormState state)
        {
            // Todo: return specific error
            if (state.productId is null) return;
            if (!state.alreadyExists)
            {
                MessageBox.Show($"Error: Producto de id `{state.productId}` no existe");
                return;
            }
            if (this.ProductIdHasInventory(state.productId!.Value))
            {
                MessageBox.Show($"Error: El producto `{state.productId}` ya está registrado");
                return;
            }
            state.Populate();

            string sql = "INSERT INTO Inventario (ProductoId, StockActual, StockMinimo) VALUES ($id, $stockActual, $stockMinimo)";
            this.db.EjecutarComando(sql,
                ("$id", state.productId!),
                ("$stockActual", state.cantidad!),
                ("$stockMinimo", state.stockMinimo!)
            );
        }

        /// <summary>
        ///  Registra una salida del producto del inventario
        /// </summary>
        private void actualizarInventario(FormState state)
        {
            var result = state.CheckArgs();
            if (!result.IsSuccessful)
            {
                MessageBox.Show("Campos incompleto al actualizars", result.Error.Message);
                return;
            }
            ;

            var (productId, cantidad, stockMinimo, alreadyExists) = state;

            // Early return if there's no inventory record
            // Maybe register it anyways?
            if (!this.ProductIdHasInventory(state.productId!.Value)) return;

            string sql = "UPDATE Inventario SET StockActual=$cantidad, StockMinimo=$stockMinimo WHERE ProductoId=$id";

            this.db.EjecutarComando(sql,
                ("$id", state.productId!),
                ("$cantidad", state.cantidad!),
                ("$stockMinimo", state.stockMinimo!)
            );
        }

        Result<Void> SyncEntries()
        {
            try
            {
                var state = this.state;
                if (!int.TryParse(txtProductoId.Text, out int id))
                {
                    state.productId = null;
                    state.alreadyExists = false;
                }
                else
                {
                    state.productId = id;
                    state.alreadyExists = this.ProductIdExists(state.productId!.Value);
                }

                state.cantidad = int.Parse(txtCantidad.Text);
                state.stockMinimo = int.Parse(txtStockMinimo.Text);
                this.state = state;
            }
            catch (Exception e)
            {
                return Result.FromException<Void>(e);
            }
            return new Void();
        }

        private void txtProductoId_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(this.txtProductoId.Text, out int id))
            {
                this.state.productId = null;
                return;
            }
            this.state.productId = id;
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtStockMinimo_TextChanged(object sender, EventArgs e)
        {
        }
        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0)
            {
                this.txtProductoId.Text = dgvInventario.Rows[rowIndex].Cells["ProductoId"].Value.ToString();
                this.txtCantidad.Text = dgvInventario.Rows[rowIndex].Cells["StockActual"].Value.ToString();
                this.txtStockMinimo.Text = dgvInventario.Rows[rowIndex].Cells["StockMinimo"].Value.ToString();
                this.txtProductoId_TextChanged(sender, e);
            }
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CargarListaInventario();
        }
    }

    public enum existState
    {
        Inexistent,
        AlreadyExists
    }
    /// <summary>
    /// Unit Type
    /// </summary>
    class Void
    {
        public Void() { }
    }
    struct FormState
    {
        public int? productId = null;
        public int? cantidad = null;
        public int? stockMinimo = null;
        /// <summary>
        /// Describes if the given productId exists
        /// </summary>
        public bool alreadyExists = false;
        public FormState()
        {

        }

        /// <summary>
        /// Populate the relevant fields with a default value
        /// </summary>
        /// <returns></returns>
        public Result<Void> Populate()
        {
            var (productId, cantidad, stockMinimo, _) = this;
            if (productId is null)
                return Result.FromException<Void>(new MissingFieldException("Product id isn't provided"));
            this.cantidad ??= 0;
            this.stockMinimo ??= 0;
            return new Void();
        }

        /// <summary>
        /// Check if the arguments are all set
        /// </summary>
        /// <returns></returns>
        public Result<Void> CheckArgs()
        {
            var (productId, cantidad, stockMinimo, alreadyExists) = this;
            if (productId == null)
                return Result.FromException<Void>(new MissingFieldException("Product id isn't provided"));
            if (cantidad == null)
                return Result.FromException<Void>(new MissingFieldException("cantidad isn't provided"));
            if (productId == null)
                return Result.FromException<Void>(new MissingFieldException("Minimum stock isn't provided"));
            if (productId == null)
                return Result.FromException<Void>(new MissingFieldException("`alreadyExists` field isn't provided"));
            return new Void();
        }

        public void Deconstruct(out int? productId, out int? cantidad, out int? stockMinimo, out bool? alreadyExists)
        {
            productId = this.productId;
            cantidad = this.cantidad;
            stockMinimo = this.stockMinimo;
            alreadyExists = this.alreadyExists;
        }

    }
}
