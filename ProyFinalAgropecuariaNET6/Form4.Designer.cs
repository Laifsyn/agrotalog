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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            dgvProveedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProveedores.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 12F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProveedores.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProveedores.Location = new Point(12, 12);
            dgvProveedores.MultiSelect = false;
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.RowTemplate.Height = 35;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(829, 573);
            dgvProveedores.TabIndex = 0;
            dgvProveedores.CellClick += dgvProveedores_CellClick;
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 12F);
            txtId.Location = new Point(866, 4);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(100, 34);
            txtId.TabIndex = 1;
            txtId.Visible = false;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 12F);
            txtNombre.Location = new Point(866, 53);
            txtNombre.Multiline = true;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(297, 45);
            txtNombre.TabIndex = 2;
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(865, 148);
            txtTelefono.Multiline = true;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(297, 45);
            txtTelefono.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(865, 250);
            txtEmail.Multiline = true;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(297, 45);
            txtEmail.TabIndex = 5;
            // 
            // txtDireccion
            // 
            txtDireccion.Font = new Font("Segoe UI", 12F);
            txtDireccion.Location = new Point(866, 351);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(297, 45);
            txtDireccion.TabIndex = 6;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.FromArgb(192, 255, 192);
            btnNuevo.Font = new Font("Segoe UI", 12F);
            btnNuevo.Location = new Point(865, 512);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(135, 42);
            btnNuevo.TabIndex = 7;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(255, 255, 192);
            btnGuardar.Font = new Font("Segoe UI", 12F);
            btnGuardar.Location = new Point(865, 439);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(297, 45);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(255, 192, 192);
            btnEliminar.Font = new Font("Segoe UI", 12F);
            btnEliminar.Location = new Point(1027, 512);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(135, 42);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(866, 22);
            label1.Name = "label1";
            label1.Size = new Size(85, 28);
            label1.TabIndex = 12;
            label1.Text = "Nombre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(865, 117);
            label2.Name = "label2";
            label2.Size = new Size(86, 28);
            label2.TabIndex = 13;
            label2.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(865, 219);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 14;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(866, 320);
            label4.Name = "label4";
            label4.Size = new Size(94, 28);
            label4.TabIndex = 15;
            label4.Text = "Direccion";
            // 
            // frmProveedores
            // 
            ClientSize = new Size(1232, 734);
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
