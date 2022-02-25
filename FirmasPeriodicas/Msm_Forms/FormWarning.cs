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
    public partial class FormWarning : Form
    {
        public FormWarning()
        {
            InitializeComponent();
            this.TopMost = true;

        }
        public void CargarDatos()
        {
            try
            {
                lbl_nombrep.Text = Cls_Libreria.NombrePerson;
                lbl_Warning.Text = Cls_Libreria.Mensajesistema;
                
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

        private void rjButton2_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }

        private void FormWarning_Load(object sender, EventArgs e)
        {
            rjButton2.Focus();   
        }
    }
}
