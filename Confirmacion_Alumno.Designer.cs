namespace Colegio_Panamericana
{
    partial class Confirmacion_Alumno
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
            this.lblConfirmacion = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.lblAlumno = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConfirmacion
            // 
            this.lblConfirmacion.AutoSize = true;
            this.lblConfirmacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmacion.Location = new System.Drawing.Point(53, 33);
            this.lblConfirmacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfirmacion.Name = "lblConfirmacion";
            this.lblConfirmacion.Size = new System.Drawing.Size(318, 24);
            this.lblConfirmacion.TabIndex = 0;
            this.lblConfirmacion.Text = "¿Deseas eliminar a este alumno?";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(16, 94);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(329, 94);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // lblAlumno
            // 
            this.lblAlumno.AutoSize = true;
            this.lblAlumno.Location = new System.Drawing.Point(388, 39);
            this.lblAlumno.Name = "lblAlumno";
            this.lblAlumno.Size = new System.Drawing.Size(0, 17);
            this.lblAlumno.TabIndex = 3;
            this.lblAlumno.Visible = false;
            // 
            // Confirmacion_Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 127);
            this.Controls.Add(this.lblAlumno);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblConfirmacion);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(461, 174);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(461, 174);
            this.Name = "Confirmacion_Alumno";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar Alumno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfirmacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label lblAlumno;
    }
}