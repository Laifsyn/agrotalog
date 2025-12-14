namespace proyFinalAgropecuaria
{
    partial class frmVentas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.DataGridView dgvVenta;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnFinalizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvProductos = new DataGridView();
            dgvVenta = new DataGridView();
            cmbClientes = new ComboBox();
            lblCliente = new Label();
            lblTotal = new Label();
            btnAgregar = new Button();
            btnQuitar = new Button();
            btnFinalizar = new Button();
            cmbModo = new ComboBox();
            lblCuentas = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(20, 65);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(400, 300);
            dgvProductos.TabIndex = 0;
            // 
            // dgvVenta
            // 
            dgvVenta.ColumnHeadersHeight = 29;
            dgvVenta.Location = new Point(438, 65);
            dgvVenta.MultiSelect = false;
            dgvVenta.Name = "dgvVenta";
            dgvVenta.RowHeadersWidth = 51;
            dgvVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenta.Size = new Size(400, 300);
            dgvVenta.TabIndex = 1;
            // 
            // cmbClientes
            // 
            cmbClientes.Items.AddRange(new object[] { "ListaDeClientes" });
            cmbClientes.Location = new Point(12, 6);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(124, 23);
            cmbClientes.TabIndex = 2;
            cmbClientes.SelectedIndexChanged += cmbClientes_SelectedIndexChanged;
            // 
            // lblCliente
            // 
            lblCliente.Location = new Point(142, 9);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(70, 20);
            lblCliente.TabIndex = 3;
            // 
            // lblTotal
            // 
            lblTotal.Location = new Point(438, 375);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(150, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(44, 370);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 30);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnNuevo_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(141, 370);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 30);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "Eliminar";
            btnQuitar.Click += btnEliminar_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(234, 370);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(100, 30);
            btnFinalizar.TabIndex = 7;
            btnFinalizar.Text = "Guardar";
            btnFinalizar.Click += btnGuardar_Click;
            // 
            // cmbModo
            // 
            cmbModo.Items.AddRange(new object[] { "Facturacion", "Historial de Compra" });
            cmbModo.Location = new Point(161, 6);
            cmbModo.Name = "cmbModo";
            cmbModo.Size = new Size(124, 23);
            cmbModo.TabIndex = 8;
            // 
            // lblCuentas
            // 
            lblCuentas.Location = new Point(20, 42);
            lblCuentas.Name = "lblCuentas";
            lblCuentas.Size = new Size(150, 20);
            lblCuentas.TabIndex = 9;
            lblCuentas.Text = "Historial de Cuentas";
            lblCuentas.Click += label1_Click;
            // 
            // label2
            // 
            label2.Location = new Point(438, 42);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 10;
            label2.Text = "Productos";
            // 
            // frmVentas
            // 
            ClientSize = new Size(850, 400);
            Controls.Add(label2);
            Controls.Add(lblCuentas);
            Controls.Add(cmbModo);
            Controls.Add(dgvProductos);
            Controls.Add(dgvVenta);
            Controls.Add(cmbClientes);
            Controls.Add(lblCliente);
            Controls.Add(lblTotal);
            Controls.Add(btnAgregar);
            Controls.Add(btnQuitar);
            Controls.Add(btnFinalizar);
            Name = "frmVentas";
            Text = "Ventas / Compras";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).EndInit();
            ResumeLayout(false);
        }

        private ComboBox cmbModo;
        private Label lblCuentas;
        private Label label2;
    }
}
