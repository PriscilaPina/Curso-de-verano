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

            builder.Server = "";
            
            builder.Port = ;
            builder.UserID = "";
            builder.Password = "";
            builder.Database = "";
            MySqlConnection connection = new MySqlConnection(builder.ToString());

            return connection;
        }
    }
}
