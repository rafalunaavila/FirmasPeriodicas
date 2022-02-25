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
using System.Drawing.Printing;
using QRCoder;


namespace FirmasPeriodicas.Msm_Forms
{
    public partial class FormAsistencia : Form
    {
        public FormAsistencia()
        {
            InitializeComponent();
        }

        string xFotoRuta;
        public void CargarDatos()
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
        string imge = @"\logo_negro.png";
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            string Nombre = "NOMBRE: " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson;
            string coode = Nombre + " " + "FECHA: " + DateTime.Now;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(coode, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Font font = new Font("Ticketing", 10, FontStyle.Regular, GraphicsUnit.Point);
            int width = 200;
            int y = 20;
            Image img = Image.FromFile(imge);
            e.Graphics.DrawImage(img, new RectangleF(10, y += 10, 170, 50));
            e.Graphics.DrawString("FIRMA REGISTRADA EL DÍA: " + DateTime.Now.ToString("dddd, dd MMM yyyy HH:mm").ToUpper(), font, Brushes.Black, new RectangleF(0, y += 60, width, 60));
            e.Graphics.DrawString(Nombre, font, Brushes.Black, new RectangleF(0, y += 60, width, 60));
            e.Graphics.DrawString("_________________________", font, Brushes.Black, new RectangleF(0, y += 70, width, 50));
            e.Graphics.DrawString(" " + " " + " FIRMA DE SUPERVISOR", font, Brushes.Black, new RectangleF(0, y += 20, width, 50));
            e.Graphics.DrawImage(code.GetGraphic(5), new RectangleF(5, y += 20, 170, 170));
        }
        private void rjButton1_Click(object sender, EventArgs e)
        {
                printDocument1 = new PrintDocument();
                PrinterSettings ps = new PrinterSettings();
                printDocument1.PrinterSettings = ps;
                printDocument1.PrintPage += Imprimir;
                printDocument1.Print();
                this.Close();
     
        }
        private void rjButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            this.Close();
        }

        private void FormAsistencia_Load(object sender, EventArgs e)
        {

        }
    }
}
