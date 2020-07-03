namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    partial class frmCasDetalji
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
            this.dateVrijeme = new System.Windows.Forms.DateTimePicker();
            this.txtLokacija = new System.Windows.Forms.TextBox();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.checkOdrzan = new System.Windows.Forms.CheckBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.vrijemePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateVrijeme
            // 
            this.dateVrijeme.Location = new System.Drawing.Point(199, 23);
            this.dateVrijeme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateVrijeme.Name = "dateVrijeme";
            this.dateVrijeme.Size = new System.Drawing.Size(265, 22);
            this.dateVrijeme.TabIndex = 0;
            this.dateVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.dateVrijeme_Validating);
            // 
            // txtLokacija
            // 
            this.txtLokacija.Location = new System.Drawing.Point(199, 78);
            this.txtLokacija.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLokacija.Name = "txtLokacija";
            this.txtLokacija.Size = new System.Drawing.Size(265, 22);
            this.txtLokacija.TabIndex = 1;
            this.txtLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtLokacija_Validating);
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(199, 129);
            this.txtOpis.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(265, 142);
            this.txtOpis.TabIndex = 2;
            // 
            // checkOdrzan
            // 
            this.checkOdrzan.AutoSize = true;
            this.checkOdrzan.Location = new System.Drawing.Point(199, 300);
            this.checkOdrzan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkOdrzan.Name = "checkOdrzan";
            this.checkOdrzan.Size = new System.Drawing.Size(102, 21);
            this.checkOdrzan.TabIndex = 3;
            this.checkOdrzan.Text = "Čas održan";
            this.checkOdrzan.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(199, 358);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(267, 28);
            this.btnConfirm.TabIndex = 4;
            this.btnConfirm.Text = "Potvrdi";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Vrijeme održavanja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lokacija";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Opis/Napomene";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 300);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Status";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // vrijemePicker
            // 
            this.vrijemePicker.Location = new System.Drawing.Point(472, 23);
            this.vrijemePicker.Margin = new System.Windows.Forms.Padding(4);
            this.vrijemePicker.Name = "vrijemePicker";
            this.vrijemePicker.Size = new System.Drawing.Size(142, 22);
            this.vrijemePicker.TabIndex = 9;
            // 
            // frmCasDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 460);
            this.Controls.Add(this.vrijemePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.checkOdrzan);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.txtLokacija);
            this.Controls.Add(this.dateVrijeme);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmCasDetalji";
            this.Text = "Čas";
            this.Load += new System.EventHandler(this.frmCasDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateVrijeme;
        private System.Windows.Forms.TextBox txtLokacija;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.CheckBox checkOdrzan;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker vrijemePicker;
    }
}