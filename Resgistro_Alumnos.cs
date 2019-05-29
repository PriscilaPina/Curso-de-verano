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
    public partial class Registro_Alumnos : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Registro_Alumnos()
        {
            InitializeComponent();
            lblAño.Text = DateTime.Now.ToString("yyyy");
            connection.Open();
            CargarHorarios();
            comboBox2.Items.Add("1");
            comboBox2.Items.Add("2");
            comboBox2.Items.Add("3");
            comboBox2.SelectedIndex = 0;

        }

        public void CargarHorarios(){
            MySqlCommand getHorarios= new MySqlCommand("SELECT id_Horario, Entrada, Salida, Descripcion FROM horario", connection);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(getHorarios);
                DataTable table = new DataTable();
                adapter.Fill(table);
                foreach (var row in table.Rows) {
                    string text = table.Rows[0][1].ToString() + " a " + table.Rows[0][2].ToString();
                    cmbHorario.Items.Add(text);
                }
            }
            catch {
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (checarCampos()) {
                MySqlCommand setAlumno = new MySqlCommand("INSERT INTO alumno (`Nombre`, `Apellido_Paterno`, `Apellido_Materno`, `Edad`, `Fecha_Nacimiento`, `Direccion`, `Nombre_Padre`, `Celular_Padre`, `Nombre_Madre`, `Celular_Madre`, `No_Familiar`, `Año`, `Status`) " +
                    "VALUES ( '@Nombre', '@Apellido_Paterno', '@Apellido_Materno', '@Edad', '@Fecha_Nacimiento', '@Direccion', '@Nombre_Padre', '@Celular_Padre', '@Nombre_Madre','@Celular_Madre', '@No_Familiar', @Año, '@Status');", connection);
                try
                {
                    setAlumno.Parameters.AddWithValue("Nombre", txtNombre.Text);
                    setAlumno.Parameters.AddWithValue("Apellido_Paterno", txtApellidoP.Text);
                    setAlumno.Parameters.AddWithValue("Apellido_Materno", txtApellidoM.Text);
                    setAlumno.Parameters.AddWithValue("Edad", txtEdad.Text);
                    setAlumno.Parameters.AddWithValue("Fecha_Nacimiento", dateFechaN.Value.ToString());
                    setAlumno.Parameters.AddWithValue("Direccion", txtDireccion.Text);
                    setAlumno.Parameters.AddWithValue("Nombre_Padre", txtPadre.Text);
                    setAlumno.Parameters.AddWithValue("Celular_Padre", txtCelularP.Text);
                    setAlumno.Parameters.AddWithValue("Nombre_Madre", txtMadre.Text);
                    setAlumno.Parameters.AddWithValue("Celular_Madre", txtCelularM.Text);
                    //setAlumno.Parameters.AddWithValue("No_Familiar", user);
                    setAlumno.Parameters.AddWithValue("Año", DateTime.Now.Year);
                    setAlumno.Parameters.AddWithValue("Status", "Activo");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(setAlumno);
                }
                catch (Exception exc) {
                    MessageBox.Show(exc.Message);
                }

            }
            else {
                MessageBox.Show( "Algun campo esta vacio o es incorrecto","Error al capturar Alumno");
            }
        }

        public bool checarCampos()
        {
            bool result = true;
            result = txtNombre.Text != "" ? result : false;
            result = txtApellidoP.Text != "" ? result : false;
            result = txtApellidoM.Text != "" ? result : false;
            result = dateFechaN.Value != null ? result : false;
            result = txtEdad.Text != "" ? result : false;
            result = txtDireccion.Text != "" ? result : false;
            result = txtPadre.Text != "" ? result : false;
            result = txtCelularP.Text != "" ? result : false;
            result = txtMadre.Text != "" ? result : false;
            result = txtCelularM.Text != "" ? result : false;
            try
            {
                result = cmbHorario.SelectedItem.ToString() != "" ? result : false;
                result = comboBox2.SelectedItem.ToString() != "" ? result : false;
            }
            catch {
                result = false;
            }
            return result;
        }

        private void TxtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si no es número Y NO ES
            //la tecla borrar
            if (!Char.IsNumber(e.KeyChar) &&
                e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }
    }
}
