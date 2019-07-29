using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Colegio_Panamericana.Connections;

namespace Colegio_Panamericana
{
    public partial class Registro_Empleado : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Administrador main_;
        public Registro_Empleado()
        {
            InitializeComponent();
            connection.Open();
        }

        public void Insert(string name, string lastP, string lastM, string user, string pass, string type)
        {
            try { 
            MySqlCommand newEmployee = new MySqlCommand("INSERT INTO Empleado (Nombre, Apellido_Paterno, Apellido_Materno, Usuario, Contraseña, Tipo_Cuenta) VALUES(@Nombre, @Apellido_P, @Apellido_M, @Usuario, @Contraseña, @Tipo_Cuenta)", connection);
            newEmployee.Parameters.AddWithValue("Nombre", name);
            newEmployee.Parameters.AddWithValue("Apellido_P", lastP);
            newEmployee.Parameters.AddWithValue("Apellido_M", lastM);
            newEmployee.Parameters.AddWithValue("Usuario",  user);
            newEmployee.Parameters.AddWithValue("Contraseña", pass);
            newEmployee.Parameters.AddWithValue("Tipo_Cuenta", type);
            newEmployee.ExecuteNonQuery();
            MessageBox.Show("El usuario fue agregado correctamente");
            this.Dispose();
            }catch(Exception)
            {
                MessageBox.Show("Hubo un problema al crear al nuevo usuario");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

            Insert(txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, txtUser.Text, txtPass.Text, cmbTipo.Text);
            main_.Dates();
            this.Close();
        }
    }
}
