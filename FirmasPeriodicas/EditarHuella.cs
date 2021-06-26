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


        public void Buscar_Personal_paraEditar(String xvalor)
        {
            try
            {
                Users obj = new Users();
                DataTable data = new DataTable();
                data = obj.RN_Buscar_personal_xvalor_edicion(xvalor);
                if (data.Rows.Count == 0) return;
                {
                    lbl_idPersona.Text = Convert.ToString(data.Rows[0]["idPersona"]);
                    lbl_nombre.Text = Convert.ToString(data.Rows[0]["Nombre"]);
                    lbl_idregistro.Text = xvalor;
                }     
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar datos", "Advertencia de Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Tag = "";
            this.Close();
        }

        private void btn_Salir_Click(object sender, EventArgs e)
        {
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

        private void enrollmentControl1_Load(object sender, EventArgs e)
        {

        }

        private void EditarHuella_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
