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
            if(cmbClientes.Text == "Venta") {
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
    }
}
