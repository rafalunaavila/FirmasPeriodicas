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
    public partial class FormSelect : Form
    {
        public FormSelect()
        {
            this.TopMost = true;
            InitializeComponent();
        }
        public void CaragarDatos()
        {
            try
            {
                lbl_Select.Text = Cls_Libreria.Mensajesistema;
                lbl_NombreP.Text = Cls_Libreria.NombrePerson;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema" + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            bool ok = true;
            ok = Cls_Libreria.ok;
            this.Close();
        }

        private void btn_not_Click(object sender, EventArgs e)
        {
            bool not = false;
            not = Cls_Libreria.ok;
            this.Close();
        }
    }
}
