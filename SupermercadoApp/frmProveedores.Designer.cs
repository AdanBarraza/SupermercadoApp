namespace SupermercadoApp
{
    partial class frmProveedores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvProveedores = new DataGridView();
            txtEmpresa = new TextBox();
            txtTelefono = new TextBox();
            txtTipoProductos = new TextBox();
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCargarProv = new Button();
            btnAgregarProv = new Button();
            btnActualizarProv = new Button();
            btnEliminarProv = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            SuspendLayout();
            // 
            // dgvProveedores
            // 
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Dock = DockStyle.Top;
            dgvProveedores.Location = new Point(0, 0);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.Size = new Size(800, 188);
            dgvProveedores.TabIndex = 0;
            dgvProveedores.SelectionChanged += dgvProveedores_SelectionChanged;
            // 
            // txtEmpresa
            // 
            txtEmpresa.Location = new Point(39, 228);
            txtEmpresa.Name = "txtEmpresa";
            txtEmpresa.Size = new Size(125, 27);
            txtEmpresa.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(369, 228);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 2;
            // 
            // txtTipoProductos
            // 
            txtTipoProductos.Location = new Point(203, 228);
            txtTipoProductos.Name = "txtTipoProductos";
            txtTipoProductos.Size = new Size(125, 27);
            txtTipoProductos.TabIndex = 3;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(538, 228);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 205);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 5;
            label1.Text = "Empresa";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(203, 205);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 6;
            label2.Text = "Producto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(369, 205);
            label3.Name = "label3";
            label3.Size = new Size(67, 20);
            label3.TabIndex = 7;
            label3.Text = "Telefono";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(538, 205);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 8;
            label4.Text = "Email";
            // 
            // btnCargarProv
            // 
            btnCargarProv.Location = new Point(53, 282);
            btnCargarProv.Name = "btnCargarProv";
            btnCargarProv.Size = new Size(94, 29);
            btnCargarProv.TabIndex = 9;
            btnCargarProv.Text = "Cargar";
            btnCargarProv.UseVisualStyleBackColor = true;
            btnCargarProv.Click += btnCargarProv_Click;
            // 
            // btnAgregarProv
            // 
            btnAgregarProv.Location = new Point(215, 282);
            btnAgregarProv.Name = "btnAgregarProv";
            btnAgregarProv.Size = new Size(94, 29);
            btnAgregarProv.TabIndex = 10;
            btnAgregarProv.Text = "Agregar";
            btnAgregarProv.UseVisualStyleBackColor = true;
            btnAgregarProv.Click += btnAgregarProv_Click;
            // 
            // btnActualizarProv
            // 
            btnActualizarProv.Location = new Point(378, 282);
            btnActualizarProv.Name = "btnActualizarProv";
            btnActualizarProv.Size = new Size(94, 29);
            btnActualizarProv.TabIndex = 11;
            btnActualizarProv.Text = "Actualizar";
            btnActualizarProv.UseVisualStyleBackColor = true;
            btnActualizarProv.Click += btnActualizarProv_Click;
            // 
            // btnEliminarProv
            // 
            btnEliminarProv.Location = new Point(550, 282);
            btnEliminarProv.Name = "btnEliminarProv";
            btnEliminarProv.Size = new Size(94, 29);
            btnEliminarProv.TabIndex = 12;
            btnEliminarProv.Text = "Eliminar";
            btnEliminarProv.UseVisualStyleBackColor = true;
            btnEliminarProv.Click += btnEliminarProv_Click;
            // 
            // frmProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 344);
            Controls.Add(btnEliminarProv);
            Controls.Add(btnActualizarProv);
            Controls.Add(btnAgregarProv);
            Controls.Add(btnCargarProv);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(txtTipoProductos);
            Controls.Add(txtTelefono);
            Controls.Add(txtEmpresa);
            Controls.Add(dgvProveedores);
            Name = "frmProveedores";
            Text = "frmProveedores";
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProveedores;
        private TextBox txtEmpresa;
        private TextBox txtTelefono;
        private TextBox txtTipoProductos;
        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnCargarProv;
        private Button btnAgregarProv;
        private Button btnActualizarProv;
        private Button btnEliminarProv;
    }
}