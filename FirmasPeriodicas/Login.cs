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
     
   

        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
     

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            Application.Exit();
        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private bool VlidarTexbox()
        {
            if (txt_user.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingresa tu usuario", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_user.Focus();
                return false;
            }
            if (txt_pass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Ingresa tu Contrseña", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_pass.Focus();
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
                this.Hide(); 
                Filtro fil = new Filtro();
                fil.Show();
                MessageBox.Show("Bienvenido al sistema", "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                MenuPrincipal xMenuPrincipal = new MenuPrincipal();
                xMenuPrincipal.Show();
                fil.Close();

            }
            else
            {
                MessageBox.Show("Usuario o contrseña invalidos", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_pass.Text = "";
                txt_user.Text = "";
                txt_user.Focus();
                veces += 1;
                if (veces == 3)
                {
                    MessageBox.Show("El Numero Mximo De intentos fue superado", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                }
            }

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            AccederalSistema();
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
    }
}
