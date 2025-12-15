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
        private System.Windows.Forms.Button btnFinalizar;

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
            btnFinalizar = new Button();
            cmbReceiptKind = new ComboBox();
            listClientes = new ListBox();
            lblSaleList = new Label();
            lblItemDetails = new Label();
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
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(121, 574);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(76, 30);
            btnQuitar.TabIndex = 6;
            btnQuitar.Text = "Eliminar";
            // 
            // btnFinalizar
            // 
            btnFinalizar.Location = new Point(213, 574);
            btnFinalizar.Name = "btnFinalizar";
            btnFinalizar.Size = new Size(76, 30);
            btnFinalizar.TabIndex = 7;
            btnFinalizar.Text = "Guardar";
            // 
            // cmbReceiptKind
            // 
            cmbReceiptKind.Items.AddRange(new object[] { "Venta", "Compra" });
            cmbReceiptKind.Location = new Point(322, 118);
            cmbReceiptKind.Name = "cmbReceiptKind";
            cmbReceiptKind.Size = new Size(124, 23);
            cmbReceiptKind.TabIndex = 8;
            cmbReceiptKind.SelectedIndexChanged += cmbReceiptKind_SelectedIndexChanged;
            // 
            // listClientes
            // 
            listClientes.FormattingEnabled = true;
            listClientes.ItemHeight = 15;
            listClientes.Location = new Point(23, 32);
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
            lblItemDetails.Location = new Point(462, 231);
            lblItemDetails.Name = "lblItemDetails";
            lblItemDetails.Size = new Size(91, 15);
            lblItemDetails.TabIndex = 11;
            lblItemDetails.Text = "Detalle de Venta";
            // 
            // frmVentas
            // 
            ClientSize = new Size(1012, 638);
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
            Controls.Add(btnFinalizar);
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
    }
}
