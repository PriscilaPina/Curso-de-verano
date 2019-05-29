namespace Colegio_Panamericana
{
    partial class Inicio_Administrador
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
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.tabEmpleados = new System.Windows.Forms.TabPage();
            this.btnRegister = new System.Windows.Forms.Button();
            this.dGridEmpleado = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabContraseña = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtConPass = new System.Windows.Forms.TextBox();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblConPass = new System.Windows.Forms.Label();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.tabMenu.SuspendLayout();
            this.tabEmpleados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridEmpleado)).BeginInit();
            this.tabContraseña.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabMenu.Controls.Add(this.tabInicio);
            this.tabMenu.Controls.Add(this.tabEmpleados);
            this.tabMenu.Controls.Add(this.tabContraseña);
            this.tabMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMenu.Location = new System.Drawing.Point(13, 13);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(759, 436);
            this.tabMenu.TabIndex = 0;
            // 
            // tabInicio
            // 
            this.tabInicio.BackColor = System.Drawing.Color.Transparent;
            this.tabInicio.Location = new System.Drawing.Point(4, 25);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tabInicio.Size = new System.Drawing.Size(751, 407);
            this.tabInicio.TabIndex = 0;
            this.tabInicio.Text = "Inicio";
            // 
            // tabEmpleados
            // 
            this.tabEmpleados.Controls.Add(this.btnRegister);
            this.tabEmpleados.Controls.Add(this.dGridEmpleado);
            this.tabEmpleados.Controls.Add(this.btnSearch);
            this.tabEmpleados.Controls.Add(this.txtSearch);
            this.tabEmpleados.Location = new System.Drawing.Point(4, 25);
            this.tabEmpleados.Name = "tabEmpleados";
            this.tabEmpleados.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpleados.Size = new System.Drawing.Size(751, 407);
            this.tabEmpleados.TabIndex = 1;
            this.tabEmpleados.Text = "Usuarios";
            this.tabEmpleados.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(562, 65);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(169, 25);
            this.btnRegister.TabIndex = 8;
            this.btnRegister.Text = "Registrar Empleado";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // dGridEmpleado
            // 
            this.dGridEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridEmpleado.Location = new System.Drawing.Point(20, 104);
            this.dGridEmpleado.Name = "dGridEmpleado";
            this.dGridEmpleado.Size = new System.Drawing.Size(711, 262);
            this.dGridEmpleado.TabIndex = 7;
            this.dGridEmpleado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGridEmpleado_CellClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(150, 40);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(64, 24);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(20, 41);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(135, 22);
            this.txtSearch.TabIndex = 5;
            // 
            // tabContraseña
            // 
            this.tabContraseña.BackColor = System.Drawing.Color.Transparent;
            this.tabContraseña.Controls.Add(this.btnSave);
            this.tabContraseña.Controls.Add(this.txtConPass);
            this.tabContraseña.Controls.Add(this.txtNewPass);
            this.tabContraseña.Controls.Add(this.txtUsuario);
            this.tabContraseña.Controls.Add(this.lblConPass);
            this.tabContraseña.Controls.Add(this.lblNewPass);
            this.tabContraseña.Controls.Add(this.lblUser);
            this.tabContraseña.Location = new System.Drawing.Point(4, 25);
            this.tabContraseña.Name = "tabContraseña";
            this.tabContraseña.Padding = new System.Windows.Forms.Padding(3);
            this.tabContraseña.Size = new System.Drawing.Size(751, 407);
            this.tabContraseña.TabIndex = 2;
            this.tabContraseña.Text = "Recuperación de Contraseña";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(147, 283);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // txtConPass
            // 
            this.txtConPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConPass.Location = new System.Drawing.Point(84, 229);
            this.txtConPass.Name = "txtConPass";
            this.txtConPass.PasswordChar = '*';
            this.txtConPass.Size = new System.Drawing.Size(206, 24);
            this.txtConPass.TabIndex = 5;
            // 
            // txtNewPass
            // 
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(84, 170);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PasswordChar = '*';
            this.txtNewPass.Size = new System.Drawing.Size(206, 24);
            this.txtNewPass.TabIndex = 4;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(82, 110);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(208, 24);
            this.txtUsuario.TabIndex = 3;
            // 
            // lblConPass
            // 
            this.lblConPass.AutoSize = true;
            this.lblConPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConPass.Location = new System.Drawing.Point(102, 208);
            this.lblConPass.Name = "lblConPass";
            this.lblConPass.Size = new System.Drawing.Size(175, 18);
            this.lblConPass.TabIndex = 2;
            this.lblConPass.Text = "Confirmar Contraseña";
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(115, 149);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(147, 18);
            this.lblNewPass.TabIndex = 1;
            this.lblNewPass.Text = "Nueva Contraseña";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(159, 89);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(67, 18);
            this.lblUser.TabIndex = 0;
            this.lblUser.Text = "Usuario";
            // 
            // Inicio_Administrador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(213)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.tabMenu);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Inicio_Administrador";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colegio Panamericana - Principal";
            this.tabMenu.ResumeLayout(false);
            this.tabEmpleados.ResumeLayout(false);
            this.tabEmpleados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridEmpleado)).EndInit();
            this.tabContraseña.ResumeLayout(false);
            this.tabContraseña.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.TabPage tabEmpleados;
        private System.Windows.Forms.TabPage tabContraseña;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtConPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblConPass;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.DataGridView dGridEmpleado;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}