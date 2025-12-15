namespace proyFinalAgropecuaria
{
    partial class FormMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitulo = new Label();
            panelBotones = new Panel();
            btnProductos = new Button();
            btnClientes = new Button();
            btnProveedores = new Button();
            btnVentas = new Button();
            btnInventario = new Button();
            panelMenu = new Panel();
            panelContenedor = new Panel();
            panelTop.SuspendLayout();
            panelBotones.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(25, 25, 50);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(290, 100);
            panelTop.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Fill;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.LimeGreen;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(290, 1000);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "AgroCampo S.A.";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelBotones
            // 
            panelBotones.BackColor = Color.FromArgb(30, 30, 60);
            panelBotones.Controls.Add(btnProductos);
            panelBotones.Controls.Add(btnClientes);
            panelBotones.Controls.Add(btnProveedores);
            panelBotones.Controls.Add(btnVentas);
            panelBotones.Controls.Add(btnInventario);
            panelBotones.Dock = DockStyle.Fill;
            panelBotones.Location = new Point(0, 1000);
            panelBotones.Name = "panelBotones";
            panelBotones.Size = new Size(290, 0);
            panelBotones.TabIndex = 0;
            panelBotones.Paint += panelBotones_Paint;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(30, 30, 60);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(10, 25);
            btnProductos.Margin = new Padding(3, 4, 3, 4);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(270, 100);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(10, 140);
            btnClientes.Margin = new Padding(3, 4, 3, 4);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(270, 100);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(10, 255);
            btnProveedores.Margin = new Padding(3, 4, 3, 4);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(270, 100);
            btnProveedores.TabIndex = 3;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = Color.White;
            btnVentas.Location = new Point(10, 370);
            btnVentas.Margin = new Padding(3, 4, 3, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(270, 100);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas/Compras";
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(10, 485);
            btnInventario.Margin = new Padding(3, 4, 3, 4);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(270, 100);
            btnInventario.TabIndex = 5;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(30, 30, 60);
            panelMenu.Controls.Add(panelBotones);
            panelMenu.Controls.Add(panelTop);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(3, 4, 3, 4);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(290, 808);
            panelMenu.TabIndex = 0;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = SystemColors.Control;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(290, 0);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1009, 808);
            panelContenedor.TabIndex = 6;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1299, 808);
            Controls.Add(panelContenedor);
            Controls.Add(panelMenu);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormMenu";
            Text = "Sistema AgroCampo";
            panelTop.ResumeLayout(false);
            panelBotones.ResumeLayout(false);
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private Panel panelTop;
        private Panel panelBotones;
      


        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel panelContenedor;




    }
}

