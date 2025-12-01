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
            panelMenu = new Panel();
            btnProductos = new Button();
            btnClientes = new Button();
            btnProveedores = new Button();
            btnVentas = new Button();
            btnInventario = new Button();
            panelContenedor = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(30, 30, 60);
            panelMenu.Controls.Add(btnProductos);
            panelMenu.Controls.Add(btnClientes);
            panelMenu.Controls.Add(btnProveedores);
            panelMenu.Controls.Add(btnVentas);
            panelMenu.Controls.Add(btnInventario);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(175, 422);
            panelMenu.TabIndex = 0;
            // 
            // btnProductos
            // 
            btnProductos.BackColor = Color.FromArgb(30, 30, 60);
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.ForeColor = Color.White;
            btnProductos.Location = new Point(9, 19);
            btnProductos.Name = "btnProductos";
            btnProductos.Size = new Size(158, 38);
            btnProductos.TabIndex = 1;
            btnProductos.Text = "Productos";
            btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnClientes
            // 
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.ForeColor = Color.White;
            btnClientes.Location = new Point(9, 66);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(158, 38);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = true;
            // 
            // btnProveedores
            // 
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(9, 112);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Size = new Size(158, 38);
            btnProveedores.TabIndex = 3;
            btnProveedores.Text = "Proveedores";
            btnProveedores.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.ForeColor = Color.White;
            btnVentas.Location = new Point(9, 159);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(158, 38);
            btnVentas.TabIndex = 4;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // btnInventario
            // 
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(9, 206);
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(158, 38);
            btnInventario.TabIndex = 5;
            btnInventario.Text = "Inventario";
            btnInventario.UseVisualStyleBackColor = true;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(175, 0);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(863, 422);
            panelContenedor.TabIndex = 6;
            // 
            // FormMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1038, 422);
            Controls.Add(panelContenedor);
            Controls.Add(panelMenu);
            Name = "FormMenu";
            Text = "Sistema AgroCampo";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnVentas;
        private System.Windows.Forms.Button btnProveedores;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Panel panelContenedor;
    }
}

