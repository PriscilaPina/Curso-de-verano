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
    public partial class Inicio_Administrador : Form
    {
        MySqlConnection connection = Conexion.connection();
        public Inicio_Administrador()
        {
            InitializeComponent();
            connection.Open();
            Dates(dGridEmpleado);
        }

        public void Recovery(string newPass, string conPass, string user)
        {
            if (newPass == conPass)
            {
                MySqlCommand recoveryPassword = new MySqlCommand("UPDATE Empleado SET Contraseña=@Contraseña WHERE Usuario=@Usuario",connection);
                recoveryPassword.Parameters.AddWithValue("Contraseña", newPass);
                recoveryPassword.Parameters.AddWithValue("Usuario", user);
                recoveryPassword.ExecuteNonQuery();
                MessageBox.Show("La contraseña fue cambiada exitosamente");
            }
            MessageBox.Show("Las contraseñas no coinciden");

        }

        public void CheckUser(string user)
        {
            try
            {
                MySqlCommand validar = new MySqlCommand("SELECT Usuario FROM Empleado WHERE Usuario=@Usuario" , connection);
                validar.Parameters.AddWithValue("Usuario", user);
                MySqlDataAdapter adapter = new MySqlDataAdapter(validar);
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    if (table.Rows[0][0].ToString() == txtUsuario.Text)
                    {
                        Recovery(this.txtNewPass.Text, this.txtConPass.Text, user);
                    }
                    MessageBox.Show("Este usuario no existe");
                }
            }
            catch (Exception)
            {
            }
            connection.Close();
        }
        public void Dates(DataGridView data)
        {
            MySqlCommand dates = new MySqlCommand("SELECT id_Empleado, Nombre, Apellido_Paterno, Apellido_Materno, Usuario, Tipo_Cuenta FROM Empleado", connection);
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
            catch (Exception)
            {

            }
        }

        public void Find(DataGridView data, string name)
        {
            MySqlCommand find = new MySqlCommand("SELECT id_Empleado, Nombre, Apellido_Paterno, Apellido_Materno, Usuario, Tipo_Cuenta FROM Empleado WHERE Nombre like '%" + name +"%'", connection);
            
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
                int id = int.Parse( dGridEmpleado.SelectedCells[0].Value.ToString());

                MySqlCommand cmd = new MySqlCommand("SELECT * FROM Empleado WHERE id_Empleado = @id", connection);
                cmd.Parameters.AddWithValue("id", id);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                new Perfil_Empleado(int.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(), table.Rows[0][4].ToString(), table.Rows[0][5].ToString(), table.Rows[0][6].ToString()).Show();
          
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            CheckUser(this.txtUsuario.Text);
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            new Registro_Empleado().Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Find(dGridEmpleado, txtSearch.Text);
        }

        private void DGridEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectCell();

        }
    }
}
