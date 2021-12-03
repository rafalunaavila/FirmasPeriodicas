using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;   

namespace FirmasPeriodicas.Msm_Forms
{
    public partial class FormDanger : Form
    {
        public FormDanger()
        {
            InitializeComponent();
            this.TopMost = true;
        }
        public void CaragarDatos()
        {
            try
            {
                lbl_Danger.Text = Cls_Libreria.Mensajesistema;
                lbl_Danger4.Text = Cls_Libreria.Mensajesistema1;
                lbl_Danger2.Text = Cls_Libreria.Mensajesistema2;
                lbl_Danger3.Text = Cls_Libreria.Mensajesistema3;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema" + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
