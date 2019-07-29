namespace Colegio_Panamericana
{
    partial class Pagos_Alumnos
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtMontoTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalAbonado = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAbonar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bntGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Enabled = false;
            this.txtNombre.Location = new System.Drawing.Point(119, 13);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(203, 26);
            this.txtNombre.TabIndex = 1;
            // 
            // txtMontoTotal
            // 
            this.txtMontoTotal.Enabled = false;
            this.txtMontoTotal.Location = new System.Drawing.Point(119, 41);
            this.txtMontoTotal.Name = "txtMontoTotal";
            this.txtMontoTotal.Size = new System.Drawing.Size(203, 26);
            this.txtMontoTotal.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Monto total:";
            // 
            // txtTotalAbonado
            // 
            this.txtTotalAbonado.Enabled = false;
            this.txtTotalAbonado.Location = new System.Drawing.Point(119, 69);
            this.txtTotalAbonado.Name = "txtTotalAbonado";
            this.txtTotalAbonado.Size = new System.Drawing.Size(203, 26);
            this.txtTotalAbonado.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Total abonado:";
            // 
            // txtAbonar
            // 
            this.txtAbonar.Location = new System.Drawing.Point(119, 112);
            this.txtAbonar.Name = "txtAbonar";
            this.txtAbonar.Size = new System.Drawing.Size(203, 26);
            this.txtAbonar.TabIndex = 7;
            this.txtAbonar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtAbonar_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Abonar cantidad:";
            // 
            // bntGuardar
            // 
            this.bntGuardar.Location = new System.Drawing.Point(15, 167);
            this.bntGuardar.Name = "bntGuardar";
            this.bntGuardar.Size = new System.Drawing.Size(75, 23);
            this.bntGuardar.TabIndex = 8;
            this.bntGuardar.Text = "Guardar";
            this.bntGuardar.UseVisualStyleBackColor = true;
            this.bntGuardar.Click += new System.EventHandler(this.BntGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(16, 196);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // Pagos_Alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(213)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(332, 263);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bntGuardar);
            this.Controls.Add(this.txtAbonar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalAbonado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMontoTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(350, 310);
            this.MinimumSize = new System.Drawing.Size(350, 310);
            this.Name = "Pagos_Alumnos";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Colegio Panamericana - Pagos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtMontoTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalAbonado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAbonar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bntGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}