using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirmasPeriodicas.Helper;
using MySql.Data.MySqlClient;
using FirmasPeriodicas.Helper;
using FirmasPeriodicas.CapaPD;
using FirmasPeriodicas.Msm_Forms;


namespace FirmasPeriodicas
{
    public partial class Login : Form
    {
        Users objetoCN = new Users();
        private string idProducto = null;
        private bool Editar = false;

        public Login()
        {
            
            InitializeComponent();
            txt_pass.PasswordChar = '*';



        }
        private void Login_Load(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();

        }
     

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }


  
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool VlidarTexbox()
        {
            if (txt_user.Text.Trim().Length == 0)
            {
              
                Cls_Libreria.Mensajesistema = "Ingresa tu Usuario";
                FormWarning fw = new FormWarning();
                fw.Show();
                fw.CaragarDatos();
                txt_user.Focus();
                return false;
            }
            if (txt_pass.Text.Trim().Length == 0)
            {
             
                Cls_Libreria.Mensajesistema = "Ingresa tu Contraseña";
                FormWarning fw = new FormWarning();  
                fw.Show();
                fw.CaragarDatos();
                txt_user.Focus();
                return false;
            }
            return true;
        }


        private void AccederalSistema()
        {
            Users obj = new Users();
            DataTable table = new DataTable();
            int veces = 0;
            if (VlidarTexbox() == false) return;
            String usu, pass;
            usu = txt_user.Text.Trim();
            pass = txt_pass.Text.Trim();
            if (obj.Verificar_Acceso(usu, pass) == true)
            {
                Cls_Libreria.NombreUsuario = usu;
                this.Hide(); 
                Cls_Libreria.Mensajesistema = "Bienvenid@ al sistema " + usu;
                FormInformation fw = new FormInformation();
                fw.Show();
                fw.CaragarDatos();
                MenuPrincipal xMenuPrincipal = new MenuPrincipal();
                xMenuPrincipal.Show();

            }
            else
            {
                Cls_Libreria.Mensajesistema = "Usuario o contraseña invalidos " + usu;
                FormWarning fw = new FormWarning();
                fw.Show();
                fw.CaragarDatos();
                txt_pass.Text = "";
                txt_user.Text = "";
                txt_user.Focus();
                veces += 1;
                if (veces == 3)
                {

                    MessageBox.Show("El numero maximo de intentos fue superado", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }

        }

      

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_pass.Focus();
            }
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Login_Click(sender, e);
            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            Application.Exit();

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            AccederalSistema();
        }

        private void label13_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }
    }
}
