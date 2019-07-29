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
using Excel = Microsoft.Office.Interop.Excel;
using Colegio_Panamericana.Connections;
using Colegio_Panamericana.Modelos;

namespace Colegio_Panamericana
{
    public partial class Inicio_Usuario : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Usuario()
        {
            InitializeComponent();
            connection.Open();
            Dates();
        }

        public void Dates()
        {
            MySqlCommand dates = new MySqlCommand("SELECT id_Alumno, Nombre, Apellido_Paterno, Apellido_Materno, Edad, Nombre_Madre, Celular_Madre FROM Alumno WHERE Status='Activo' AND Año=@Año", connection);
            dates.Parameters.AddWithValue("Año", DateTime.Now.ToString("yyyy"));
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(dates);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                dGridAlumno.DataSource = source;
                adapter.Update(table);
            }
            catch(Exception)
            {

            }
        }

        public void Find(DataGridView data, string name)
        {
            MySqlCommand find = new MySqlCommand("SELECT id_Alumno, Nombre, Apellido_Paterno, Apellido_Materno, Edad, Nombre_Madre, Celular_Madre FROM Alumno WHERE Nombre like '%" + name + "%' AND Status='Activo' AND Año=@Año", connection);
            find.Parameters.AddWithValue("Año", DateTime.Now.ToString("yyyy"));
            try
            {
                MySqlDataAdapter adapter = new MySqlDataAdapter(find);
                DataTable table = new DataTable();
                adapter.Fill(table);
                BindingSource source = new BindingSource();
                source.DataSource = table;
                data.DataSource = source;
                adapter.Update(table);
            }
            catch (Exception)
            {

            }
        }
        public void SelectCell()
        {
            try
            {
                int id = int.Parse(dGridAlumno.SelectedCells[0].Value.ToString());

                MySqlCommand cmd = new MySqlCommand("SELECT id_Alumno, Nombre, Apellido_Paterno, Apellido_Materno, Edad, Fecha_Nacimiento, Direccion, Servicio_Medico,  Nombre_Padre, Celular_Padre, Nombre_Madre, Celular_Madre FROM Alumno WHERE id_Alumno = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                Perfil_Alumno perfil = new Perfil_Alumno(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), int.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(), table.Rows[0][6].ToString(), table.Rows[0][7].ToString(), table.Rows[0][8].ToString(), table.Rows[0][9].ToString(), table.Rows[0][10].ToString(), table.Rows[0][11].ToString());
                perfil.main_ = this;perfil.ShowDialog();
            }
            catch (Exception)
            {

            }
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            Registro_Alumnos registro = new Registro_Alumnos();
            registro.idFamiliar = Guid.Empty;
            registro.main_ = this;
            registro.ShowDialog();
        }

        

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Find(dGridAlumno, txtSearch.Text);
        }

        private void DGridAlumno_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCell();
        }

        public List<Alumno> ObtenerAlumnos()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id_Alumno, Nombre, Apellido_Paterno, Apellido_Materno, Edad,Nombre_Padre, Celular_Padre, Nombre_Madre, Celular_Madre FROM Alumno WHERE Status=@Activo", connection);
                cmd.Parameters.AddWithValue("Activo", "Activo");
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Alumno> result_ = new List<Alumno>();
                foreach (DataRow row in table.Rows)
                {
                    Alumno alumno = new Alumno();
                    alumno.id_Alumno = int.Parse(row[0].ToString());
                    alumno.Nombre = row[1].ToString();
                    alumno.Apellido_Paterno = row[2].ToString();
                    alumno.Apellido_Materno = row[3].ToString();
                    alumno.Edad = int.Parse(row[4].ToString());
                    alumno.Papa = row[5].ToString();
                    alumno.CelPapa = row[6].ToString();
                    alumno.Mama = row[7].ToString();
                    alumno.CelMama = row[8].ToString();
                    result_.Add(alumno);
                }
                return result_;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public List<string> ObtenerConceptos(int [] conceptos)
        {
            List<string> lista = new List<string>();
            for (int i = 0; i < conceptos.Length; i++) { 
                MySqlCommand cmd = new MySqlCommand("SELECT Descripcion FROM concepto_cobro WHERE id_Cobro=@id", connection);
                cmd.Parameters.AddWithValue("id", conceptos[i]);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                lista.Add( table.Rows[0][0].ToString());
            }
            return lista;
        }

        public string ObtenerHorario(int id)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Entrada, Salida FROM horario WHERE id_Horario=@id", connection);
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                return table.Rows[0][0].ToString() + " a " + table.Rows[0][1].ToString();
            }
            catch (Exception e) {
                MessageBox.Show(e.Message);
                return "";
            }
        }

        public List<Kardex> ObtenerKardex() {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT IdKardex, ListaConceptos,id_Horario,id_Alumno FROM Kardex", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<Kardex> result_ = new List<Kardex>();
                foreach (DataRow row in table.Rows)
                {
                    Kardex kardex = new Kardex();
                    kardex.IdKardex= int.Parse(row[0].ToString());
                    List<string> lista = ObtenerConceptos(row[1].ToString().Split(',').ToList().ConvertAll(int.Parse).ToArray());
                    kardex.Desayuno = lista.Contains("Desayuno");
                    kardex.Natacion = lista.Contains("Natacion");
                    kardex.Horario = ObtenerHorario(int.Parse(row[2].ToString()));
                    kardex.Comida = !kardex.Horario.Contains("1:30");
                    kardex.idAlumno = int.Parse(row[3].ToString());
                    result_.Add(kardex);
                }
                return result_;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        public List<ConceptoPago> ObtenerConceptosPago() {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT id_Pago, Abono, No_Pago, Total, id_Alumno  FROM concepto_pago", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                List<ConceptoPago> result_ = new List<ConceptoPago>();
                foreach (DataRow row in table.Rows)
                {
                    ConceptoPago ConceptoPago_ = new ConceptoPago();
                    ConceptoPago_.idConcepto = int.Parse(row[0].ToString());
                    ConceptoPago_.Abono = double.Parse(row[1].ToString());
                    ConceptoPago_.No_Pago = int.Parse(row[2].ToString());
                    ConceptoPago_.Total = double.Parse(row[3].ToString());
                    ConceptoPago_.idAlumno = int.Parse(row[4].ToString());
                    result_.Add(ConceptoPago_);
                }
                return result_;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }

        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            string bloque="";
            int a=0;
            try
            {
                btnReporte.Enabled = false;


                var excelApp = new Excel.Application();

                excelApp.Interactive = false;
                Excel._Worksheet workSheet = (Excel.Worksheet)excelApp.ActiveSheet;
                List<Alumno> alumnos = ObtenerAlumnos();
                List<Kardex> kardex = ObtenerKardex();
                List<ConceptoPago> conceptosPago = ObtenerConceptosPago();
                workSheet.Cells[1, "A"] = "No.";
                workSheet.Cells[1, "B"] = "Nombre";
                workSheet.Cells[1, "C"] = "Horario";
                workSheet.Cells[1, "D"] = "Natacion";
                workSheet.Cells[1, "E"] = "Desayuno";
                workSheet.Cells[1, "F"] = "Comida";
                workSheet.Cells[1, "G"] = "Edad";
                workSheet.Cells[1, "H"] = "Mama";
                workSheet.Cells[1, "I"] = "Cel";
                workSheet.Cells[1, "J"] = "Papa";
                workSheet.Cells[1, "K"] = "Cel";
                workSheet.Cells[1, "L"] = "Costo";
                workSheet.Cells[1, "M"] = "Pago 1";
                workSheet.Cells[1, "N"] = "Pago 2";
                workSheet.Cells[1, "O"] = "Pago 3";
                bloque = 1+" : ";
                for (int i = 0; i < alumnos.Count; i++)
                {
                    a = i;
                    workSheet.Cells[i + 2, "A"] = alumnos[i].id_Alumno.ToString();
                    workSheet.Cells[i + 2, "B"] = alumnos[i].Nombre + " " + alumnos[i].Apellido_Paterno + " " + alumnos[i].Apellido_Materno;
                    workSheet.Cells[i + 2, "C"] = kardex.Where(k => k.idAlumno == alumnos[i].id_Alumno).First().Horario;
                    workSheet.Cells[i + 2, "D"] = kardex.Where(k => k.idAlumno == alumnos[i].id_Alumno).First().Natacion ? "SI" : "NO";
                    workSheet.Cells[i + 2, "E"] = kardex.Where(k => k.idAlumno == alumnos[i].id_Alumno).First().Desayuno ? "SI" : "NO";
                    workSheet.Cells[i + 2, "F"] = kardex.Where(k => k.idAlumno == alumnos[i].id_Alumno).First().Comida ? "SI" : "NO";
                    workSheet.Cells[i + 2, "G"] = alumnos[i].Edad.ToString();
                    workSheet.Cells[i + 2, "H"] = alumnos[i].Mama;
                    workSheet.Cells[i + 2, "I"] = alumnos[i].CelMama;
                    workSheet.Cells[i + 2, "J"] = alumnos[i].Papa;
                    workSheet.Cells[i + 2, "K"] = alumnos[i].CelPapa;
                    workSheet.Cells[i + 2, "L"] = conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).First().Total;

                    switch (conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList().Count) {
                        case 1:
                            {
                                workSheet.Cells[i + 2, "M"] = 
                                                conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[0].Abono.ToString();
                            }
                            break;
                        case 2: {
                                workSheet.Cells[i + 2, "M"] = 
                                                conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[1].Abono.ToString();
                                workSheet.Cells[i + 2, "N"] =
                                    conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[0].Abono.ToString();
                            } break;
         
                    }

                    if(conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList().Count >= 3) { 

                    workSheet.Cells[i + 2, "M"] =
                                                conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[2].Abono.ToString();
                        workSheet.Cells[i + 2, "N"] =
                                                    conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[1].Abono.ToString();
                    workSheet.Cells[i + 2, "O"] = 
                                                conceptosPago.Where(c => c.idAlumno == alumnos[i].id_Alumno).OrderByDescending(c => c.No_Pago).ToList()[0].Abono.ToString();
                    }

                    

                }
                excelApp.Visible = true;
                excelApp.Interactive = true;
                btnReporte.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + bloque + a);
                btnReporte.Enabled = true;
            }
        }


    }
}
