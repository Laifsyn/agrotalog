namespace proyFinalAgropecuaria
{
    partial class frmProveedores
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvProveedores;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtDireccion;
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
            dgvProveedores = new DataGridView();
            txtId = new TextBox();
            txtNombre = new TextBox();
            txtTelefono = new TextBox();
            txtEmail = new TextBox();
            txtDireccion = new TextBox();
            btnNuevo = new Button();
            btnGuardar = new Button();
            btnEliminar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeight = 29;
            dgvProveedores.Location = new Point(12, 12);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(550, 300);
            dgvProveedores.TabIndex = 0;
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
            txtNombre.Location = new Point(580, 61);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(220, 27);
            txtNombre.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(580, 112);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(220, 27);
            txtTelefono.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(580, 162);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 27);
            txtEmail.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(580, 214);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(220, 27);
            txtDireccion.TabIndex = 6;
            // 
            // btnNuevo
            // 
            btnNuevo.Location = new Point(580, 283);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 30);
            btnNuevo.TabIndex = 7;
            btnNuevo.Text = "Nuevo";
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(665, 283);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 30);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(750, 283);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 30);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Location = new Point(580, 39);
            label1.Name = "label1";
            label1.Size = new Size(64, 20);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Location = new Point(580, 92);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 13;
            label2.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Location = new Point(580, 142);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 14;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Location = new Point(580, 191);
            label4.Name = "label4";
            label4.Size = new Size(72, 20);
            label4.TabIndex = 15;
            label4.Text = "Direccion";
            // 
            // frmProveedores
            // 
            ClientSize = new Size(840, 330);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvProveedores);
            Controls.Add(txtId);
            Controls.Add(txtNombre);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmail);
            Controls.Add(txtDireccion);
            Controls.Add(btnNuevo);
            Controls.Add(btnGuardar);
            Controls.Add(btnEliminar);
            Name = "frmProveedores";
            Text = "Proveedores";
            Load += frmProveedor_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
