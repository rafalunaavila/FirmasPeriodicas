using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using QRCoder;
using FirmasPeriodicas.CapaPD;

namespace FirmasPeriodicas.Msm_Forms
{
    public partial class ComentarioFirma : Form
    {
        Users insertUser = new Users();
        public ComentarioFirma()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            try
            {
                string com = null;
                string personaIdPersona = Cls_Libreria.idpersona;
                string idregistro = Cls_Libreria.idregistro;
                insertUser.InsertarRegistroPP(DateTime.Now, idregistro, personaIdPersona, com);
                FormAsistencia fAsis = new FormAsistencia();
                fAsis.Show();
                fAsis.CargarDatos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema " + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

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


        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                string com = txtComentario.Text.ToUpper();
                string personaIdPersona = Cls_Libreria.idpersona;
                string idregistro = Cls_Libreria.idregistro;
                insertUser.InsertarRegistroPP(DateTime.Now, idregistro, personaIdPersona, com);
                FormAsistencia fAsis = new FormAsistencia();
                fAsis.Show();
                fAsis.CargarDatos();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema " + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }
    }
}
