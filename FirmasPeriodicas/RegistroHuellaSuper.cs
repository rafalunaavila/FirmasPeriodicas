using FirmasPeriodicas.CapaPD;
using FirmasPeriodicas.Helper;
using FirmasPeriodicas.Msm_Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirmasPeriodicas
{
    public partial class RegistroHuellaSuper : Form
    {
        public RegistroHuellaSuper()
        {
            InitializeComponent();
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

        private void enrollmentControl1_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));

        }

        private void enrollmentControl1_OnEnroll(object Control, int FingerMask, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            byte[] bytes = null;
            Users obj = new Users();
            if (Template is null)
            {
                Template.Serialize(ref bytes);
                MessageBox.Show("No se puede realizar la Operacion Requerida", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt_user.Text = "";
                txt_pass.Text = "";
                this.Tag = "";
                enrollmentControl1.Enabled = false;
                this.Close();
            }
            else
            {
                Template.Serialize(ref bytes);
                obj.RN_Registrar_Huella_Supervisor(txt_user.Text, txt_pass.Text, bytes);
                enrollmentControl1.Enabled = false;
                txt_pass.Text = "";
                txt_user.Text = "";
                if (DBUsuario.huella == true)
                {
                    MessageBox.Show("La Huella Registrada", "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
     
                }


            }
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            Login log = new Login();
            log.Show();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }

        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
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
    }
}
