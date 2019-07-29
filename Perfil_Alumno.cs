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
    public partial class Perfil_Alumno : Form
    {
        MySqlConnection connection = Conexion.connection();
        int idAlumno;
        public Inicio_Usuario main_;
        public Perfil_Alumno(int id, string name, string last_P, string last_M, int age, string date, string address, string service, string name_P, string celular_P, string name_M, string celular_M)
        {
            InitializeComponent();
            connection.Open();
            idAlumno = id;
            if (service == "IMSS" )
            {
                lblIdAlumno.Text = id.ToString();
                txtNombre.Text = name.ToString();
                txtApellidoP.Text = last_P.ToString();
                txtApellidoM.Text = last_M.ToString();
                txtEdad.Text = age.ToString();
                dateFechaN.Value = DateTime.Parse(date.ToString());
                txtDireccion.Text = address.ToString();
                cmbServivioM.Text = service.ToString();
                txtPadre.Text = name_P.ToString();
                txtCelularP.Text = celular_P.ToString();
                txtMadre.Text = name_M.ToString();
                txtCelularM.Text = celular_M.ToString();
                txtServicioM.Visible = false;
            }
            else if(service == "ISSSTE")
            {
                lblIdAlumno.Text = id.ToString();
                txtNombre.Text = name.ToString();
                txtApellidoP.Text = last_P.ToString();
                txtApellidoM.Text = last_M.ToString();
                txtEdad.Text = age.ToString();
                dateFechaN.Value = DateTime.Parse(date.ToString());
                txtDireccion.Text = address.ToString();
                cmbServivioM.Text = service.ToString();
                txtPadre.Text = name_P.ToString();
                txtCelularP.Text = celular_P.ToString();
                txtMadre.Text = name_M.ToString();
                txtCelularM.Text = celular_M.ToString();
                txtServicioM.Visible = false;
            }
            else
            {
                lblIdAlumno.Text = id.ToString();
                txtNombre.Text = name.ToString();
                txtApellidoP.Text = last_P.ToString();
                txtApellidoM.Text = last_M.ToString();
                txtEdad.Text = age.ToString();
                dateFechaN.Value = DateTime.Parse(date.ToString());
                txtDireccion.Text = address.ToString();
                txtServicioM.Visible = true;
                txtServicioM.Enabled = false;
                txtServicioM.Text = service.ToString();
                txtPadre.Text = name_P.ToString();
                txtCelularP.Text = celular_P.ToString();
                txtMadre.Text = name_M.ToString();
                txtCelularM.Text = celular_M.ToString();
            }
            CargarTabla();
        }
        public void EditKardex()
        {
            int idISSSTE = -1;
            MySqlCommand query = new MySqlCommand("SELECT id_Cobro FROM concepto_cobro WHERE Descripcion=@descripcion", connection);
            query.Parameters.AddWithValue("descripcion", "ISSSTE");
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable table = new DataTable();
            adapter.Fill(table);
            idISSSTE=int.Parse(table.Rows[0][0].ToString());


            query = new MySqlCommand("SELECT IdKardex, ListaConceptos FROM kardex WHERE id_Alumno=@id", connection);
            query.Parameters.Clear();
            query.Parameters.AddWithValue("id", idAlumno);
            adapter = new MySqlDataAdapter(query);
            table = new DataTable();
            adapter.Fill(table);
            int idKardex = int.Parse(table.Rows[0][0].ToString());
            string[] conceptos = table.Rows[0][1].ToString().Split(',');
            if (cmbServivioM.Text == "ISSSTE") {
                var aux = conceptos.ToList();
                aux.Add(idISSSTE.ToString());
                conceptos = aux.Distinct().ToArray();
            }
            else
            {
                conceptos = conceptos.Where(val => val != idISSSTE.ToString()).ToArray();
            }
            string listaConceptos = conceptos[0];
            for(int i = 1; i < conceptos.Length; i++)
            {
                listaConceptos += "," + conceptos[i];
            }

            query = new MySqlCommand("UPDATE kardex SET ListaConceptos=@lista WHERE IdKardex=@id", connection);
            query.Parameters.Clear();
            query.Parameters.AddWithValue("lista", listaConceptos);
            query.Parameters.AddWithValue("id", idKardex);
            query.ExecuteNonQuery();
        }
        public void EditAlumno(int id, string name, string last_P, string last_M, int age, string date, string address, string service, string name_P, string celular_P, string name_M, string celular_M)
        {
            try
            {
                MySqlCommand edit = new MySqlCommand("UPDATE Alumno SET Nombre=@Nombre, Apellido_Paterno=@Paterno, Apellido_Materno=@Materno, Edad=@Edad, Fecha_Nacimiento=@Fecha, Direccion=@Direccion, Servicio_Medico=@Servicio,  Nombre_Padre=@nPadre, Celular_Padre=@cPadre, Nombre_Madre=@nMadre, Celular_Madre=@cMadre WHERE id_Alumno=@id", connection);
                edit.Parameters.AddWithValue("id", id);
                edit.Parameters.AddWithValue("Nombre", name);
                edit.Parameters.AddWithValue("Paterno", last_P);
                edit.Parameters.AddWithValue("Materno", last_M);
                edit.Parameters.AddWithValue("Edad", age);
                edit.Parameters.AddWithValue("Fecha", DateTime.Parse(date).Date);
                edit.Parameters.AddWithValue("Direccion", address);
                edit.Parameters.AddWithValue("Servicio", service);
                edit.Parameters.AddWithValue("nPadre", name_P);
                edit.Parameters.AddWithValue("cPadre", celular_P);
                edit.Parameters.AddWithValue("nMadre", name_M);
                edit.Parameters.AddWithValue("cMadre", celular_M);
                edit.ExecuteNonQuery();
                EditKardex();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtApellidoP.Enabled = true;
            txtApellidoM.Enabled = true;
            txtEdad.Enabled = true;
            dateFechaN.Enabled = true;
            txtDireccion.Enabled = true;
            cmbServivioM.Enabled = true;
            txtPadre.Enabled = true;
            txtCelularP.Enabled = true;
            txtMadre.Enabled = true;
            txtCelularM.Enabled = true;
            txtAfiliacion.Enabled = true;
            txtServicioM.Visible = false;

            btnEliminar.Visible = false;
            btnSave.Visible = true;

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            Confirmacion_Alumno confirmacion = new Confirmacion_Alumno(int.Parse(lblIdAlumno.Text));
            confirmacion.main_ = this.main_;
            confirmacion.ShowDialog();
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbServivioM.Text == "Otro...")
            {

                EditAlumno(int.Parse(lblIdAlumno.Text), txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, int.Parse(txtEdad.Text), dateFechaN.Value.Date.ToString("d"), txtDireccion.Text, txtServicioM.Text, txtPadre.Text, txtCelularP.Text, txtMadre.Text, txtCelularM.Text);
                main_.Dates();
                this.Close();
            }
            else
            {
                EditAlumno(int.Parse(lblIdAlumno.Text), txtNombre.Text, txtApellidoP.Text, txtApellidoM.Text, int.Parse(txtEdad.Text), dateFechaN.Value.Date.ToString("d"), txtDireccion.Text, cmbServivioM.Text, txtPadre.Text, txtCelularP.Text, txtMadre.Text, txtCelularM.Text);
                main_.Dates();
                this.Close();
            }
        }

        private void CmbServivioM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex == 2)
            {
                txtServicioM.Visible = true;
                txtServicioM.Enabled = true;
            }
            else
            {
                txtServicioM.Visible = false;
            }
        }

        private void BtnPagos_Click(object sender, EventArgs e)
        {
            Pagos_Alumnos pagos = new Pagos_Alumnos();
            pagos.idAlumno = idAlumno;
            pagos.main_ = this;
            pagos.cargarDatos();
            pagos.Show();
        }

        public void CargarTabla()
        {
            MySqlCommand query = new MySqlCommand("SELECT id_Pago, Abono, No_Pago, Total, FechaPago From concepto_pago WHERE id_Alumno=@idAlumno", connection);
            try
            {
                query.Parameters.AddWithValue("idAlumno", idAlumno);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                dGridKardex.DataSource = source;
                adapter.Update(table);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
