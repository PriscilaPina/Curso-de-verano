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
    public partial class IniciarSesion : Form
    {
        //hola chaps-chaps,estoy un tanto seguroque esta conexion la  vas a tener que hacer statica en algun momento para no tenerla que levantar acada rato
        //dain out
        MySqlConnection connection = Conexion.connection();
        
        public IniciarSesion()
        {
            InitializeComponent();
            connection.Open();
            
        }

        public void Login(string user, string pass)
        {
            try
            {
                MySqlCommand validar = new MySqlCommand("SELECT Tipo_Cuenta FROM Empleado WHERE Usuario=@Usuario AND Contraseña=@Contraseña", connection);
                validar.Parameters.AddWithValue("Usuario", user);
                validar.Parameters.AddWithValue("Contraseña", pass);
                MySqlDataAdapter adapter = new MySqlDataAdapter(validar);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                if (table.Rows.Count == 1)
                {
                    if (table.Rows[0][0].ToString() == "Administrador")
                    {
                        new Inicio_Administrador().Show();
                    }
                    else if (table.Rows[0][0].ToString() == "Usuario")
                    {
                        new Inicio_Usuario().Show();
                    }

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña son incorrectos, por favor verificalos");
                }
            }
            catch (Exception)
            {

            }

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Login(this.txtUser.Text, this.txtPass.Text);
        }

        private void LinkPass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Solicita al administrador que te ayude a recuperar tu contraseña");
        }
    }
}
