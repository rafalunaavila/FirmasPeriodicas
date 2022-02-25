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
    public partial class FormRegistro : Form
    {
        private Timer timUpadate;
        public FormRegistro()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            try
            {
                lbl_nombre.Text = Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson;
                pictureBox1.Load(@"http://10.6.60.190/Fotos/" + Cls_Libreria.Foto);
                // MessageBox.Show("hola"+pictureBox1.Image.Width + "largoo" + pictureBox1.Image.Height);
                int ancho = pictureBox1.Image.Width;
                int largo = pictureBox1.Image.Height;
                if (ancho > largo)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema" + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea continuar con el registro de " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + "?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                Cls_Libreria.Vacioo = "";
                RegistroHuellaPersona rh = new RegistroHuellaPersona();
                this.Close();
                return;
            }
            else
            {
                this.Close();
            }

                
        }
    }
}
