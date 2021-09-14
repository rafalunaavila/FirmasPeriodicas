using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace FirmasPeriodicas.Helper
{
    public class DBHelper
    {
       //private MySqlConnection Connection = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=penas2");
       private static MySqlConnection Connection = new MySqlConnection("server=10.6.60.190;port=3306;user=administrador;password=ssp.2020;database=penas2");

        public MySqlConnection Conectar()
        {
            if (Connection.State == ConnectionState.Closed)
                Connection.Open();
            //MessageBox.Show("Conexion exitosa");
            return Connection;
        }
  
        public MySqlConnection CerrarConexion()
        {
            if (Connection.State == ConnectionState.Open)
                Connection.Close();
            return Connection;
        }

    }

}
