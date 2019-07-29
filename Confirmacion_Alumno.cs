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
    public partial class Confirmacion_Alumno : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Usuario main_;

        public Confirmacion_Alumno(int id)
        {
            InitializeComponent();
            connection.Open();

            lblAlumno.Text = id.ToString();
        }

        public void Delete(int id)
        {
            try
            {
                MySqlCommand delete = new MySqlCommand("UPDATE Alumno SET Status ='Inactivo' WHERE id_Alumno= @id", connection);
                delete.Parameters.AddWithValue("id", id);
                delete.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Delete(int.Parse(lblAlumno.Text));
            main_.Dates();
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            main_.Dates();
            this.Close();
        }
    }
}
