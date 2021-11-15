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
using DPFP;
using DPFP.Gui.Verification;
using System.Web;
using System.Net;
using System.IO;
using System.Drawing.Imaging;

namespace FirmasPeriodicas
{
    public partial class EditarHuella : Form
    {
        public EditarHuella()
        {
      
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }
  

        string xFotoRuta;
        string NombrePerson;
        string PaternoPerson;
        string MaternoPerson;
        public void Buscar_Personal_paraEditar(String xvalor)
        {
            try
            {
                enrollmentControl1.Enabled = false;
                Users obj = new Users();
                DataTable data = new DataTable();
                data = obj.RN_Buscar_personal_xvalor_edicion(xvalor);
                if (data.Rows.Count == 0) return;
                {
                    lbl_idPersona.Text = Convert.ToString(data.Rows[0]["idPersona"]);
                    NombrePerson = Convert.ToString(data.Rows[0]["Nombre"]);
                    PaternoPerson = Convert.ToString(data.Rows[0]["Paterno"]);
                    MaternoPerson = Convert.ToString(data.Rows[0]["Materno"]);
                    lbl_nombre.Text = NombrePerson + " " + PaternoPerson + " " + MaternoPerson;
                    xFotoRuta = Convert.ToString(data.Rows[0]["rutaFoto"]);
                    pictureBox3.Load(@"http://10.6.60.190/Fotos/" + xFotoRuta);
                    int ancho = pictureBox3.Image.Width;
                    int largo = pictureBox3.Image.Height;
                    if (ancho > largo)
                    {
                        pictureBox3.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                    }


                    lbl_idregistro.Text = xvalor;
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos "+ ex.Message, "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            enrollmentControl1.Enabled = false;
            this.Tag = "";
            this.Close();
        }

        private void enrollmentControl1_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }

        private void enrollmentControl1_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            ListEvents.Items.Insert(0, String.Format("OnSampleQueallity: {0}, finger {1},{2}", ReaderSerialNumber, Finger, CaptureFeedback));
        }

        private void enrollmentControl1_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger{1}", ReaderSerialNumber, Finger));
        }

        private void enrollmentControl1_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderConnect: {0}, finger{1}", ReaderSerialNumber, Finger));

        }

        private void enrollmentControl1_OnFingerTouch(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerTouch: {0}, finger{1}", ReaderSerialNumber, Finger));

        }

        private void enrollmentControl1_OnFingerRemove(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnFingerRemove: {0}, finger{1}", ReaderSerialNumber, Finger));
        }

        private void enrollmentControl1_OnEnroll(object Control, int FingerMask, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            byte[] bytes = null;
            Users obj = new Users();

            if (Template is null)
            {
                Template.Serialize(ref bytes);
                MessageBox.Show("No se puede realizar la Operacion Requerida", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                lbl_idPersona.Text = "";
                lbl_idregistro.Text = "";
                lbl_nombre.Text = "";
                this.Tag = "";
                this.Close();
            }
            else
            {
                Template.Serialize(ref bytes);
                obj.RN_Registrar_Huella_Personal_Edicion(lbl_idregistro.Text, bytes);
                enrollmentControl1.Enabled = false;
                lbl_idPersona.Text = "";
                lbl_nombre.Text = "";
                lbl_idregistro.Text = "";
                if (DBUsuario.huella == true)
                {
                    MessageBox.Show("La Huella Fue Actualizada", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Tag = "A";
                    this.Close();
                }


            }
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            var imagen = string.Empty;
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    xFotoRuta = openFileDialog1.FileName;
                    pictureBox3.Load(xFotoRuta);
                    System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog1.FileName);
                    MessageBox.Show("Width: " + img.Width + ", Height: " + img.Height);


                }
            }
            catch(Exception ex)
            {
              
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }
    }
}
