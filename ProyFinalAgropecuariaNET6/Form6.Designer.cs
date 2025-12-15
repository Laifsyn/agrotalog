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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventario.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvInventario.DefaultCellStyle = dataGridViewCellStyle2;
            dgvInventario.Location = new Point(12, 12);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowHeadersWidth = 51;
            dgvInventario.RowTemplate.Height = 35;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(698, 519);
            dgvInventario.TabIndex = 0;
            dgvInventario.CellClick += dgvInventario_CellClick;
            dgvInventario.CellContentClick += dgvInventario_CellContentClick;
            // 
            // txtProductoId
            // 
            txtProductoId.Font = new Font("Segoe UI", 12F);
            txtProductoId.Location = new Point(735, 59);
            txtProductoId.Multiline = true;
            txtProductoId.Name = "txtProductoId";
            txtProductoId.Size = new Size(294, 45);
            txtProductoId.TabIndex = 1;
            txtProductoId.TextChanged += txtProductoId_TextChanged;
            // 
            // txtCantidad
            // 
            txtCantidad.Font = new Font("Segoe UI", 12F);
            txtCantidad.Location = new Point(735, 160);
            txtCantidad.Multiline = true;
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(294, 45);
            txtCantidad.TabIndex = 2;
            txtCantidad.TextChanged += txtCantidad_TextChanged;
            // 
            // lblProductoId
            // 
            lblProductoId.Font = new Font("Segoe UI", 12F);
            lblProductoId.Location = new Point(735, 24);
            lblProductoId.Name = "lblProductoId";
            lblProductoId.Size = new Size(200, 32);
            lblProductoId.TabIndex = 4;
            lblProductoId.Text = "Producto Id:";
            // 
            // lblCantidad
            // 
            lblCantidad.Font = new Font("Segoe UI", 12F);
            lblCantidad.Location = new Point(735, 125);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(184, 45);
            lblCantidad.TabIndex = 5;
            lblCantidad.Text = "Cantidad:";
            // 
            // lblTipo
            // 
            lblTipo.Font = new Font("Segoe UI", 12F);
            lblTipo.Location = new Point(735, 225);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(214, 31);
            lblTipo.TabIndex = 6;
            lblTipo.Text = "Stock Mínimo:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.BackColor = Color.FromArgb(192, 192, 255);
            btnRegistrar.Font = new Font("Segoe UI", 12F);
            btnRegistrar.Location = new Point(735, 362);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(294, 45);
            btnRegistrar.TabIndex = 7;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = false;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(255, 255, 192);
            btnActualizar.Font = new Font("Segoe UI", 12F);
            btnActualizar.Location = new Point(735, 423);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(294, 45);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Font = new Font("Segoe UI", 12F);
            txtStockMinimo.Location = new Point(735, 259);
            txtStockMinimo.Multiline = true;
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(294, 45);
            txtStockMinimo.TabIndex = 9;
            txtStockMinimo.TextChanged += txtStockMinimo_TextChanged;
            // 
            // frmInventario
            // 
            ClientSize = new Size(1215, 630);
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
