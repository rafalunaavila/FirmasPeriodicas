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
using DPFP;
using FirmasPeriodicas.Msm_Forms;

namespace FirmasPeriodicas
{
    public partial class MenuPrincipal : Form
    {
        Users insertUser = new Users();
        public MenuPrincipal()
        {
            InitializeComponent();
            lbl_nomUser.Text = Cls_Libreria.NombreUsuario;
        }

        //NUEVO METODO PARA SELECIONAR ID PERSONA
        private void BusacarIDPersona()
        {
            Users obj = new Users();
            DataTable table = new DataTable();
            
            int totalFilas = 0;
            string nombre, apellidoP, apellidoM, nomCompleto;
            String id;
            id = txt_nom.Text.Trim();
            if (obj.Verificar_id(id) == true)
            {
                table = obj.mostarUsers(id);
                totalFilas = table.Rows.Count;
                if (table.Rows.Count <= 0) return;
                var datoPer = table.Rows[0];
                foreach (DataRow xitem in table.Rows)
                {
                    nombre = Convert.ToString(xitem["Nombre"]);
                    apellidoP = Convert.ToString(xitem["Paterno"]);
                    apellidoM = Convert.ToString(xitem["Materno"]);

                    Cls_Libreria.NombrePerson = nombre;
                    Cls_Libreria.PaternoPerson = apellidoP;
                    Cls_Libreria.MaternoPerson = apellidoM;
                    Cls_Libreria.Foto = Convert.ToString(xitem["rutaFoto"]);

                    FormRegistro fAsis = new FormRegistro();
                    fAsis.Show();
                    fAsis.CaragarDatos();

                    txt_nombreP.Text = nombre + " " + apellidoP + " " + apellidoM;

                }
            }
            else
            {
                if (txt_nom.Text == "")
                {
                    MessageBox.Show("Buscador vacio", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    MessageBox.Show("La Perosna no se ecuentra en el sistema O ya esta registrada", "Advetrencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_nom.Text = "";
                }
               
            }
            
        }


        DBUsuario dbuser = new DBUsuario();
 

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
           
            Verificar = new DPFP.Verification.Verification();
            Resultado = new DPFP.Verification.Verification.Result();
            dateTimePicker1.Value = DateTime.Now;

        }

    

        #region ENROLAMIENTO DE HUELLA EN REGISTRO PERSONA 
        private void enrollmentControl1_OnStartEnroll(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnStartEnroll: {0}, finger {1}", ReaderSerialNumber, Finger));
           
        }

        private void enrollmentControl1_OnSampleQuality(object Control, string ReaderSerialNumber, int Finger, DPFP.Capture.CaptureFeedback CaptureFeedback)
        {
            ListEvents.Items.Insert(0, String.Format("OnSampleQueallity: {0}, finger {1},{2}", ReaderSerialNumber, Finger, CaptureFeedback));
        }

        public void enrollmentControl1_OnReaderDisconnect(object Control, string ReaderSerialNumber, int Finger)
        {
            ListEvents.Items.Insert(0, String.Format("OnReaderDisconnect: {0}, finger{1}", ReaderSerialNumber, Finger));

        }

        public void enrollmentControl1_OnReaderConnect(object Control, string ReaderSerialNumber, int Finger)
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
        //AQUI REGISTRAMOS PERSONAS AL REGISTRO DE HUELLA
        string nombre="";
        string nomsuper = "";
        private void enrollmentControl1_OnEnroll(object Control, int FingerMask, DPFP.Template Template, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea Regstrar a " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + "?" , "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.No)
            {
                txt_nombreP.Text = Cls_Libreria.Vacioo;
                txt_nom.Text = Cls_Libreria.Vacioo;
                return;
            }
            else
            {
                nomsuper = Cls_Libreria.NombreUsuario;
                byte[] bytes = null;
                if (Template is null)
                {
                    Template.Serialize(ref bytes);
                    Cls_Libreria.Mensajesistema = "La huella no se pudo registrar ";
                    FormWarning fw = new FormWarning();
                    fw.Show();
                    fw.CaragarDatos();
                    this.Tag = "";
                    this.Close();
                }
                else
                {
                    Users objeto = new Users();
                    if (objeto.checarRegistroPersona(txt_nom.Text.Trim()) == true)
                    {
                        DialogResult dialogResult2 = MessageBox.Show("El Usuario ya esta registrado ¿Desea registrar su asistencia?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (dialogResult2 == DialogResult.Yes)
                        {
                            tabControl1.SelectTab(2);
                        }
                    }
                    else
                    {
                        Template.Serialize(ref bytes);
                        insertUser.InsertarPRod(bytes, txt_nom.Text, nomsuper, DateTime.Now);
                        string usuario = Cls_Libreria.NombreUsuario;
                        //insertUser.InsertarPRod(bytes, lbl_id.Text, usuario);
                        Cls_Libreria.Mensajesistema = "La persona " + Cls_Libreria.NombrePerson + " " + Cls_Libreria.PaternoPerson + " " + Cls_Libreria.MaternoPerson + " se ha registrado con exito ";
                        txt_nombreP.Text = Cls_Libreria.Vacioo;
                        txt_nom.Text = Cls_Libreria.Vacioo;
                        FormInformation fw = new FormInformation();
                        fw.Show();
                        fw.CaragarDatos();
                        tabControl1.SelectTab(2);
                        enrollmentControl1.Enabled = false;
                    }


                }
                return;
            }  
        }
        #endregion
  
        #region REGISTRO DE ASISTENCIA
        private DPFP.Verification.Verification Verificar;
        private DPFP.Verification.Verification.Result Resultado;

        string xFotoRuta;
        public void verificationControl2_OnComplete_1(object Control, FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            DPFP.Template templateDB = new DPFP.Template();
            byte[] fingeprintByte;
            Users obj = new Users();
            DataTable datosPersona = new DataTable();
            int totalFilas = 0;
            string personaIdPersona = "";
            string idregistro = "";
            string nombrePersona = "";
            string PaternoPersona = "";
            string MaternoPersona = "";
            sbyte Candado;
            string Supervisor = "";
            string Mensaje = "";

            try
            {
                bool encontro = false;
                datosPersona = obj.mostrarUsersPH();
                totalFilas = datosPersona.Rows.Count;
                if (datosPersona.Rows.Count <= 0) return;
                var datoPer = datosPersona.Rows[0];
                foreach (DataRow xitem in datosPersona.Rows)
                {
              
                    fingeprintByte = (byte[])xitem["fingerPrint"];
                    idregistro = Convert.ToString(xitem["idregistroHuella"]);
                    personaIdPersona = Convert.ToString(xitem["personaIdPersona"]);
                    nombrePersona = Convert.ToString(xitem["Nombre"]);
                    PaternoPersona = Convert.ToString(xitem["Paterno"]);
                    MaternoPersona = Convert.ToString(xitem["Materno"]);
                    Supervisor = Convert.ToString(xitem["Supervisor"]);
                    Mensaje = Convert.ToString(xitem["MotivoCandado"]);

                    Cls_Libreria.Mensajesistema = "No puedes registrar su firma";
                    Cls_Libreria.Mensajesistema1 = "("+Mensaje+")";
                    Cls_Libreria.Mensajesistema2 = "Solicite a su supervisor";
                    Cls_Libreria.Mensajesistema3 = Supervisor;


                    templateDB.DeSerialize(fingeprintByte);
                    Verificar.Verify(FeatureSet, templateDB, ref Resultado);
                    if (Resultado.Verified == true)
                    {
                        Cls_Libreria.idregistro = idregistro;
                        Cls_Libreria.idpersona = personaIdPersona;
                        Cls_Libreria.NombrePerson = nombrePersona;
                        Cls_Libreria.PaternoPerson = PaternoPersona;
                        Cls_Libreria.MaternoPerson = MaternoPersona;
                        Cls_Libreria.Fecha = dateTimePicker1.Value.ToString();
                        
                        Cls_Libreria.Foto = Convert.ToString(xitem["rutaFoto"]);
                        encontro = true;
                        Users objeto = new Users();
                        if (objeto.checarRegistroAsistecia(idregistro.Trim()) == true)
                        {
                            objeto = null;
                            MessageBox.Show("El usuario " + nombrePersona + " " + PaternoPersona + " " + MaternoPersona + " ya marco asistencia el dia de hoy ", "Informe del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                        else
                        {
                            Candado = Convert.ToSByte(xitem["Candado"]);
                            if (Candado == 1){
                                FormDanger fdanger = new FormDanger();
                                fdanger.Show();
                                fdanger.CaragarDatos();
                            }
                            else
                            {
                                DialogResult dialogResult = MessageBox.Show("Desea agregar un comentario?", "Informe del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (dialogResult == DialogResult.Yes)
                                {
                                    ComentarioFirma comentarioFirma = new ComentarioFirma();
                                    comentarioFirma.Show();
                                }
                                else
                                {
                                    string com = null;
                                    insertUser.InsertarRegistroPP(DateTime.Now, idregistro, personaIdPersona, com);
                                    FormAsistencia fAsis = new FormAsistencia();
                                    fAsis.Show();
                                    fAsis.CaragarDatos();
                                } 
                            }
                            
                        }
                    }

                }
                if (encontro == false)
                {
                    Filtro fil = new Filtro();
                    fil.Show();
                    DialogResult dialogResult = MessageBox.Show("La Huella no existe desea registrarse", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tabControl1.SelectTab(0);
                    }

                    fil.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema " + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            Resultado.Verified = false;
            templateDB = null;
           
            return;
        }
        #endregion
        //PARA MOVER EL PANEL DANDO CICK EN LA PARTE SUPERIOR
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Utilitarios u = new Utilitarios();
                u.Mover_formulario(this);
            }
        }



        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            fil.Show();
            DialogResult dialogResult = MessageBox.Show("¿Desea Salir del Sistema?", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                Login log = new Login();
                log.Show();
            }
            fil.Close();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region MOSTRAR PERSONAS CON HUELLA EN LISTVIEW
        private void Cargar_Todo_Asistencia()
        {
            Users obj = new Users();
            DataTable dt = new DataTable();
            dt = obj.verpersonasHuellla();
            if (dt.Rows.Count > 0)
            {
                LlenarListviewPeronasHuella(dt);
            }
        }

        private void LlenarListviewPeronasHuella(DataTable data)
        {
            var lis = lsv_PerosnasHuella;
            lis.Columns.Clear();
            lis.Items.Clear();
            lis.View = View.Details;
            lis.GridLines = false;
            lis.FullRowSelect = true;
            lis.Scrollable = true;
            lis.HideSelection = false;
            lis.Columns.Add("ID", 100, HorizontalAlignment.Left);
            lis.Columns.Add("NombreCompleto", 290, HorizontalAlignment.Left);
            lis.Columns.Add("Supervisor", 190, HorizontalAlignment.Left);
            lsv_PerosnasHuella.Items.Clear();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow dr = data.Rows[i];
                ListViewItem list = new ListViewItem(dr["idregistroHuella"].ToString());
                list.SubItems.Add(dr["NombreCompleto"].ToString());
                list.SubItems.Add(dr["Supervisor"].ToString());
                lsv_PerosnasHuella.Items.Add(list);
            }
            lbl_Total.Text = Convert.ToString(lsv_PerosnasHuella.Items.Count);
        }
        #endregion
        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {
            if (txt_buscador.Text.Trim().Length > 0)
            {
                Buscar_Personal_PorValor(txt_buscador.Text.Trim());
            }
            if(txt_buscador.Text.Trim().Length == 0)
            {
                Cargar_Todo_Asistencia();
            }
        }

        private void Buscar_Personal_PorValor(String xvalor)
        {
            Users obj = new Users();
            DataTable dt = new DataTable();
            dt = obj.RN_Buscar_personal_xvalor(xvalor);
            if (dt.Rows.Count > 0)
            {
                LlenarListviewPeronasHuella(dt);
            }
            else
            {
                lsv_PerosnasHuella.Clear();

            }
        }


        private void txt_buscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_buscador.Text.Trim().Length > 0)
            {
                Buscar_Personal_PorValor(txt_buscador.Text.Trim());
            }
          
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Cargar_Todo_Asistencia();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Cargar_Todo_Asistencia();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            //Registro reg = new Registro();
            //Filtro fil = new Filtro();
            //fil.Show();
            //reg.Show();

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Filtro fil = new Filtro();
            EditarHuella per = new EditarHuella();
            if (lsv_PerosnasHuella.SelectedIndices.Count == 0)
            {

            }
            else
            {
                verificationControl2.Active = false;     
                var lsv = lsv_PerosnasHuella.SelectedItems[0];
                string idpersona = lsv_PerosnasHuella.SelectedItems[0].Text;
                fil.Show();
                per.Buscar_Personal_paraEditar(idpersona);
                per.ShowDialog();
                fil.Hide();
                if (Convert.ToString(per.Tag) == "A")
                {
                    Cargar_Todo_Asistencia();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(3);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(4);
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
          if(e.TabPageIndex == 3)
            {
                Cargar_Todo_Asistencia();
            }
          if (e.TabPageIndex == 1)
            {
                verificationControl2.Active = false;
                verificationControl1.Active = false;
                enrollmentControl1.Enabled = true;
            }
          if (e.TabPageIndex == 2)
            {
                verificationControl2.Active = true;
                verificationControl1.Active = true;
                dateTimePicker1.Value = DateTime.Now;                
          }
            if (e.TabPageIndex == 3)
            {
                verificationControl1.Active = false;
                verificationControl2.Active = false;
                pictureBox12.Hide();
            }
            if (e.TabPageIndex == 4)
            {
                verificationControl2.Active = false;
                verificationControl1.Active = true;     
          }
          if (e.TabPageIndex != 4)
            {
                lbl_nombre.Text = "";
                lbl_Supervisor.Text = "";
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

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
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
        //VERIFICACION DE PERSONA
        private void verificationControl1_OnComplete(object Control, FeatureSet FeatureSet, ref DPFP.Gui.EventHandlerStatus EventHandlerStatus)
        {
            DPFP.Template templateDB = new DPFP.Template();
            byte[] fingeprintByte;
            Users obj = new Users();
            DataTable datosPersona = new DataTable();
            int totalFilas = 0;
            string personaIdPersona = "";
            string idregistro = "";
            string nombrePersona = "";
            string PaternoPersona = "";
            string MaternoPersona = "";
            string personSuper = "";
            string verFoto = "";

            try
            {
                bool encontro = false;
                datosPersona = obj.mostrarUsersPH();
                totalFilas = datosPersona.Rows.Count;
                if (datosPersona.Rows.Count <= 0) return;
                var datoPer = datosPersona.Rows[0];
                foreach (DataRow xitem in datosPersona.Rows)
                {

                    fingeprintByte = (byte[])xitem["fingerPrint"];
                    idregistro = Convert.ToString(xitem["idregistroHuella"]);
                    personaIdPersona = Convert.ToString(xitem["personaIdPersona"]);
                    nombrePersona = Convert.ToString(xitem["Nombre"]);
                    PaternoPersona = Convert.ToString(xitem["Paterno"]);
                    MaternoPersona = Convert.ToString(xitem["Materno"]);
                    personSuper = Convert.ToString(xitem["supervisor"]);
                    templateDB.DeSerialize(fingeprintByte);
                    Verificar.Verify(FeatureSet, templateDB, ref Resultado);
                    if (Resultado.Verified == true)
                    {
                        pictureBox12.Show();
                        lbl_nombre.Text = nombrePersona+" "+PaternoPersona+" "+MaternoPersona;
                        lbl_Supervisor.Text = personSuper;
                        verFoto = Convert.ToString(xitem["rutaFoto"]);
                        pictureBox12.Load(@"http://10.6.60.190/Fotos/" + verFoto);
                        int ancho = pictureBox12.Image.Width;
                        int largo = pictureBox12.Image.Height;
                        if (ancho > largo)
                        {
                            pictureBox12.Image.RotateFlip(RotateFlipType.Rotate90FlipY);
                        }
                        encontro = true;
                    }
                }
                if (encontro == false)
                {
                    verificationControl1.Enabled = false;
                    Filtro fil = new Filtro();
                    fil.Show();
                    DialogResult dialogResult = MessageBox.Show("La Huella no existe desea registrarse", "Informe del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (dialogResult == DialogResult.Yes)
                    {
                        tabControl1.SelectTab(0);
                    }

                    fil.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error del sistema " + ex.Message, "Advertencia del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            Resultado.Verified = false;
            templateDB = null;
            return;

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void lbl_idregistro_Click(object sender, EventArgs e)
        {

        }

        private void txt_nom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            
                BusacarIDPersona();
            }
        }

        private void txt_nom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo números", "Alertas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }


    }
}