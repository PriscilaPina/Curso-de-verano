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
    public partial class Inicio_Usuario : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Usuario()
        {
            InitializeComponent();
            connection.Open();
            Dates(dGridAlumno);
        }

        public void Dates(DataGridView data)
        {
            MySqlCommand dates = new MySqlCommand("SELECT Nombre, Apellido_Paterno, Apellido_Materno, Edad, Nombre_Madre, Celular_Madre FROM Alumno", connection);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(dates);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                data.DataSource = source;
                adapter.Update(table);
            }
            catch(Exception)
            {

            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            new Registro_Alumnos().Show();
        }
    }
}
