using Colegio_Panamericana.Connections;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Colegio_Panamericana
{
    public partial class Perfil_Empleado : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Administrador main_;
        public Perfil_Empleado(int id, string name, string lastP, string lastM, string user, string pass, string type)
        {
            InitializeComponent();
            connection.Open();

            lblIdEmpleado.Text = id.ToString();
            txtNombre.Text = name;
            txtApellidoP.Text = lastP;
            txtApellidoM.Text = lastM;
            txtUser.Text = user;
            txtPass.Text = pass;
            cmbTipo.Text = type;
        }
        public void EditEmpleado(int id, string name, string lastP, string lastM, string user, string pass, string type)
        {
            try
            {
                MySqlCommand edit = new MySqlCommand("UPDATE Empleado SET Nombre = @Nombre, Apellido_Paterno = @ApellidoP, Apellido_Materno = @ApellidoM, Usuario = @Usuario, Contraseña = @Contraseña, Tipo_Cuenta = @TipoCuenta WHERE id_Empleado=@id", connection);
                edit.Parameters.AddWithValue("Nombre", name);
                edit.Parameters.AddWithValue("ApellidoP", lastP);
                edit.Parameters.AddWithValue("ApellidoM", lastM);
                edit.Parameters.AddWithValue("Usuario", user);
                edit.Parameters.AddWithValue("Contraseña", pass);
                edit.Parameters.AddWithValue("TipoCuenta", type);
                edit.Parameters.AddWithValue("id", id);
                edit.ExecuteNonQuery();

                MessageBox.Show("La informacion del empleado fue modificada correctamente");
                this.Dispose();
            }
            catch (Exception)
            {

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtApellidoP.Enabled = true;
            txtApellidoM.Enabled = true;
            txtUser.Enabled = true;
            txtPass.Enabled = true;
            cmbTipo.Enabled = true;
            btnEliminar.Visible = false;
            btnSave.Visible = true;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            EditEmpleado(int.Parse(lblIdEmpleado.Text), txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtUser.Text, txtPass.Text, cmbTipo.Text);
            main_.Dates();
            this.Close();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion_Empleado confirmacion = new Confirmacion_Empleado(int.Parse(lblIdEmpleado.Text));
            confirmacion.main_ = this.main_;
            confirmacion.ShowDialog();
            this.Close();
        }
    }
}
