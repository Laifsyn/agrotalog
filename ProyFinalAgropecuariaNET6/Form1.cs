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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            // Conectar los eventos de los botones
            btnProductos.Click += BtnProductos_Click;
            btnClientes.Click += BtnClientes_Click;
            btnProveedores.Click += BtnProveedores_Click;
            btnVentas.Click += BtnVentas_Click;
            btnInventario.Click += BtnInventario_Click;
        }

        // Método genérico para mostrar un Form dentro del panel
        private void AbrirFormEnPanel(Form form)
        {
            // Limpiar el panel antes de abrir otro Form
            panelContenedor.Controls.Clear();
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(form);
            panelContenedor.Tag = form;
            form.Show();
        }

        // Eventos de los botones
        private void BtnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProductos());

        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmClientes());
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmProveedores());
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmVentas());
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new frmInventario());
        }
    }
}
