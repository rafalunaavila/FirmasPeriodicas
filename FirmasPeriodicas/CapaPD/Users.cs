using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirmasPeriodicas.Helper;
using System.Data;

namespace FirmasPeriodicas.CapaPD
{
    public class Users
    {
        private DBUsuario objetoCD = new DBUsuario();


        public bool Verificar_Acceso(string Usuario, string Contraseña)
        {
            DBUsuario obj = new DBUsuario();
            return obj.BD_VerificarAcceso(Usuario, Contraseña);
        }

        public DataTable mostarUsers(string id)
        {
        
            DBUsuario obj = new DBUsuario();
            return obj.Motrar(id);
        }
       
        public DataTable mostrarUsersPH()
        {
            DBUsuario obj = new DBUsuario();
            return obj.mostrarPH();
        }
        public void InsertarPRod(object fingerprint, string idperosna)
        {
            objetoCD.Insertar(fingerprint, idperosna);
        }

        public void InsertarRegistroPP(DateTime fechaFirma, string registroidHuella, string personaIdPersona)
        {
            objetoCD.insertarPresentacion(fechaFirma, registroidHuella, personaIdPersona);
        }
        public bool checarRegistroAsistecia(string id)
        {
            DBUsuario obj = new DBUsuario();
            return obj.checarRegistroAsistecia(id);
        }
        public bool checarRegistroPersona(string id)
        {
            DBUsuario obj = new DBUsuario();
            return obj.checarRegistroPersona(id);
        }

        public DataTable verpersonasHuellla()
        {
            DBUsuario obj = new DBUsuario();
            return obj.verpersonasHuellla();
        }       

        public DataTable RN_Buscar_personal_xvalor(String valor)
        {
            DBUsuario obj = new DBUsuario();
           return obj.DB_Buscar_personal_xvalor(valor);

        }
        public DataTable RN_Buscar_personal_xvalor_edicion(String valor)
        {
            DBUsuario obj = new DBUsuario();
            return obj.DB_Buscar_personal_xvalor_edicion(valor);

        }

        public void RN_Registrar_Huella_Personal_Edicion(string idper, object finguer)
        {
            DBUsuario obj = new DBUsuario();
            obj.BD_Registrar_Huella_Personal_Edicion(idper, finguer);
        }

    }

}
