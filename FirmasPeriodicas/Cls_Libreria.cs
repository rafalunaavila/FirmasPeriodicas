using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirmasPeriodicas
{
    public class Cls_Libreria
    {
        private static string id_Registro;
        private static string id_persona;
        private static string Nombre_Usuario;
        private static string Nombre_Person;
        private static string Paterno_Person;
        private static string Materno_Person;
        private static string _Foto;
        private static string Mensaje_sistema;
        private static string Mensaje_sistema1;
        private static string Mensaje_sistema2;
        private static string Mensaje_sistema3;
        private static string Comentario;
        private static bool Registro;
        private static string RegistroNo;
        private static string Vacio;
        private static string _Fecha;
        private static DateTime _FechaFechaProximoContacto;
        private static bool _ok;



        public static string idpersona { get => id_persona; set => id_persona = value; }
        public static string idregistro { get => id_Registro; set => id_Registro = value; }
        public static string NombreUsuario { get => Nombre_Usuario; set => Nombre_Usuario = value; }
        public static string NombrePerson { get => Nombre_Person; set => Nombre_Person = value; }
        public static string PaternoPerson { get => Paterno_Person; set => Paterno_Person = value; }
        public static string MaternoPerson { get => Materno_Person; set => Materno_Person = value; }
        public static string Foto { get => _Foto; set => _Foto = value; }
        public static string Mensajesistema { get => Mensaje_sistema; set => Mensaje_sistema = value; }
        public static string Mensajesistema1 { get => Mensaje_sistema1; set => Mensaje_sistema1 = value; }
        public static string Mensajesistema2 { get => Mensaje_sistema2; set => Mensaje_sistema2 = value; }
        public static string Mensajesistema3 { get => Mensaje_sistema3; set => Mensaje_sistema3 = value; }
        public static string Comentari0 { get => Comentario; set => Comentario = value; }
        public static bool Registr0 { get => Registro; set => Registro = value; }
        public static string Registro_no { get => RegistroNo; set => RegistroNo = value; }
        public static string Vacioo { get => Vacio; set => Vacio = value; }
        public static string Fecha { get => _Fecha; set => _Fecha = value; }
        public static DateTime FechaFechaProximoContacto { get => _FechaFechaProximoContacto; set => _FechaFechaProximoContacto = value; }
        public static bool ok { get => _ok; set => _ok = value; }
  


    }
}
