using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Colegio_Panamericana.Connections;
using MySql.Data.MySqlClient;

namespace Colegio_Panamericana
{
    public partial class IniciarSesion : Form
    {
        //hola chaps-chaps,estoy un tanto seguroque esta conexion la  vas a tener que hacer statica en algun momento para no tenerla que levantar acada rato
        //dain out
        //hey hye ahora hay github :)
        MySqlConnection connection = Conexion.connection();
        
        public IniciarSesion()
        {
            InitializeComponent();
            try
            { 
            connection.Open();
            }catch(Exception e)
            {
                MessageBox.Show("Error al conectar con base de datos, contactar con el administrador.");
                MessageBox.Show(e.Message);
            }
        }

        public void Login(string user, string pass)
        {
            try
            {
                MySqlCommand validar = new MySqlCommand("SELECT Tipo_Cuenta FROM Empleado WHERE Usuario like '%" + user +"%' AND Contraseña=@Contraseña", connection);
                validar.Parameters.AddWithValue("Contraseña", pass);
                MySqlDataAdapter adapter = new MySqlDataAdapter(validar);
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                if (table.Rows.Count == 1)
                {
                    if (table.Rows[0][0].ToString() == "Administrador")
                    {
                        Inicio_Administrador form = new Inicio_Administrador();
                        form.Closed += (s, args) => this.Close();
                        form.Show();

                    }
                    else if (table.Rows[0][0].ToString() == "Usuario")
                    {
                        Inicio_Usuario form = new Inicio_Usuario();
                        form.Closed += (s, args) => this.Close();
                        form.Show();
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

        private void TxtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPass.Select();
                txtPass.Focus();
            }
        }

        private void TxtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
