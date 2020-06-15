namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    partial class frmPostavkeInstance
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
            this.datePocetak = new System.Windows.Forms.DateTimePicker();
            this.datePrijaveDo = new System.Windows.Forms.DateTimePicker();
            this.txtKapacitet = new System.Windows.Forms.TextBox();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // datePocetak
            // 
            this.datePocetak.Location = new System.Drawing.Point(127, 24);
            this.datePocetak.Name = "datePocetak";
            this.datePocetak.Size = new System.Drawing.Size(200, 20);
            this.datePocetak.TabIndex = 0;
            this.datePocetak.Validating += new System.ComponentModel.CancelEventHandler(this.datePocetak_Validating);
            // 
            // datePrijaveDo
            // 
            this.datePrijaveDo.Location = new System.Drawing.Point(127, 61);
            this.datePrijaveDo.Name = "datePrijaveDo";
            this.datePrijaveDo.Size = new System.Drawing.Size(200, 20);
            this.datePrijaveDo.TabIndex = 1;
            this.datePrijaveDo.Validating += new System.ComponentModel.CancelEventHandler(this.datePrijaveDo_Validating);
            // 
            // txtKapacitet
            // 
            this.txtKapacitet.Location = new System.Drawing.Point(127, 99);
            this.txtKapacitet.Name = "txtKapacitet";
            this.txtKapacitet.Size = new System.Drawing.Size(200, 20);
            this.txtKapacitet.TabIndex = 2;
            this.txtKapacitet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtKapacitet.Validating += new System.ComponentModel.CancelEventHandler(this.txtKapacitet_Validating);
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(127, 140);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(200, 23);
            this.btnPotvrdi.TabIndex = 3;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Datum početka kursa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Krajnji rok za prijave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Kapacitet";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmPostavkeInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 242);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.txtKapacitet);
            this.Controls.Add(this.datePrijaveDo);
            this.Controls.Add(this.datePocetak);
            this.Name = "frmPostavkeInstance";
            this.Text = "frmPostavkeInstance";
            this.Load += new System.EventHandler(this.frmPostavkeInstance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePocetak;
        private System.Windows.Forms.DateTimePicker datePrijaveDo;
        private System.Windows.Forms.TextBox txtKapacitet;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}