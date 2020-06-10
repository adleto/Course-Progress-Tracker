namespace eCourse.WinUI.Osoblje
{
    partial class frmUposlenikDetalji
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateRodjenja = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.comboOpcina = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.radioM = new System.Windows.Forms.RadioButton();
            this.radioZ = new System.Windows.Forms.RadioButton();
            this.radioDrugi = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.dateZaposlenja = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.radioNeAktivan = new System.Windows.Forms.RadioButton();
            this.radioDaAktivan = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.txtLozinkaPonovo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtLozinka = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSlikaPath = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.pictureSlika = new System.Windows.Forms.PictureBox();
            this.btnOdaberiSliku = new System.Windows.Forms.Button();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.comboUloga = new System.Windows.Forms.ComboBox();
            this.panelAktivan = new System.Windows.Forms.Panel();
            this.panelSpol = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSlika)).BeginInit();
            this.panelAktivan.SuspendLayout();
            this.panelSpol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(40, 44);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(183, 20);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Validating += new System.ComponentModel.CancelEventHandler(this.txtUsername_Validating);
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(40, 135);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(183, 20);
            this.txtPrezime.TabIndex = 2;
            this.txtPrezime.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrezime_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prezime";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(40, 89);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(183, 20);
            this.txtIme.TabIndex = 1;
            this.txtIme.Validating += new System.ComponentModel.CancelEventHandler(this.txtIme_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ime";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(40, 181);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(183, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 165);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Email";
            // 
            // dateRodjenja
            // 
            this.dateRodjenja.Location = new System.Drawing.Point(40, 232);
            this.dateRodjenja.Name = "dateRodjenja";
            this.dateRodjenja.Size = new System.Drawing.Size(183, 20);
            this.dateRodjenja.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Datum rođenja";
            // 
            // comboOpcina
            // 
            this.comboOpcina.FormattingEnabled = true;
            this.comboOpcina.Location = new System.Drawing.Point(40, 286);
            this.comboOpcina.Name = "comboOpcina";
            this.comboOpcina.Size = new System.Drawing.Size(183, 21);
            this.comboOpcina.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Općina boravišta";
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(40, 338);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(183, 20);
            this.txtJMBG.TabIndex = 6;
            this.txtJMBG.Validating += new System.ComponentModel.CancelEventHandler(this.txtJMBG_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 322);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "JMBG";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Spol";
            // 
            // radioM
            // 
            this.radioM.AutoSize = true;
            this.radioM.Checked = true;
            this.radioM.Location = new System.Drawing.Point(18, 35);
            this.radioM.Name = "radioM";
            this.radioM.Size = new System.Drawing.Size(34, 17);
            this.radioM.TabIndex = 15;
            this.radioM.TabStop = true;
            this.radioM.Text = "M";
            this.radioM.UseVisualStyleBackColor = true;
            // 
            // radioZ
            // 
            this.radioZ.AutoSize = true;
            this.radioZ.Location = new System.Drawing.Point(18, 58);
            this.radioZ.Name = "radioZ";
            this.radioZ.Size = new System.Drawing.Size(32, 17);
            this.radioZ.TabIndex = 16;
            this.radioZ.Text = "Ž";
            this.radioZ.UseVisualStyleBackColor = true;
            // 
            // radioDrugi
            // 
            this.radioDrugi.AutoSize = true;
            this.radioDrugi.Location = new System.Drawing.Point(18, 81);
            this.radioDrugi.Name = "radioDrugi";
            this.radioDrugi.Size = new System.Drawing.Size(50, 17);
            this.radioDrugi.TabIndex = 17;
            this.radioDrugi.Text = "Drugi";
            this.radioDrugi.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(313, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Datum zaposlenja";
            // 
            // dateZaposlenja
            // 
            this.dateZaposlenja.Location = new System.Drawing.Point(316, 44);
            this.dateZaposlenja.Name = "dateZaposlenja";
            this.dateZaposlenja.Size = new System.Drawing.Size(183, 20);
            this.dateZaposlenja.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(43, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Aktivan";
            // 
            // radioNeAktivan
            // 
            this.radioNeAktivan.AutoSize = true;
            this.radioNeAktivan.Location = new System.Drawing.Point(12, 71);
            this.radioNeAktivan.Name = "radioNeAktivan";
            this.radioNeAktivan.Size = new System.Drawing.Size(39, 17);
            this.radioNeAktivan.TabIndex = 10;
            this.radioNeAktivan.Text = "Ne";
            this.radioNeAktivan.UseVisualStyleBackColor = true;
            // 
            // radioDaAktivan
            // 
            this.radioDaAktivan.AutoSize = true;
            this.radioDaAktivan.Checked = true;
            this.radioDaAktivan.Location = new System.Drawing.Point(13, 46);
            this.radioDaAktivan.Name = "radioDaAktivan";
            this.radioDaAktivan.Size = new System.Drawing.Size(39, 17);
            this.radioDaAktivan.TabIndex = 9;
            this.radioDaAktivan.TabStop = true;
            this.radioDaAktivan.Text = "Da";
            this.radioDaAktivan.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(313, 216);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Uloga";
            // 
            // txtLozinkaPonovo
            // 
            this.txtLozinkaPonovo.Location = new System.Drawing.Point(316, 338);
            this.txtLozinkaPonovo.Name = "txtLozinkaPonovo";
            this.txtLozinkaPonovo.PasswordChar = '*';
            this.txtLozinkaPonovo.Size = new System.Drawing.Size(183, 20);
            this.txtLozinkaPonovo.TabIndex = 13;
            this.txtLozinkaPonovo.Validating += new System.ComponentModel.CancelEventHandler(this.txtLozinkaPonovo_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(313, 322);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Lozinka (Ponovo)";
            // 
            // txtLozinka
            // 
            this.txtLozinka.Location = new System.Drawing.Point(316, 287);
            this.txtLozinka.Name = "txtLozinka";
            this.txtLozinka.PasswordChar = '*';
            this.txtLozinka.Size = new System.Drawing.Size(183, 20);
            this.txtLozinka.TabIndex = 12;
            this.txtLozinka.Validating += new System.ComponentModel.CancelEventHandler(this.txtLozinka_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(313, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Lozinka";
            // 
            // txtSlikaPath
            // 
            this.txtSlikaPath.Location = new System.Drawing.Point(562, 178);
            this.txtSlikaPath.Name = "txtSlikaPath";
            this.txtSlikaPath.Size = new System.Drawing.Size(183, 20);
            this.txtSlikaPath.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(560, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 31;
            this.label15.Text = "Slika";
            // 
            // pictureSlika
            // 
            this.pictureSlika.Location = new System.Drawing.Point(563, 216);
            this.pictureSlika.Name = "pictureSlika";
            this.pictureSlika.Size = new System.Drawing.Size(183, 147);
            this.pictureSlika.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureSlika.TabIndex = 33;
            this.pictureSlika.TabStop = false;
            // 
            // btnOdaberiSliku
            // 
            this.btnOdaberiSliku.Location = new System.Drawing.Point(763, 178);
            this.btnOdaberiSliku.Name = "btnOdaberiSliku";
            this.btnOdaberiSliku.Size = new System.Drawing.Size(82, 20);
            this.btnOdaberiSliku.TabIndex = 19;
            this.btnOdaberiSliku.Text = "Odaberi";
            this.btnOdaberiSliku.UseVisualStyleBackColor = true;
            this.btnOdaberiSliku.Click += new System.EventHandler(this.btnOdaberiSliku_Click);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(352, 456);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(112, 42);
            this.btnPotvrdi.TabIndex = 20;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // comboUloga
            // 
            this.comboUloga.FormattingEnabled = true;
            this.comboUloga.Location = new System.Drawing.Point(316, 232);
            this.comboUloga.Name = "comboUloga";
            this.comboUloga.Size = new System.Drawing.Size(183, 21);
            this.comboUloga.TabIndex = 11;
            // 
            // panelAktivan
            // 
            this.panelAktivan.Controls.Add(this.radioDaAktivan);
            this.panelAktivan.Controls.Add(this.radioNeAktivan);
            this.panelAktivan.Controls.Add(this.label11);
            this.panelAktivan.Location = new System.Drawing.Point(316, 73);
            this.panelAktivan.Name = "panelAktivan";
            this.panelAktivan.Size = new System.Drawing.Size(183, 125);
            this.panelAktivan.TabIndex = 8;
            // 
            // panelSpol
            // 
            this.panelSpol.Controls.Add(this.label8);
            this.panelSpol.Controls.Add(this.radioM);
            this.panelSpol.Controls.Add(this.radioZ);
            this.panelSpol.Controls.Add(this.radioDrugi);
            this.panelSpol.Location = new System.Drawing.Point(563, 32);
            this.panelSpol.Name = "panelSpol";
            this.panelSpol.Size = new System.Drawing.Size(183, 123);
            this.panelSpol.TabIndex = 14;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // frmUposlenikDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 565);
            this.Controls.Add(this.panelSpol);
            this.Controls.Add(this.panelAktivan);
            this.Controls.Add(this.comboUloga);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.btnOdaberiSliku);
            this.Controls.Add(this.pictureSlika);
            this.Controls.Add(this.txtSlikaPath);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtLozinkaPonovo);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtLozinka);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateZaposlenja);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboOpcina);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateRodjenja);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label1);
            this.Name = "frmUposlenikDetalji";
            this.Text = "Uposlenik";
            this.Load += new System.EventHandler(this.frmUposlenikDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureSlika)).EndInit();
            this.panelAktivan.ResumeLayout(false);
            this.panelAktivan.PerformLayout();
            this.panelSpol.ResumeLayout(false);
            this.panelSpol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateRodjenja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboOpcina;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtJMBG;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton radioM;
        private System.Windows.Forms.RadioButton radioZ;
        private System.Windows.Forms.RadioButton radioDrugi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateZaposlenja;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton radioNeAktivan;
        private System.Windows.Forms.RadioButton radioDaAktivan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtLozinkaPonovo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtLozinka;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSlikaPath;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.PictureBox pictureSlika;
        private System.Windows.Forms.Button btnOdaberiSliku;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.ComboBox comboUloga;
        private System.Windows.Forms.Panel panelAktivan;
        private System.Windows.Forms.Panel panelSpol;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}