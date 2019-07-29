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
        public Guid idFamiliar;
        public Inicio_Usuario main_;
        public Registro_Alumnos()
        {
            InitializeComponent();
            lblAño.Text = DateTime.Now.ToString("yyyy");
            connection.Open();
            CargarHorarios();
            if (!idFamiliar.Equals(Guid.Empty))
            {
                lblFamiliares.Visible = false;
                asociarAOtro.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                txtApellidoMAsociado.Visible = false;
                txtApellidoPAsociado.Visible = false;
                txtNombreAsociado.Visible = false;
            }
        }

        public void CargarHorarios(){
            MySqlCommand getHorarios= new MySqlCommand("SELECT id_Horario, Entrada, Salida, Descripcion FROM horario", connection);
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(getHorarios);
                DataTable table = new DataTable();
                adapter.Fill(table);
                for(int i = 0; i<table.Rows.Count;i++) {
                    string text = table.Rows[i][1].ToString() + " a " + table.Rows[i][2].ToString();
                    cmbHorario.Items.Add(text);
                }
            }
            catch {
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (crearAlumno()) {
                main_.Dates();
                this.Close();
            }
        }
        public bool crearKardex(int idAlumno) {
            try { 
            MySqlCommand query = new MySqlCommand("SELECT * FROM horario", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter(query);
            DataTable table = new DataTable();
            adapter.Fill(table);
            int rows = table.Rows.Count;
            int idHorario=1;
            string texto = cmbHorario.SelectedItem.ToString();
            for(int i = 0; i < rows; i++)
            {
                if(texto.Contains(table.Rows[i][1].ToString()) && texto.Contains(table.Rows[i][2].ToString()))
                {
                    idHorario = int.Parse( table.Rows[i][0].ToString() );
                }
            }

            string lista_conceptos = "1";
            query = new MySqlCommand("SELECT id_Cobro FROM concepto_cobro where Descripcion=@nombre", connection);
            if (chckNatacion.Checked) {
                query.Parameters.Clear();
                query.Parameters.AddWithValue("nombre", "Natacion");
                adapter = new MySqlDataAdapter(query);
                table = new DataTable();
                adapter.Fill(table);
                lista_conceptos += "," + table.Rows[0][0].ToString();
            }

            if (chckDesayuno.Checked)
            {
                query.Parameters.Clear();
                query.Parameters.AddWithValue("nombre", "Desayuno");
                adapter = new MySqlDataAdapter(query);
                table = new DataTable();
                adapter.Fill(table);
                lista_conceptos += "," + table.Rows[0][0].ToString();
            }

            if (cmbServivioM.SelectedItem.ToString() == "ISSSTE")
            {
                query.Parameters.Clear();
                query.Parameters.AddWithValue("nombre", "ISSSTE");
                adapter = new MySqlDataAdapter(query);
                table = new DataTable();
                adapter.Fill(table);
                lista_conceptos += "," + table.Rows[0][0].ToString();
            }

            query = new MySqlCommand("INSERT INTO kardex (`ListaConceptos`, `id_Horario`, `id_Alumno`) VALUES ( @lista, @idHorario, @id_Alumno);", connection);
            query.Parameters.Clear();
            query.Parameters.AddWithValue("lista", lista_conceptos);
            query.Parameters.AddWithValue("idHorario", idHorario);
            query.Parameters.AddWithValue("id_Alumno", idAlumno);
            query.ExecuteNonQuery();

                return true;
            }catch(Exception )
            {
                return false;
            }
        }

        public bool crearAlumno()
        {
            if (checarCampos())
            {
                if (!AlumnoYaInscrito())
                {
                    if (asociarAOtro.Checked)
                    {
                        MySqlCommand validar = new MySqlCommand("SELECT id_Alumno, No_Familiar FROM alumno WHERE Nombre=@NAsociado AND Apellido_Paterno=@APAsociado AND Apellido_Materno=@AMAsociado", connection);
                        validar.Parameters.AddWithValue("NAsociado", txtNombreAsociado.Text);
                        validar.Parameters.AddWithValue("APAsociado", txtApellidoPAsociado.Text);
                        validar.Parameters.AddWithValue("AMAsociado", txtApellidoMAsociado.Text);
                        MySqlDataAdapter adapter = new MySqlDataAdapter(validar);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        if (table.Rows.Count == 1)
                        {
                            idFamiliar = Guid.Parse(table.Rows[0][1].ToString());
                        }
                    }
                    else if (idFamiliar.Equals(Guid.Empty) && !asociarAOtro.Checked)
                    {
                        idFamiliar = Guid.NewGuid();
                    }
                    int idAlumno = crearRegistroAlumno();
                    if (idAlumno > 0)
                    {
                        if (crearKardex(idAlumno)) {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("Se ha producido un error y los datos no han podido ser guardado, contactar con el administrador del sistema", "Error al capturar datos de alumno");
                            return false;
                        }

                           
                    }else
                    {
                        MessageBox.Show("Se ha producido un error y los datos no han podido ser guardado, contactar con el administrador del sistema", "Error al capturar datos de alumno");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("El alumno ya esta inscrito o sea producido un error en la base de datos", "Error al capturar datos de alumno");
                    return false;

                }
            }
            else
            {
                MessageBox.Show("Algun campo esta vacio o es incorrecto", "Error al capturar datos de alumno");
            return false;
            }
        }

        /// <summary>
        /// verificar si los campos minimos necesarios para la captura de un alumno estan capturados
        /// </summary>
        /// <returns>false, si uno de los campos requeridos esta invalido, true si todo esta en orden</returns>
        public bool checarCampos()
        {
            bool result = true;
            if (asociarAOtro.Checked){
                result = txtNombreAsociado.Text != "" ? result : false;
                result = txtApellidoPAsociado.Text != "" ? result : false;
                result = txtApellidoMAsociado.Text != "" ? result : false;
            }
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
            }
            catch {
                result = false;
            }
            return result;
        }
        /// <summary>
        /// crea con los datos del formulario un alumno nuevo
        /// </summary>
        /// <returns>false, si no pudo crearse el usuario, true si el usuario pudo ser creado exitosamente</returns>
        public int crearRegistroAlumno() {
            try
            {
                MySqlCommand setAlumno = new MySqlCommand(
                    "INSERT INTO `bdcolegiopanamericana`.`alumno` " +
                            "(`Nombre`, `Apellido_Paterno`, `Apellido_Materno`, `Edad`, `Fecha_Nacimiento`, `Direccion`, `Servicio_Medico`, `No_Afiliacion`, `Nombre_Padre`, `Celular_Padre`, `Nombre_Madre`, `Celular_Madre`, `No_Familiar`, `Año`, `Status`) " +
                    "VALUES(  @Nombre, @Apellido_Paterno,@Apellido_Materno, @Edad, @Fecha_Nacimiento, @Direccion, @Servicio_Medico, @No_Afiliacion, @Nombre_Padre, @Celular_Padre,@Nombre_Madre,@Celular_Madre, @No_Familiar, @Año, @Status);"
                , connection);
                setAlumno.Parameters.AddWithValue("Nombre", txtNombre.Text);
                setAlumno.Parameters.AddWithValue("Apellido_Paterno", txtApellidoP.Text);
                setAlumno.Parameters.AddWithValue("Apellido_Materno", txtApellidoM.Text);
                setAlumno.Parameters.AddWithValue("Edad", txtEdad.Text);
                setAlumno.Parameters.AddWithValue("Fecha_Nacimiento", dateFechaN.Value.Date);
                setAlumno.Parameters.AddWithValue("Direccion", txtDireccion.Text);
                setAlumno.Parameters.AddWithValue("Servicio_Medico", cmbServivioM.SelectedItem.ToString() != "Otro..." ? cmbServivioM.SelectedItem.ToString() : lblServicioM.Text );
                setAlumno.Parameters.AddWithValue("No_Afiliacion", txtAfiliacion.Text);
                setAlumno.Parameters.AddWithValue("Nombre_Padre", txtPadre.Text);
                setAlumno.Parameters.AddWithValue("Celular_Padre", txtCelularP.Text);
                setAlumno.Parameters.AddWithValue("Nombre_Madre", txtMadre.Text);
                setAlumno.Parameters.AddWithValue("Celular_Madre", txtCelularM.Text);
                setAlumno.Parameters.AddWithValue("No_Familiar", idFamiliar.ToString());
                setAlumno.Parameters.AddWithValue("Año", DateTime.Now.Year);
                setAlumno.Parameters.AddWithValue("Status", "Activo");
                setAlumno.ExecuteNonQuery();
                MySqlCommand query = new MySqlCommand("SELECT id_Alumno FROM alumno WHERE Nombre=@Nombre AND Apellido_Paterno=@APaterno AND Apellido_Materno=@AMaterno AND Año=@Año", connection);
                query.Parameters.AddWithValue("Nombre", txtNombre.Text);
                query.Parameters.AddWithValue("APaterno", txtApellidoP.Text);
                query.Parameters.AddWithValue("AMaterno", txtApellidoM.Text);
                query.Parameters.AddWithValue("Año", DateTime.Now.Year);
                MySqlDataAdapter adapter = new MySqlDataAdapter(query);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    return int.Parse(table.Rows[0][0].ToString());
                }
            }
            catch(Exception )
            {
                return -1;
            }
            return -1;
        }
        /// <summary>
        /// evalua si el alumno ya existe
        /// </summary>
        /// <returns>false, si el Alumno no existe, true si el alumno si existe o algo salio mal , lo que detiene el programa</returns>
        public bool AlumnoYaInscrito() {
            try {
                MySqlCommand validar = new MySqlCommand("SELECT id_Alumno, No_Familiar FROM alumno WHERE Nombre=@Nombre AND Apellido_Paterno=@APaterno AND Apellido_Materno=@AMaterno AND Año=@date", connection);
                validar.Parameters.AddWithValue("Nombre", txtNombre.Text);
                validar.Parameters.AddWithValue("APaterno", txtApellidoP.Text);
                validar.Parameters.AddWithValue("AMaterno", txtApellidoM.Text);
                validar.Parameters.AddWithValue("date", DateTime.Now.Year);
                MySqlDataAdapter adapter = new MySqlDataAdapter(validar);
                DataTable table = new DataTable();
                adapter.Fill(table);
                if (table.Rows.Count == 1)
                {
                    return true;
                }else if(table.Rows.Count == 0)
                {
                    return false;
                }
                else { return true; }
            } catch {
                return true;
            }
        }
        /// <summary>
        /// obliga a que la edad solo pueda ser numerico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        private void GuardarYAgregar_Click(object sender, EventArgs e)
        {
            if (crearAlumno())
            {
                this.Hide();
                Registro_Alumnos registro = new Registro_Alumnos();
                registro.idFamiliar = idFamiliar;
                registro.main_ = this.main_;
                registro.ShowDialog();
                registro.Closed += (s, args) => this.Close();
            }
        }

        private void AsociarAOtro_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            label1.Visible = check.Checked;
            label2.Visible = check.Checked;
            label3.Visible = check.Checked;
            txtApellidoMAsociado.Visible = check.Checked;
            txtApellidoPAsociado.Visible = check.Checked;
            txtNombreAsociado.Visible = check.Checked;
        }

        private void CmbServivioM_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            if (combo.SelectedIndex == 2) {
                txtServicioM.Visible = true;
            }
            else
            {
                txtServicioM.Visible = false;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
                main_.Dates();
                this.Close();
        }

        private void CmbHorario_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox checkBox = (ComboBox)sender;
            if(checkBox.SelectedIndex > 0)
            {
                chckComida.Checked = true;
                chckNatacion.Checked = true;
                chckNatacion.Enabled = false;
            }
            else
            {
                chckComida.Checked = false;
                chckNatacion.Enabled = true;
            }
        }
    }
}
