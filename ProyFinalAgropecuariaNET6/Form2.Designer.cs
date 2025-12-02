namespace proyFinalAgropecuaria
{
    partial class frmProductos
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtUnidad;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            txtUnidad = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(580, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(580, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(580, 70);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(220, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(580, 98);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 4;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(580, 126);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 5;
            // 
            // txtUnidad
            // 
            txtUnidad.Location = new Point(580, 154);
            txtUnidad.Name = "txtUnidad";
            txtUnidad.Size = new Size(100, 23);
            txtUnidad.TabIndex = 6;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(580, 190);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 30);
            btnNuevo.TabIndex = 7;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(665, 190);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(750, 190);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 30);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeight = 29;
            dgvProductos.Location = new Point(12, 12);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(550, 300);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // frmProductos
            // 
            ClientSize = new Size(840, 330);
            Controls.Add(dgvProductos);
            Controls.Add(txtId);
            Controls.Add(txtNombre);
            Controls.Add(txtDescripcion);
            Controls.Add(txtPrecio);
            Controls.Add(txtStock);
            Controls.Add(txtUnidad);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Name = "frmProductos";
            Text = "Productos";
            Load += frmProductos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.DataGridView dgvProductos;
    }
}
