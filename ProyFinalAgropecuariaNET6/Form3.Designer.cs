namespace proyFinalAgropecuaria
{
    partial class frmClientes
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.ComboBox cmbTipoCliente;
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
            dgvClientes = new DataGridView();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            cmbTipoCliente = new ComboBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeight = 29;
            dgvClientes.Location = new Point(12, 12);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(550, 300);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // txtId
            // 
            txtId.Location = new Point(580, 12);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 27);
            txtId.TabIndex = 1;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(580, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(580, 70);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(220, 27);
            txtDireccion.TabIndex = 3;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(580, 98);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(220, 27);
            txtTelefono.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(580, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 5;
            // 
            // cmbTipoCliente
            // 
            cmbTipoCliente.Items.AddRange(new object[] { "Minorista", "Mayorista" });
            cmbTipoCliente.Location = new Point(580, 154);
            cmbTipoCliente.Name = "cmbTipoCliente";
            cmbTipoCliente.Size = new Size(150, 28);
            cmbTipoCliente.TabIndex = 6;
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
            // frmClientes
            // 
            ClientSize = new Size(840, 330);
            Controls.Add(dgvClientes);
            Controls.Add(txtId);
            Controls.Add(txtNombre);
            Controls.Add(txtDireccion);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(cmbTipoCliente);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Name = "frmClientes";
            Text = "Clientes";
            Load += frmCliente_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }
    }
}
