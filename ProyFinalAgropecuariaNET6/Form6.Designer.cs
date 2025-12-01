namespace proyFinalAgropecuaria
{
    partial class frmInventario
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ComboBox cmbTipoMovimiento;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnActualizar;

        protected override void Dispose(bool disposing)
        {
            if (disposing != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.cmbTipoMovimiento = new System.Windows.Forms.ComboBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.SuspendLayout();
            // dgvInventario
            this.dgvInventario.Location = new System.Drawing.Point(12, 12);
            this.dgvInventario.Size = new System.Drawing.Size(500, 300);
            this.dgvInventario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInventario.MultiSelect = false;
            // txtProducto
            this.txtProducto.Location = new System.Drawing.Point(580, 40);
            this.txtProducto.Size = new System.Drawing.Size(200, 22);
            // txtCantidad
            this.txtCantidad.Location = new System.Drawing.Point(580, 70);
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            // cmbTipoMovimiento
            this.cmbTipoMovimiento.Location = new System.Drawing.Point(580, 100);
            this.cmbTipoMovimiento.Size = new System.Drawing.Size(120, 24);
            this.cmbTipoMovimiento.Items.AddRange(new object[] { "Entrada", "Salida" });
            // lblProducto
            this.lblProducto.Location = new System.Drawing.Point(520, 40);
            this.lblProducto.Size = new System.Drawing.Size(60, 20);
            this.lblProducto.Text = "Producto:";
            // lblCantidad
            this.lblCantidad.Location = new System.Drawing.Point(520, 70);
            this.lblCantidad.Size = new System.Drawing.Size(60, 20);
            this.lblCantidad.Text = "Cantidad:";
            // lblTipo
            this.lblTipo.Location = new System.Drawing.Point(520, 100);
            this.lblTipo.Size = new System.Drawing.Size(60, 20);
            this.lblTipo.Text = "Tipo:";
            // btnRegistrar
            this.btnRegistrar.Location = new System.Drawing.Point(580, 140);
            this.btnRegistrar.Size = new System.Drawing.Size(75, 30);
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // btnActualizar
            this.btnActualizar.Location = new System.Drawing.Point(665, 140);
            this.btnActualizar.Size = new System.Drawing.Size(75, 30);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // frmInventario
            this.ClientSize = new System.Drawing.Size(800, 330);
            this.Controls.Add(this.dgvInventario);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbTipoMovimiento);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnActualizar);
            this.Name = "frmInventario";
            this.Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
