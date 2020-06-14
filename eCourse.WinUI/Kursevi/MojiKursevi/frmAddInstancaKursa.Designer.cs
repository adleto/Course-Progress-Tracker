namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    partial class frmAddInstancaKursa
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
            this.comboKurs = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.label2A = new System.Windows.Forms.Label();
            this.datePocetak = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.datePrijave = new System.Windows.Forms.DateTimePicker();
            this.labelCijena = new System.Windows.Forms.Label();
            this.labelKapacitet = new System.Windows.Forms.Label();
            this.txtKapacitet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBrojCasova = new System.Windows.Forms.TextBox();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.checkImaCijenu = new System.Windows.Forms.CheckBox();
            this.checkImaKapacitet = new System.Windows.Forms.CheckBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboKurs
            // 
            this.comboKurs.FormattingEnabled = true;
            this.comboKurs.Location = new System.Drawing.Point(190, 8);
            this.comboKurs.Name = "comboKurs";
            this.comboKurs.Size = new System.Drawing.Size(268, 21);
            this.comboKurs.TabIndex = 0;
            this.comboKurs.Validating += new System.ComponentModel.CancelEventHandler(this.comboKurs_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kurs";
            // 
            // txtCijena
            // 
            this.txtCijena.Location = new System.Drawing.Point(190, 211);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.Size = new System.Drawing.Size(268, 20);
            this.txtCijena.TabIndex = 2;
            this.txtCijena.Validating += new System.ComponentModel.CancelEventHandler(this.txtCijena_Validating);
            // 
            // label2A
            // 
            this.label2A.AutoSize = true;
            this.label2A.Location = new System.Drawing.Point(104, 53);
            this.label2A.Name = "label2A";
            this.label2A.Size = new System.Drawing.Size(80, 13);
            this.label2A.TabIndex = 3;
            this.label2A.Text = "Datum početka";
            // 
            // datePocetak
            // 
            this.datePocetak.Location = new System.Drawing.Point(190, 47);
            this.datePocetak.Name = "datePocetak";
            this.datePocetak.Size = new System.Drawing.Size(268, 20);
            this.datePocetak.TabIndex = 4;
            this.datePocetak.Validating += new System.ComponentModel.CancelEventHandler(this.datePocetak_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Krajnji rok za prijave";
            // 
            // datePrijave
            // 
            this.datePrijave.Location = new System.Drawing.Point(190, 83);
            this.datePrijave.Name = "datePrijave";
            this.datePrijave.Size = new System.Drawing.Size(268, 20);
            this.datePrijave.TabIndex = 6;
            this.datePrijave.Validating += new System.ComponentModel.CancelEventHandler(this.datePrijave_Validating);
            // 
            // labelCijena
            // 
            this.labelCijena.AutoSize = true;
            this.labelCijena.Location = new System.Drawing.Point(148, 214);
            this.labelCijena.Name = "labelCijena";
            this.labelCijena.Size = new System.Drawing.Size(36, 13);
            this.labelCijena.TabIndex = 7;
            this.labelCijena.Text = "Cijena";
            // 
            // labelKapacitet
            // 
            this.labelKapacitet.AutoSize = true;
            this.labelKapacitet.Location = new System.Drawing.Point(9, 254);
            this.labelKapacitet.Name = "labelKapacitet";
            this.labelKapacitet.Size = new System.Drawing.Size(175, 13);
            this.labelKapacitet.TabIndex = 9;
            this.labelKapacitet.Text = "Kapacitet/Maksimalan broj klijenata";
            // 
            // txtKapacitet
            // 
            this.txtKapacitet.Location = new System.Drawing.Point(190, 251);
            this.txtKapacitet.Name = "txtKapacitet";
            this.txtKapacitet.Size = new System.Drawing.Size(268, 20);
            this.txtKapacitet.TabIndex = 8;
            this.txtKapacitet.Validating += new System.ComponentModel.CancelEventHandler(this.txtKapacitet_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Broj časova";
            // 
            // txtBrojCasova
            // 
            this.txtBrojCasova.Location = new System.Drawing.Point(190, 126);
            this.txtBrojCasova.Name = "txtBrojCasova";
            this.txtBrojCasova.Size = new System.Drawing.Size(268, 20);
            this.txtBrojCasova.TabIndex = 10;
            this.txtBrojCasova.Validating += new System.ComponentModel.CancelEventHandler(this.txtBrojCasova_Validating);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(284, 303);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 12;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // checkImaCijenu
            // 
            this.checkImaCijenu.AutoSize = true;
            this.checkImaCijenu.Location = new System.Drawing.Point(190, 162);
            this.checkImaCijenu.Name = "checkImaCijenu";
            this.checkImaCijenu.Size = new System.Drawing.Size(134, 17);
            this.checkImaCijenu.TabIndex = 13;
            this.checkImaCijenu.Text = "Kurs se posebno plaća";
            this.checkImaCijenu.UseVisualStyleBackColor = true;
            // 
            // checkImaKapacitet
            // 
            this.checkImaKapacitet.AutoSize = true;
            this.checkImaKapacitet.Location = new System.Drawing.Point(190, 178);
            this.checkImaKapacitet.Name = "checkImaKapacitet";
            this.checkImaKapacitet.Size = new System.Drawing.Size(169, 17);
            this.checkImaKapacitet.TabIndex = 14;
            this.checkImaKapacitet.Text = "Kurs ima ograničen broj mjesta";
            this.checkImaKapacitet.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddInstancaKursa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 419);
            this.Controls.Add(this.checkImaKapacitet);
            this.Controls.Add(this.checkImaCijenu);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBrojCasova);
            this.Controls.Add(this.labelKapacitet);
            this.Controls.Add(this.txtKapacitet);
            this.Controls.Add(this.labelCijena);
            this.Controls.Add(this.datePrijave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.datePocetak);
            this.Controls.Add(this.label2A);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboKurs);
            this.Name = "frmAddInstancaKursa";
            this.Text = "Instanca kursa";
            this.Load += new System.EventHandler(this.frmAddInstancaKursa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboKurs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label label2A;
        private System.Windows.Forms.DateTimePicker datePocetak;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker datePrijave;
        private System.Windows.Forms.Label labelCijena;
        private System.Windows.Forms.Label labelKapacitet;
        private System.Windows.Forms.TextBox txtKapacitet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBrojCasova;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.CheckBox checkImaCijenu;
        private System.Windows.Forms.CheckBox checkImaKapacitet;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}