namespace proyFinalAgropecuaria
{
    partial class frmVentas
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvItems = new DataGridView();
            dgvVentas = new DataGridView();
            lblCliente = new Label();
            lblTotal = new Label();
            btnAgregar = new Button();
            btnQuitar = new Button();
            cmbReceiptKind = new ComboBox();
            listClientes = new ListBox();
            lblSaleList = new Label();
            lblItemDetails = new Label();
            label1 = new Label();
            txtDetailProductId = new TextBox();
            txtDetailCantidad = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtDetailPrecio = new TextBox();
            btnDetailsAdd = new Button();
            btDetailsDelete = new Button();
            btnDetailsUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // dgvItems
            // 
            dgvItems.ColumnHeadersHeight = 29;
            dgvItems.Location = new Point(322, 260);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.RowHeadersWidth = 51;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(540, 300);
            dgvItems.TabIndex = 0;
            dgvItems.CellClick += dgvItems_CellClick;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeight = 29;
            dgvVentas.Location = new Point(23, 260);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(266, 300);
            dgvVentas.TabIndex = 1;
            dgvVentas.SelectionChanged += dgvVentas_SelectionChanged;
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
            lblTotal.Location = new Point(322, 574);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(150, 20);
            lblTotal.TabIndex = 4;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(23, 574);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(76, 30);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.Click += btnAgregarVentaCompra_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(121, 574);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(76, 30);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "Eliminar";
            btnQuitar.Click += btnQuitarCompraVenta_Click;
            // 
            // cmbReceiptKind
            // 
            cmbReceiptKind.Items.AddRange(new object[] { "Venta", "Compra" });
            cmbReceiptKind.Location = new Point(270, 67);
            cmbReceiptKind.Name = "cmbReceiptKind";
            cmbReceiptKind.Size = new Size(124, 23);
            cmbReceiptKind.TabIndex = 8;
            cmbReceiptKind.SelectedIndexChanged += cmbReceiptKind_SelectedIndexChanged;
            // 
            // listClientes
            // 
            listClientes.FormattingEnabled = true;
            listClientes.ItemHeight = 15;
            listClientes.Location = new Point(23, 49);
            listClientes.Name = "listClientes";
            listClientes.Size = new Size(241, 169);
            listClientes.TabIndex = 9;
            listClientes.SelectedIndexChanged += listClientes_SelectedIndexChanged;
            // 
            // lblSaleList
            // 
            lblSaleList.AutoSize = true;
            lblSaleList.Location = new Point(23, 231);
            lblSaleList.Name = "lblSaleList";
            lblSaleList.Size = new Size(104, 15);
            lblSaleList.TabIndex = 10;
            lblSaleList.Text = "Historial de Ventas";
            // 
            // lblItemDetails
            // 
            lblItemDetails.AutoSize = true;
            lblItemDetails.Location = new Point(322, 231);
            lblItemDetails.Name = "lblItemDetails";
            lblItemDetails.Size = new Size(91, 15);
            lblItemDetails.TabIndex = 11;
            lblItemDetails.Text = "Detalle de Venta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(270, 49);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 12;
            label1.Text = "Tipo de Facturas";
            // 
            // txtDetailProductId
            // 
            txtDetailProductId.Location = new Point(868, 319);
            txtDetailProductId.Name = "txtDetailProductId";
            txtDetailProductId.Size = new Size(100, 23);
            txtDetailProductId.TabIndex = 13;
            txtDetailProductId.Leave += txtDetailProductId_Leave;
            // 
            // txtDetailCantidad
            // 
            txtDetailCantidad.Location = new Point(868, 383);
            txtDetailCantidad.Name = "txtDetailCantidad";
            txtDetailCantidad.Size = new Size(100, 23);
            txtDetailCantidad.TabIndex = 14;
            txtDetailCantidad.Leave += txtDetailCantidad_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(868, 291);
            label2.Name = "label2";
            label2.Size = new Size(85, 15);
            label2.TabIndex = 18;
            label2.Text = "Id de Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(868, 355);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 19;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(868, 419);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 20;
            label4.Text = "Precio Unitario";
            // 
            // txtDetailPrecio
            // 
            txtDetailPrecio.Location = new Point(868, 447);
            txtDetailPrecio.Name = "txtDetailPrecio";
            txtDetailPrecio.Size = new Size(100, 23);
            txtDetailPrecio.TabIndex = 15;
            txtDetailPrecio.Leave += txtDetailPrecio_Leave;
            // 
            // btnDetailsAdd
            // 
            btnDetailsAdd.BackColor = Color.YellowGreen;
            btnDetailsAdd.Location = new Point(868, 485);
            btnDetailsAdd.Name = "btnDetailsAdd";
            btnDetailsAdd.Size = new Size(107, 41);
            btnDetailsAdd.TabIndex = 21;
            btnDetailsAdd.Text = "Agregar";
            btnDetailsAdd.UseVisualStyleBackColor = false;
            btnDetailsAdd.Click += btDetailsAdd_Click;
            // 
            // btDetailsDelete
            // 
            btDetailsDelete.BackColor = Color.Salmon;
            btDetailsDelete.Location = new Point(868, 573);
            btDetailsDelete.Name = "btDetailsDelete";
            btDetailsDelete.Size = new Size(107, 41);
            btDetailsDelete.TabIndex = 22;
            btDetailsDelete.Text = "Borrar";
            btDetailsDelete.UseVisualStyleBackColor = false;
            btDetailsDelete.Click += btDetailsDelete_Click;
            // 
            // btnDetailsUpdate
            // 
            btnDetailsUpdate.BackColor = Color.SandyBrown;
            btnDetailsUpdate.Location = new Point(868, 529);
            btnDetailsUpdate.Name = "btnDetailsUpdate";
            btnDetailsUpdate.Size = new Size(107, 41);
            btnDetailsUpdate.TabIndex = 23;
            btnDetailsUpdate.Text = "Actualizar";
            btnDetailsUpdate.UseVisualStyleBackColor = false;
            btnDetailsUpdate.Click += btnDetailsUpdate_Click;
            // 
            // frmVentas
            // 
            ClientSize = new Size(1012, 638);
            Controls.Add(btnDetailsUpdate);
            Controls.Add(btDetailsDelete);
            Controls.Add(btnDetailsAdd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtDetailPrecio);
            Controls.Add(txtDetailCantidad);
            Controls.Add(txtDetailProductId);
            Controls.Add(label1);
            Controls.Add(lblItemDetails);
            Controls.Add(lblSaleList);
            Controls.Add(listClientes);
            Controls.Add(cmbReceiptKind);
            Controls.Add(dgvItems);
            Controls.Add(dgvVentas);
            Controls.Add(lblCliente);
            Controls.Add(lblTotal);
            Controls.Add(btnAgregar);
            Controls.Add(btnQuitar);
            Name = "frmVentas";
            Text = "Ventas / Compras";
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private ComboBox cmbReceiptKind;
        private ListBox listClientes;
        private Label lblSaleList;
        private Label lblItemDetails;
        private Label label1;
        private TextBox txtDetailProductId;
        private TextBox txtDetailCantidad;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtDetailPrecio;
        private Button btnDetailsAdd;
        private Button btDetailsDelete;
        private Button btnDetailsUpdate;
    }
}
