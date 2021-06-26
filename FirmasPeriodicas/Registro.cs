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
using MySql.Data.MySqlClient;
using FirmasPeriodicas.Helper;
using System.IO;



namespace FirmasPeriodicas
{

    public partial class Registro : Form
    {
        Users insertUser = new Users();
        public Registro()
        {
            InitializeComponent();
            mostrarComboVox();
        }

        DBUsuario dbuser = new DBUsuario();
        private void mostrarComboVox()
        {
            dbuser.llenarCombo(comboBox1);
        }

     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;
            Object selectedItem = comboBox1.SelectedItem;
            var display = comboBox1.SelectedValue.ToString();
            lbl_id.Text = display;

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
            enrollmentControl1.Enabled = false;
            byte[] bytes = null;
            if (Template is null)
            {
                Template.Serialize(ref bytes);
                MessageBox.Show("La huella no se pudo registrar", "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Tag = "";
                this.Close();
            }
            else
            {
                Users objeto = new Users();
                if (objeto.checarRegistroPersona(lbl_id.Text.Trim()) == true)
                {
                    DialogResult dialogResult = MessageBox.Show("El Usuario ya esta registrado¿Desea registrar su asistencia?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if(dialogResult == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
                else
                {
                Template.Serialize(ref bytes);
                insertUser.InsertarPRod(bytes, lbl_id.Text);
                enrollmentControl1.Enabled = false;
                MessageBox.Show("La persona se ha registrado", "Informe del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                }
                
            }return;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }
    }
}
