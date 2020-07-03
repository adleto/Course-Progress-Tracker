namespace eCourse.WinUI.Kursevi.MojiKursevi.Ispit
{
    partial class frmIspitDetail
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.vrijemePicker = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateVrijeme
            // 
            this.dateVrijeme.Location = new System.Drawing.Point(172, 20);
            this.dateVrijeme.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dateVrijeme.Name = "dateVrijeme";
            this.dateVrijeme.Size = new System.Drawing.Size(265, 22);
            this.dateVrijeme.TabIndex = 0;
            this.dateVrijeme.Validating += new System.ComponentModel.CancelEventHandler(this.dateVrijeme_Validating);
            // 
            // txtLokacija
            // 
            this.txtLokacija.Location = new System.Drawing.Point(172, 58);
            this.txtLokacija.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLokacija.Name = "txtLokacija";
            this.txtLokacija.Size = new System.Drawing.Size(265, 22);
            this.txtLokacija.TabIndex = 1;
            this.txtLokacija.Validating += new System.ComponentModel.CancelEventHandler(this.txtLokacija_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Vrijeme ispita";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Lokacija održavanja";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(172, 103);
            this.btnPotvrdi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(267, 28);
            this.btnPotvrdi.TabIndex = 4;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // vrijemePicker
            // 
            this.vrijemePicker.Location = new System.Drawing.Point(464, 20);
            this.vrijemePicker.Margin = new System.Windows.Forms.Padding(4);
            this.vrijemePicker.Name = "vrijemePicker";
            this.vrijemePicker.Size = new System.Drawing.Size(121, 22);
            this.vrijemePicker.TabIndex = 5;
            // 
            // frmIspitDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 213);
            this.Controls.Add(this.vrijemePicker);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLokacija);
            this.Controls.Add(this.dateVrijeme);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmIspitDetail";
            this.Text = "Ispit";
            this.Load += new System.EventHandler(this.frmIspitDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateVrijeme;
        private System.Windows.Forms.TextBox txtLokacija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DateTimePicker vrijemePicker;
    }
}