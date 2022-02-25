using FirmasPeriodicas.CapaPD;
using FirmasPeriodicas.Msm_Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FirmasPeriodicas
{
    public partial class RegistroHuellaPersona : Form
    {
        Users insertUser = new Users();
        public RegistroHuellaPersona()
        {
            InitializeComponent();
            Arranque();
        }

        private void Arranque()
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea continuar con el registro de " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + "?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                Cls_Libreria.Vacioo = "";

                this.Close();
            }
            else
            {
                this.Show();
                lbl_nombreP.Text = Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson;
                lbl_idpersona.Text = Cls_Libreria.idpersona;
                lbl_nomUser.Text = Cls_Libreria.NombreUsuario;
                pictureBox1.Load(@"http://10.6.60.190/Fotos/" + Cls_Libreria.Foto);
                // MessageBox.Show("hola"+pictureBox1.Image.Width + "largoo" + pictureBox1.Image.Height);
                int ancho = pictureBox1.Image.Width;
                int largo = pictureBox1.Image.Height;
                if (ancho > largo)
                {
                    pictureBox1.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                }
            }
        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enrollmentControl1_OnCancelEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnCancelEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
        }
        private void enrollmentControl1_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
            DialogResult dialogResult = MessageBox.Show("¿Desea Registrar a " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + "?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                this.Close();
            }
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
        string nomsuper = "";
        private void enrollmentControl1_OnEnroll(object Control, int FingerMask, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            nomsuper = Cls_Libreria.NombreUsuario;
            byte[] bytes = null;
            if (Template is null)
            {
                Template.Serialize(ref bytes);
                Cls_Libreria.Mensajesistema = "La huella no se pudo registrar ";
                FormWarning fw = new FormWarning();
                fw.Show();
                fw.CargarDatos();
                this.Tag = "";
                this.Close();
            }
            else
            {
                Users objeto = new Users();
                if (objeto.checarRegistroPersona(lbl_idpersona.Text.Trim()) == true)
                {
                    DialogResult dialogResult2 = MessageBox.Show("El Usuario ya esta registrado ¿Desea registrar su asistencia?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult2 == DialogResult.Yes)
                    {
                        //this.Close();
                    }
                }
                else
                {
                    Template.Serialize(ref bytes);
                    insertUser.InsertarPRod(bytes, lbl_idpersona.Text, nomsuper, DateTime.Now);
                    string usuario = Cls_Libreria.NombreUsuario;
                    //insertUser.InsertarPRod(bytes, lbl_id.Text, usuario);
                    // Cls_Libreria.Mensajesistema = ;
                    lbl_idpersona.Text = "";
                    lbl_nombreP.Text = "";
                    MessageBox.Show("La persona " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + " se ha registrado con exito ", "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    enrollmentControl1.Enabled = false;
             
                }

            }
            return;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void label13_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }


       
    }
}
