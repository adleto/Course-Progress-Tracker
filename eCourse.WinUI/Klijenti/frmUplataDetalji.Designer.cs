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
            this.comboKlijent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboKursInstancaKlijenta = new System.Windows.Forms.ComboBox();
            this.labelCijenaKursa = new System.Windows.Forms.Label();
            this.btnPotvrdi = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboKlijent
            // 
            this.comboKlijent.FormattingEnabled = true;
            this.comboKlijent.Location = new System.Drawing.Point(107, 50);
            this.comboKlijent.Name = "comboKlijent";
            this.comboKlijent.Size = new System.Drawing.Size(176, 21);
            this.comboKlijent.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Klijent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tip uplate";
            // 
            // comboTip
            // 
            this.comboTip.FormattingEnabled = true;
            this.comboTip.Location = new System.Drawing.Point(107, 89);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(176, 21);
            this.comboTip.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Iznos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 131);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Kurs";
            // 
            // comboKursInstancaKlijenta
            // 
            this.comboKursInstancaKlijenta.FormattingEnabled = true;
            this.comboKursInstancaKlijenta.Location = new System.Drawing.Point(107, 214);
            this.comboKursInstancaKlijenta.Name = "comboKursInstancaKlijenta";
            this.comboKursInstancaKlijenta.Size = new System.Drawing.Size(176, 21);
            this.comboKursInstancaKlijenta.TabIndex = 7;
            // 
            // labelCijenaKursa
            // 
            this.labelCijenaKursa.AutoSize = true;
            this.labelCijenaKursa.Location = new System.Drawing.Point(104, 238);
            this.labelCijenaKursa.Name = "labelCijenaKursa";
            this.labelCijenaKursa.Size = new System.Drawing.Size(140, 13);
            this.labelCijenaKursa.TabIndex = 9;
            this.labelCijenaKursa.Text = "Cijena ovog kursa je: xxxKM";
            // 
            // btnPotvrdi
            // 
            this.btnPotvrdi.Location = new System.Drawing.Point(131, 285);
            this.btnPotvrdi.Name = "btnPotvrdi";
            this.btnPotvrdi.Size = new System.Drawing.Size(75, 23);
            this.btnPotvrdi.TabIndex = 10;
            this.btnPotvrdi.Text = "Potvrdi";
            this.btnPotvrdi.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(260, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "KM";
            // 
            // frmUplataDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 436);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPotvrdi);
            this.Controls.Add(this.labelCijenaKursa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboKursInstancaKlijenta);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboTip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboKlijent);
            this.Name = "frmUplataDetalji";
            this.Text = "Nova uplata";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboKlijent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboKursInstancaKlijenta;
        private System.Windows.Forms.Label labelCijenaKursa;
        private System.Windows.Forms.Button btnPotvrdi;
        private System.Windows.Forms.Label label5;
    }
}