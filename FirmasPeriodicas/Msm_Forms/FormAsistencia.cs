using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirmasPeriodicas.CapaPD;
using FirmasPeriodicas.Helper;


namespace FirmasPeriodicas.Msm_Forms
{
    public partial class FormAsistencia : Form
    {
        public FormAsistencia()
        {
            InitializeComponent();
        }

        string xFotoRuta;
        public void CaragarDatos()
        {
            try
            {
                label3.Text = Cls_Libreria.Fecha;
                lbl_nombre.Text = Cls_Libreria.NombrePerson +" "+ Cls_Libreria.PaternoPerson +" "+ Cls_Libreria.MaternoPerson;
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
                MessageBox.Show("Error del sistema"+ ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
         
         
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {

        }

        private void rjButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            this.Close();
        }
    }
}
