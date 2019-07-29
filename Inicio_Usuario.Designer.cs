namespace Colegio_Panamericana
{
    partial class Inicio_Usuario
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInicio = new System.Windows.Forms.TabPage();
            this.tabVerano = new System.Windows.Forms.TabPage();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.dGridAlumno = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabVerano.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAlumno)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInicio);
            this.tabControl1.Controls.Add(this.tabVerano);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(17, 16);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1012, 537);
            this.tabControl1.TabIndex = 0;
            // 
            // tabInicio
            // 
            this.tabInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabInicio.Location = new System.Drawing.Point(4, 29);
            this.tabInicio.Margin = new System.Windows.Forms.Padding(4);
            this.tabInicio.Name = "tabInicio";
            this.tabInicio.Padding = new System.Windows.Forms.Padding(4);
            this.tabInicio.Size = new System.Drawing.Size(1004, 504);
            this.tabInicio.TabIndex = 0;
            this.tabInicio.Text = "Inicio";
            this.tabInicio.UseVisualStyleBackColor = true;
            // 
            // tabVerano
            // 
            this.tabVerano.Controls.Add(this.btnRegister);
            this.tabVerano.Controls.Add(this.btnReporte);
            this.tabVerano.Controls.Add(this.dGridAlumno);
            this.tabVerano.Controls.Add(this.btnSearch);
            this.tabVerano.Controls.Add(this.txtSearch);
            this.tabVerano.Location = new System.Drawing.Point(4, 29);
            this.tabVerano.Margin = new System.Windows.Forms.Padding(4);
            this.tabVerano.Name = "tabVerano";
            this.tabVerano.Padding = new System.Windows.Forms.Padding(4);
            this.tabVerano.Size = new System.Drawing.Size(1004, 504);
            this.tabVerano.TabIndex = 1;
            this.tabVerano.Text = "Curso de Verano";
            this.tabVerano.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(805, 49);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(169, 31);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Registrar Alumno";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(791, 444);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(184, 31);
            this.btnReporte.TabIndex = 3;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // dGridAlumno
            // 
            this.dGridAlumno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGridAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGridAlumno.Location = new System.Drawing.Point(27, 97);
            this.dGridAlumno.Margin = new System.Windows.Forms.Padding(4);
            this.dGridAlumno.Name = "dGridAlumno";
            this.dGridAlumno.Size = new System.Drawing.Size(948, 322);
            this.dGridAlumno.TabIndex = 2;
            this.dGridAlumno.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGridAlumno_CellDoubleClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(200, 18);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(85, 30);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Buscar";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(27, 20);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 26);
            this.txtSearch.TabIndex = 0;
            // 
            // Inicio_Usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(213)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(1043, 558);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1061, 605);
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "Inicio_Usuario";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colegio Panamericana - Principal";
            this.tabControl1.ResumeLayout(false);
            this.tabVerano.ResumeLayout(false);
            this.tabVerano.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridAlumno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInicio;
        private System.Windows.Forms.TabPage tabVerano;
        private System.Windows.Forms.DataGridView dGridAlumno;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnReporte;
    }
}