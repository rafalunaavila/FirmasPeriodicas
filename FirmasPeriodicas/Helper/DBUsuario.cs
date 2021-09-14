using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using FirmasPeriodicas.Helper;
using System.Data;
using System.Windows.Forms;

namespace FirmasPeriodicas.Helper
{
    public class DBUsuario
    {
        private DBHelper Conexion = new DBHelper();
        MySqlConnection Connection = new MySqlConnection("server=10.6.60.190;port=3306;user=administrador;password=ssp.2020;database=penas2");
        //MySqlConnection Connection = new MySqlConnection("server=localhost;port=3306;user=root;password=;database=penas2");
        MySqlDataReader dr;

        DataTable table = new DataTable();
        MySqlCommand cmd = new MySqlCommand();


        public bool BD_VerificarAcceso(string usuario, string pass ) {
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spLogin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var_user", usuario);
            cmd.Parameters.AddWithValue("@var_pass", pass);
            cmd.ExecuteNonQuery();
            var x = cmd.ExecuteReader();
            bool devolverValor = false;
            while (x.Read())
            {
                var y = Convert.ToInt32(x[0]);
                try
                {
                    Conexion.Conectar();
                    if (y > 0)
                    {
                        devolverValor = true;
                    }
                    else
                    {
                        devolverValor = false;
                    }


                }
                catch (Exception ex)
                {
                    if (Conexion.Conectar().State == ConnectionState.Open)
                        Conexion.CerrarConexion();
                    MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia dedl sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
            cmd = null;
            Conexion.CerrarConexion();
            return devolverValor;

        }



        public DataTable mostrarPH()
        {
            MySqlCommand command = new MySqlCommand("spMostarPH", Connection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable datat = new DataTable();
            da.Fill(datat);
            da = null;
            return datat;
        }

        public DataTable Motrar(string id)
        {
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spVlidarRegistro";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var_registroidHuellaa", id);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            table.Load(dr);
            Conexion.CerrarConexion();
            return table;
        }


        //SE LLENA LA EL COMBOBOX CON LA LISTA DE PERSONAS REGISTRADAS EN LA DB
        public void llenarCombo(ComboBox combo)
        {
            MySqlCommand command = new MySqlCommand("spPersonas", Connection);
            command.CommandType = CommandType.StoredProcedure;
            MySqlDataAdapter da = new MySqlDataAdapter(command);
            DataTable datat = new DataTable();
            da.Fill(datat);
            combo.ValueMember = "idPersona";    
            combo.DisplayMember = "NombreCompleto";
            combo.DataSource = datat;
            Connection.Close();
        }

     //REGISTRA UNA NUEVA HUELLA CON EL IDPERSONA 
        public void Insertar(object fingerprint, string idPerona)
        {
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spInsert";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fingerprint", fingerprint);
            cmd.Parameters.AddWithValue("@idpersona", idPerona);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Conexion.CerrarConexion();
        }
        public void Login(string username, string pass)
        {
           
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "SpLogin";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@pass", pass);
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        //INSERTA UNA PRESENTACIÓN PERIODICA CON FECHA Y REGISTRO DE HUELLA
        public void insertarPresentacion(object fechaFirma, string registroidHuella, string personaIdPersona)
        {
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spInsertRH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fechaFirma", fechaFirma);
            cmd.Parameters.AddWithValue("@registroidHuella", registroidHuella);
            cmd.Parameters.AddWithValue("@idpersona", personaIdPersona);
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            Conexion.CerrarConexion();
        }

        //VERIFICA SI LA PERSONA YA MARCO LA ASISTENCIA EL DIA DE  HOY
        public bool checarRegistroAsistecia(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spVlidarRegistroPresentacionP";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var_registroidHuellaa", id);
            cmd.ExecuteNonQuery();
            var x = cmd.ExecuteReader();
            bool devolverValor = false;
            while (x.Read())
            {
                var y = Convert.ToInt32(x[0]);
                try
                {
                    Conexion.Conectar();
                    if (y > 0)
                    {
                        devolverValor = true;
                    }
                    else
                    {
                        devolverValor = false;
                    }
                  
                  

                }
                catch (Exception ex)
                {
                    if (Conexion.Conectar().State == ConnectionState.Open)
                        Conexion.CerrarConexion();  
                    MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia dedl sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }

            }
            cmd.Parameters.Clear();
            cmd.Dispose();
            cmd = null;
            Conexion.CerrarConexion();
            return devolverValor;
        }

        //VERIFICAR SI LA PERSONA YA SE REGISTRO EN LA DB
        public bool checarRegistroPersona(string id)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = Conexion.Conectar();
            cmd.CommandText = "spValidarRegistroPersona";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@var_personaIdPersona", id);
            cmd.ExecuteNonQuery();
            var x = cmd.ExecuteReader();
            bool devolverValor = false;
            while (x.Read())
            {
                var y = Convert.ToInt32(x[0]);
                try
                {
                    Conexion.Conectar();
                    if (y > 0)
                    {
                        devolverValor = true;
                    }
                    else
                    {
                          devolverValor = false;
                    }
               

                }
                catch (Exception ex)
                {
                    if (Conexion.Conectar().State == ConnectionState.Open)
                        Conexion.CerrarConexion();
                    MessageBox.Show("Algo malo paso: " + ex.Message, "Advertencia dedl sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                }
            }
            cmd.Parameters.Clear();
            cmd.Dispose();
            cmd = null;
            Conexion.CerrarConexion();
            return devolverValor;
       
        }

        //VER TODAS LAS PEROSNAS CON HUELLA EN LA BD

        public DataTable verpersonasHuellla()
        {
            try
            {
                Conexion.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("spEdicionView", Conexion.Conectar());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable datat = new DataTable();
                da.Fill(datat);
                da = null;
                return datat;

            }
            catch (Exception ex)
            {

               if(Conexion.Conectar().State == ConnectionState.Open)
                {
                    Conexion.CerrarConexion();
                    throw new Exception("Error " + ex.Message, ex);
                }
            }return null;
        }

        public static bool huella = false;
        public DataTable DB_Buscar_personal_xvalor(String valor)
        {
            Conexion.Conectar();
            try
            {
                Conexion.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("spBuscarPersonasHuella", Conexion.Conectar());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@var_NombreCompleto", valor);
                DataTable dato = new DataTable();
                da.Fill(dato);
                da = null;
                return dato;
            }
            catch (Exception ex)
            {
 
                if (Conexion.Conectar().State == ConnectionState.Open)
                {
                    Conexion.CerrarConexion();
                }
                MessageBox.Show("Error al Ejectar el SP;" + ex.Message, "Advertenca de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }
        #region Selecionar pesona para editar
        public DataTable DB_Buscar_personal_xvalor_edicion(String valor)
        {
            Conexion.Conectar();
            try
            {
                Conexion.Conectar();
                MySqlDataAdapter da = new MySqlDataAdapter("spBuscarPersonasHuellaEdicion", Conexion.Conectar());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@var_idregistroHuella", valor);
                DataTable dato = new DataTable();
                da.Fill(dato);
                da = null;
                return dato;
            }
            catch (Exception ex)
            {

                if (Conexion.Conectar().State == ConnectionState.Open)
                {
                    Conexion.CerrarConexion();
                }
                MessageBox.Show("Error al Ejectar el SP;" + ex.Message, "Advertenca de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return null;
        }
        #endregion

       
        public void BD_Registrar_Huella_Personal_Edicion(string idper, object finguer)
        {
            Conexion.Conectar();
            MySqlCommand da = new MySqlCommand("spEdicionHuella", Conexion.Conectar());

            try
            {
                da.CommandTimeout = 20;
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@var_idRegistro", idper);
                da.Parameters.AddWithValue("@var_Fingerprint", finguer);

                Conexion.Conectar();
                da.ExecuteNonQuery();
                Conexion.CerrarConexion();
                huella = true;
            }
            catch (Exception ex)
            {
                huella = false;
                if (Conexion.Conectar().State == ConnectionState.Open)
                {
                    Conexion.CerrarConexion();
                }
                MessageBox.Show("Error al Ejectar el SP;" + ex.Message, "Advertenca de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        } public void BD_Registrar_Huella_Supervisor(string user, string pass, object finguer)
        {
            Conexion.Conectar();
            MySqlCommand da = new MySqlCommand("spRegistroUser", Conexion.Conectar());

            try
            {
                da.CommandTimeout = 20;
                da.CommandType = CommandType.StoredProcedure;
                da.Parameters.AddWithValue("@usernameFinger", user);
                da.Parameters.AddWithValue("@pass", pass);
                da.Parameters.AddWithValue("@Fingerprint", finguer);

                Conexion.Conectar();
                da.ExecuteNonQuery();
                Conexion.CerrarConexion();
                huella = true;
            }
            catch (Exception ex)
            {
                huella = false;
                if (Conexion.Conectar().State == ConnectionState.Open)
                {
                    Conexion.CerrarConexion();
                }
                MessageBox.Show("Error al Ejectar el SP;" + ex.Message, "Advertenca de seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }


        public DataSet CarrgarfotoPersona(object picture)
        {
            Conexion.Conectar();
            MySqlDataAdapter da = new MySqlDataAdapter("spBuscarFotoPersona", Conexion.Conectar());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet dataSet = new DataSet();
            da.Fill(dataSet);
            return dataSet;
        }

    }
}
