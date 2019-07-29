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
    public partial class Pagos_Alumnos : Form
    {
        MySqlConnection connection = Conexion.connection();
        public int idAlumno;
        int noAbonos;
        public Perfil_Alumno main_;
        public Pagos_Alumnos()
        {
            connection.Open();
            InitializeComponent();
            
        }

        public bool DescuentoFamiliar(string noFamiliar)
        {
            try
            {
                MySqlCommand query = new MySqlCommand("SELECT id_Alumno FROM Alumno WHERE No_Familiar= @noFamiliar", connection);
                query.Parameters.AddWithValue("noFamiliar", noFamiliar);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if(table.Rows.Count > 1)
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }
        public void ObtenerAbonos()
        {
            try { 
                MySqlCommand query = new MySqlCommand("SELECT * FROM concepto_pago WHERE id_Alumno= @id_Alumno", connection);
                query.Parameters.AddWithValue("id_Alumno", idAlumno);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                double abonado = 0.0;
                if (table.Rows.Count > 0)
                {
                    for(int i=0;i< table.Rows.Count; i++)
                    {
                        abonado += double.Parse(table.Rows[i][1].ToString());
                    }
                    noAbonos = table.Rows.Count;
                }
                else
                {
                    noAbonos = 0;
                }
                txtTotalAbonado.Text = abonado.ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        public void cargarDatos()
        {
            try { 
            MySqlCommand query = new MySqlCommand("SELECT Nombre ,Apellido_Paterno ,Apellido_Materno, No_Familiar FROM Alumno WHERE id_Alumno= @id_Alumno", connection);
            query.Parameters.AddWithValue("id_Alumno", idAlumno);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable table = new DataTable();
            adapter.Fill(table);
            txtNombre.Text = table.Rows[0][0].ToString() + " " + table.Rows[0][1].ToString() + " " + table.Rows[0][2].ToString();
            string noFamiliar = table.Rows[0][3].ToString();
            bool descuentoFamiliar = DescuentoFamiliar(noFamiliar);
            query = new MySqlCommand("SELECT * FROM kardex WHERE id_Alumno= @id_Alumno", connection);
            query.Parameters.Clear();
            query.Parameters.AddWithValue("id_Alumno", idAlumno);
            adapter = new MySqlDataAdapter(query); table = new DataTable(); adapter.Fill(table);
            int idHorario = int.Parse(table.Rows[0][2].ToString());
            string[] conceptos = table.Rows[0][1].ToString().Split(',');
            string q_uery = "SELECT * FROM concepto_cobro Where id_Cobro in (";
            foreach (var c in conceptos)
            {
                if (c == conceptos[0])
                {
                    q_uery += c;
                }
                else
                {
                    q_uery += "," + c;
                }
            }
            q_uery += ");";
            query = new MySqlCommand(q_uery, connection);
            query.Parameters.Clear(); adapter = new MySqlDataAdapter(query); table = new DataTable(); adapter.Fill(table);

            double sTotal = 0.0, total = 0.0;
            bool issste = false;
            for (int i = 0; i < table.Rows.Count; i++)
            {
                issste = table.Rows[i][1].ToString() == "ISSSTE" ? true : false;
                if (issste)
                {
                    total = double.Parse(table.Rows[i][2].ToString());
                    break;
                }
                else
                {
                    sTotal += double.Parse(table.Rows[i][2].ToString());
                }
            }

            if (!issste) {
                query = new MySqlCommand("SELECT * FROM horario WHERE id_Horario= @horario", connection);
                query.Parameters.Clear();
                query.Parameters.AddWithValue("horario", idHorario);
                adapter = new MySqlDataAdapter(query); table = new DataTable(); adapter.Fill(table);
                sTotal += double.Parse(table.Rows[0][4].ToString());

                total = descuentoFamiliar ? sTotal - (sTotal * .10) : sTotal;
            }
            txtMontoTotal.Text = total.ToString();
            ObtenerAbonos();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void BntGuardar_Click(object sender, EventArgs e)
        {
            if (txtAbonar.Text == "")
            {
                MessageBox.Show("No se a capturado un monto de abono", "Error al abonar cantidad");
            }
            else
            {
                if (CrearAbono())
                {
                    MessageBox.Show("Abono realizado exitosamente");main_.CargarTabla();

                    this.Close();
                }
            }
        }   

        public bool CrearAbono()
        {
            try
            {
                MySqlCommand query = new MySqlCommand("INSERT INTO concepto_pago (`Abono`, `No_Pago`, `Total`, `FechaPago`, `id_Alumno`) " +
                                                                          "VALUES ( @abono, @noPago, @total, @fecha, @id_Alumno);",connection);
                query.Parameters.AddWithValue("abono",txtAbonar.Text);
                query.Parameters.AddWithValue("noPago", noAbonos+1);
                query.Parameters.AddWithValue("total", txtMontoTotal.Text);
                query.Parameters.AddWithValue("fecha", DateTime.Today);
                query.Parameters.AddWithValue("id_Alumno", idAlumno);
                query.ExecuteNonQuery();
                return true;
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }

        }

        private void TxtAbonar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) &&
                e.KeyChar != Convert.ToChar(Keys.Back) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
                       
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
