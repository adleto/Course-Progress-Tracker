namespace eCourse.WinUI.Klijenti
{
    partial class frmUplataDetalji
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
            this.comboKlijent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textIznos = new System.Windows.Forms.TextBox();
            this.labelForKursInstance = new System.Windows.Forms.Label();
            this.comboKursInstancaKlijenta = new System.Windows.Forms.ComboBox();
            this.labelCijenaKursa = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboKlijent
            // 
            this.comboKlijent.FormattingEnabled = true;
            this.comboKlijent.Location = new System.Drawing.Point(83, 60);
            this.comboKlijent.Name = "comboKlijent";
            this.comboKlijent.Size = new System.Drawing.Size(237, 21);
            this.comboKlijent.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klijent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tip uplate";
            // 
            // comboTip
            // 
            this.comboTip.FormattingEnabled = true;
            this.comboTip.Location = new System.Drawing.Point(83, 99);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(237, 21);
            this.comboTip.TabIndex = 2;
            this.comboTip.SelectedValueChanged += new System.EventHandler(this.comboTip_SelectedValueChanged);
            this.comboTip.Validating += new System.ComponentModel.CancelEventHandler(this.comboTip_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iznos";
            // 
            // textIznos
            // 
            this.textIznos.Location = new System.Drawing.Point(83, 141);
            this.textIznos.Name = "textIznos";
            this.textIznos.Size = new System.Drawing.Size(208, 20);
            this.textIznos.TabIndex = 6;
            this.textIznos.Validating += new System.ComponentModel.CancelEventHandler(this.textIznos_Validating);
            // 
            // labelForKursInstance
            // 
            this.labelForKursInstance.AutoSize = true;
            this.labelForKursInstance.Location = new System.Drawing.Point(32, 232);
            this.labelForKursInstance.Name = "labelForKursInstance";
            this.labelForKursInstance.Size = new System.Drawing.Size(28, 13);
            this.labelForKursInstance.TabIndex = 8;
            this.labelForKursInstance.Text = "Kurs";
            // 
            // comboKursInstancaKlijenta
            // 
            this.comboKursInstancaKlijenta.FormattingEnabled = true;
            this.comboKursInstancaKlijenta.Location = new System.Drawing.Point(83, 224);
            this.comboKursInstancaKlijenta.Name = "comboKursInstancaKlijenta";
            this.comboKursInstancaKlijenta.Size = new System.Drawing.Size(237, 21);
            this.comboKursInstancaKlijenta.TabIndex = 7;
            this.comboKursInstancaKlijenta.SelectedValueChanged += new System.EventHandler(this.comboKursInstancaKlijenta_SelectedValueChanged);
            this.comboKursInstancaKlijenta.Validating += new System.ComponentModel.CancelEventHandler(this.comboKursInstancaKlijenta_Validating);
            // 
            // labelCijenaKursa
            // 
            this.labelCijenaKursa.AutoSize = true;
            this.labelCijenaKursa.Location = new System.Drawing.Point(80, 248);
            this.labelCijenaKursa.Name = "labelCijenaKursa";
            this.labelCijenaKursa.Size = new System.Drawing.Size(140, 13);
            this.labelCijenaKursa.TabIndex = 9;
            this.labelCijenaKursa.Text = "Cijena ovog kursa je: xxxKM";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(145, 292);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 10;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            this.btnPotvrdi.Click += new System.EventHandler(this.btnPotvrdi_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(297, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "KM";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 401);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(318, 26);
            this.label4.TabIndex = 12;
            this.label4.Text = "*Iznos može biti i veći od cijene članarine s tim da se u tom slučaju\r\nračuna tra" +
    "janje članarine u odnosu na koliko je novca uplaćeno.";
            // 
            // frmUplataDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 436);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.labelCijenaKursa);
            this.Controls.Add(this.labelForKursInstance);
            this.Controls.Add(this.comboKursInstancaKlijenta);
            this.Controls.Add(this.textIznos);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboKlijent);
            this.Name = "frmUplataDetalji";
            this.Text = "Nova uplata";
            this.Load += new System.EventHandler(this.frmUplataDetalji_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboKlijent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textIznos;
        private System.Windows.Forms.Label labelForKursInstance;
        private System.Windows.Forms.ComboBox comboKursInstancaKlijenta;
        private System.Windows.Forms.Label labelCijenaKursa;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label4;
    }
}