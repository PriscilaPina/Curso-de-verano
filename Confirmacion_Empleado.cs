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
    public partial class Confirmacion_Empleado : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Administrador main_;
        public Confirmacion_Empleado(int id)
        {
            InitializeComponent();
            connection.Open();
            lblEmpleado.Text = id.ToString();
        }

        public void Delete(int id)
        {
            try
            {
                MySqlCommand delete = new MySqlCommand("DELETE FROM Empleado WHERE id_Empleado = @id", connection);
                delete.Parameters.AddWithValue("id", id);
                delete.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Delete(int.Parse(lblEmpleado.Text));
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
