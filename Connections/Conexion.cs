using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Colegio_Panamericana.Connections
{
    class Conexion
    {
        public static MySqlConnection connection()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "bdColegioPanamericana";
            MySqlConnection connection = new MySqlConnection(builder.ToString());

            return connection;
        }
    }
}
