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
    public partial class Perfil_Empleado : Form
    {
        public Perfil_Empleado(int id, string name, string lastP, string lastM, string user, string pass, string type)
        {
            InitializeComponent();
            lblIdEmpleado.Text = id.ToString();
            txtNombre.Text = name;
            txtApellidoP.Text = lastP;
            txtApellidoM.Text = lastM;
            txtUser.Text = user;
            txtPass.Text = pass;
            cmbTipo.Text = type;
        }
    }
}
