using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static proyFinalAgropecuaria.BDAgro;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace proyFinalAgropecuaria
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
            txtId.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtUnidad.Clear();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica que implementará tu compañero
            // 1️⃣ Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text) ||
                string.IsNullOrWhiteSpace(txtUnidad.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            // 2️⃣ Validar que Precio y Stock sean números válidos
            if (!double.TryParse(txtPrecio.Text, out double precio))
            {
                MessageBox.Show("Ingrese un precio válido.");
                return;
            }

            if (!int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Ingrese un stock válido.");
                return;
            }

            try
            {
                // 3️⃣ Crear instancia de BDAgro y agregar el producto
                BDAgro bd = new BDAgro();

                if (!BDAgro.AddProduct.TryParse(txtNombre.Text, txtDescripcion.Text,
                                 precio, stock, txtUnidad.Text, out AddProduct parseResult))
                {
                    throw new Exception("Error al crear el producto. Verifique los datos ingresados.");
                }

                bd.AgregarProducto(parseResult);
                // bd.AgregarProducto(txtNombre.Text, txtDescripcion.Text, precio, stock, txtUnidad.Text);
                MessageBox.Show("Producto agregado correctamente.");

                // 4️⃣ Limpiar los campos
                txtNombre.Clear();
                txtDescripcion.Clear();
                txtPrecio.Clear();
                txtStock.Clear();
                txtUnidad.Clear();

                // 5️⃣ Actualizar el DataGridView si tienes uno
                dgvProductos.DataSource = bd.MostrarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el producto: " + ex.Message);
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int idProducto))
            {
                MessageBox.Show("Ingrese un ID válido.");
                return;
            }

            BDAgro bd = new BDAgro();

            bool eliminado = bd.EliminarProducto(idProducto);

            if (eliminado)
            {
                MessageBox.Show("Producto eliminado correctamente.");
            }
            else
            {
                MessageBox.Show("No se encontró el ID. Ingrese un ID válido.");
            }
        }
    }
}
