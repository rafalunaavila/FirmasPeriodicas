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
    public partial class FormPersona : Form
    {
        public FormPersona()
        {
            InitializeComponent();
            this.TopMost = true;
        }

        public void CaragarDatos()
        {
            try
            {
                lbl_MsnNombre.Text = Cls_Libreria.NombrePerson;
                lbl_MsnP.Text = Cls_Libreria.Mensajesistema;

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

        private void rjButton3_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void FormPersona_Load(object sender, EventArgs e)
        {
            rjButton2.Focus();
        }
    }
}
