namespace proyFinalAgropecuaria
{
    partial class frmInventario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.TextBox txtProductoId;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblProductoId;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvInventario = new DataGridView();
            txtProductoId = new TextBox();
            txtCantidad = new TextBox();
            lblProductoId = new Label();
            lblCantidad = new Label();
            lblTipo = new Label();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            txtStockMinimo = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            SuspendLayout();
            // 
            // dgvInventario
            // 
            dgvInventario.Location = new Point(12, 12);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(453, 300);
            dgvInventario.TabIndex = 0;
            dgvInventario.CellClick += dgvInventario_CellClick;
            dgvInventario.CellContentClick += dgvInventario_CellContentClick;
            // 
            // txtProductoId
            // 
            txtProductoId.Location = new Point(572, 36);
            txtProductoId.Name = "txtProductoId";
            txtProductoId.Size = new Size(200, 23);
            txtProductoId.TabIndex = 1;
            txtProductoId.TextChanged += txtProductoId_TextChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(572, 65);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(100, 23);
            txtCantidad.TabIndex = 2;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            // 
            // lblProductoId
            // 
            lblProductoId.Location = new Point(483, 37);
            lblProductoId.Name = "lblProductoId";
            lblProductoId.Size = new Size(60, 20);
            lblProductoId.TabIndex = 4;
            lblProductoId.Text = "Producto Id:";
            // 
            // lblCantidad
            // 
            lblCantidad.Location = new Point(483, 67);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(60, 20);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblTipo
            // 
            lblTipo.Location = new Point(483, 97);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(98, 20);
            lblTipo.TabIndex = 6;
            lblTipo.Text = "Stock Mínimo:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(549, 137);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 30);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(634, 137);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 30);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(572, 94);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(100, 23);
            txtStockMinimo.TabIndex = 9;
            txtStockMinimo.TextChanged += txtStockMinimo_TextChanged;
            // 
            // frmInventario
            // 
            ClientSize = new Size(800, 330);
            Controls.Add(txtStockMinimo);
            Controls.Add(dgvInventario);
            Controls.Add(txtProductoId);
            Controls.Add(txtCantidad);
            Controls.Add(lblProductoId);
            Controls.Add(lblCantidad);
            Controls.Add(lblTipo);
            Controls.Add(btnRegistrar);
            Controls.Add(btnActualizar);
            Name = "frmInventario";
            Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
        private TextBox txtStockMinimo;
    }
}
