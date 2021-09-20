
namespace FirmasPeriodicas.Msm_Forms
{
    partial class FormSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            ns1.BunifuElipse bunifuElipse1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelect));
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ok = new CustomControls.RJControls.RJButton();
            this.lbl_Select = new System.Windows.Forms.Label();
            this.rjButton1 = new CustomControls.RJControls.RJButton();
            this.btn_not = new CustomControls.RJControls.RJButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_NombreP = new System.Windows.Forms.Label();
            bunifuElipse1 = new ns1.BunifuElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            bunifuElipse1.ElipseRadius = 5;
            bunifuElipse1.TargetControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(97, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "Informe del Sistema ";
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.White;
            this.btn_ok.BackgroundColor = System.Drawing.Color.White;
            this.btn_ok.BorderColor = System.Drawing.Color.Black;
            this.btn_ok.BorderRadius = 20;
            this.btn_ok.BorderSize = 3;
            this.btn_ok.FlatAppearance.BorderSize = 0;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ok.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ForeColor = System.Drawing.Color.Black;
            this.btn_ok.Location = new System.Drawing.Point(37, 130);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(132, 36);
            this.btn_ok.TabIndex = 11;
            this.btn_ok.Text = "A c e p t a r";
            this.btn_ok.TextColor = System.Drawing.Color.Black;
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lbl_Select
            // 
            this.lbl_Select.AutoSize = true;
            this.lbl_Select.BackColor = System.Drawing.Color.White;
            this.lbl_Select.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Select.Location = new System.Drawing.Point(89, 43);
            this.lbl_Select.Name = "lbl_Select";
            this.lbl_Select.Size = new System.Drawing.Size(65, 25);
            this.lbl_Select.TabIndex = 10;
            this.lbl_Select.Text = "Mensaje";
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.White;
            this.rjButton1.BackgroundColor = System.Drawing.Color.White;
            this.rjButton1.BorderColor = System.Drawing.Color.DarkOrange;
            this.rjButton1.BorderRadius = 10;
            this.rjButton1.BorderSize = 3;
            this.rjButton1.Enabled = false;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.ForeColor = System.Drawing.Color.White;
            this.rjButton1.Location = new System.Drawing.Point(2, 2);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(366, 179);
            this.rjButton1.TabIndex = 9;
            this.rjButton1.TextColor = System.Drawing.Color.White;
            this.rjButton1.UseVisualStyleBackColor = false;
            // 
            // btn_not
            // 
            this.btn_not.BackColor = System.Drawing.Color.White;
            this.btn_not.BackgroundColor = System.Drawing.Color.White;
            this.btn_not.BorderColor = System.Drawing.Color.Black;
            this.btn_not.BorderRadius = 20;
            this.btn_not.BorderSize = 3;
            this.btn_not.FlatAppearance.BorderSize = 0;
            this.btn_not.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_not.Font = new System.Drawing.Font("Coolvetica Rg", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_not.ForeColor = System.Drawing.Color.Black;
            this.btn_not.Location = new System.Drawing.Point(201, 130);
            this.btn_not.Name = "btn_not";
            this.btn_not.Size = new System.Drawing.Size(132, 36);
            this.btn_not.TabIndex = 13;
            this.btn_not.Text = "C a n c e l a r  ";
            this.btn_not.TextColor = System.Drawing.Color.Black;
            this.btn_not.UseVisualStyleBackColor = false;
            this.btn_not.Click += new System.EventHandler(this.btn_not_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_NombreP
            // 
            this.lbl_NombreP.AutoSize = true;
            this.lbl_NombreP.BackColor = System.Drawing.Color.White;
            this.lbl_NombreP.Font = new System.Drawing.Font("Coolvetica Condensed Rg", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NombreP.Location = new System.Drawing.Point(89, 76);
            this.lbl_NombreP.Name = "lbl_NombreP";
            this.lbl_NombreP.Size = new System.Drawing.Size(65, 25);
            this.lbl_NombreP.TabIndex = 15;
            this.lbl_NombreP.Text = "Mensaje";
            // 
            // FormSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 187);
            this.Controls.Add(this.lbl_NombreP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_not);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_Select);
            this.Controls.Add(this.rjButton1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelect";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.RJControls.RJButton btn_not;
        private System.Windows.Forms.Label label2;
        private CustomControls.RJControls.RJButton btn_ok;
        private System.Windows.Forms.Label lbl_Select;
        private CustomControls.RJControls.RJButton rjButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_NombreP;
    }
}