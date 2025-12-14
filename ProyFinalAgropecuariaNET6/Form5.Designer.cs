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
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVenta).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(12, 40);
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
            dgvVenta.Location = new Point(430, 40);
            dgvVenta.MultiSelect = false;
            dgvVenta.Name = "dgvVenta";
            dgvVenta.RowHeadersWidth = 51;
            dgvVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVenta.Size = new Size(400, 300);
            dgvVenta.TabIndex = 1;
            // 
            // cmbClientes
            // 
            cmbClientes.Items.AddRange(new object[] { "Ventas", "Compras" });
            cmbClientes.Location = new Point(12, 6);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(124, 28);
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
            lblTotal.Location = new Point(430, 350);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(150, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(122, 350);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 30);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnNuevo_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(219, 350);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(75, 30);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "Eliminar";
            btnQuitar.Click += btnEliminar_Click;
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(312, 350);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(100, 30);
            btnFinalizar.TabIndex = 7;
            btnFinalizar.Text = "Guardar";
            btnFinalizar.Click += btnGuardar_Click;
            // 
            // comboBox1
            // 
            comboBox1.Location = new Point(218, 6);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(124, 28);
            comboBox1.TabIndex = 8;
            // 
            // frmVentas
            // 
            ClientSize = new Size(850, 400);
            Controls.Add(comboBox1);
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

        private ComboBox comboBox1;
    }
}
