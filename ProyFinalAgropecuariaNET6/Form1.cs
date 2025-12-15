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

            this.WindowState = FormWindowState.Maximized;
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
            frmProductos frm = new frmProductos();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear(); // Limpia cualquier formulario anterior
            panelContenedor.Controls.Add(frm);
            frm.Show();

        }

        private void BtnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear(); // Limpia cualquier formulario anterior
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void BtnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear(); // Limpia cualquier formulario anterior
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            frmVentas frm = new frmVentas();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear(); // Limpia cualquier formulario anterior
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void BtnInventario_Click(object sender, EventArgs e)
        {
            frmInventario frm = new frmInventario();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            panelContenedor.Controls.Clear(); // Limpia cualquier formulario anterior
            panelContenedor.Controls.Add(frm);
            frm.Show();
        }

        private void panelBotones_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
