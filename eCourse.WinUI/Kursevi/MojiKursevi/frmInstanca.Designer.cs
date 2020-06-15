namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    partial class frmInstanca
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
            this.labelNazivKursa = new System.Windows.Forms.Label();
            this.labelDatumPocetka = new System.Windows.Forms.Label();
            this.labelOdrzanoCasova = new System.Windows.Forms.Label();
            this.labelStudenataNaKursu = new System.Windows.Forms.Label();
            this.labelUkupnoCasova = new System.Windows.Forms.Label();
            this.btnPregledajKlijente = new System.Windows.Forms.Button();
            this.btnOrganizujIspit = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.btnUgovoriCas = new System.Windows.Forms.Button();
            this.gridCasovi = new System.Windows.Forms.DataGridView();
            this.btnZavrsiKurs = new System.Windows.Forms.Button();
            this.btnPostavke = new System.Windows.Forms.Button();
            this.labelZavrsio = new System.Windows.Forms.Label();
            this.labelPrijaveDo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridCasovi)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNazivKursa
            // 
            this.labelNazivKursa.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNazivKursa.Location = new System.Drawing.Point(313, 4);
            this.labelNazivKursa.Name = "labelNazivKursa";
            this.labelNazivKursa.Size = new System.Drawing.Size(394, 91);
            this.labelNazivKursa.TabIndex = 0;
            this.labelNazivKursa.Text = "Kurs: Naziv";
            // 
            // labelDatumPocetka
            // 
            this.labelDatumPocetka.AutoSize = true;
            this.labelDatumPocetka.Location = new System.Drawing.Point(9, 14);
            this.labelDatumPocetka.Name = "labelDatumPocetka";
            this.labelDatumPocetka.Size = new System.Drawing.Size(86, 13);
            this.labelDatumPocetka.TabIndex = 1;
            this.labelDatumPocetka.Text = "Počeo: 1-1-2000";
            // 
            // labelOdrzanoCasova
            // 
            this.labelOdrzanoCasova.AutoSize = true;
            this.labelOdrzanoCasova.Location = new System.Drawing.Point(889, 38);
            this.labelOdrzanoCasova.Name = "labelOdrzanoCasova";
            this.labelOdrzanoCasova.Size = new System.Drawing.Size(97, 13);
            this.labelOdrzanoCasova.TabIndex = 2;
            this.labelOdrzanoCasova.Text = "Održano časova: 0";
            // 
            // labelStudenataNaKursu
            // 
            this.labelStudenataNaKursu.AutoSize = true;
            this.labelStudenataNaKursu.Location = new System.Drawing.Point(872, 87);
            this.labelStudenataNaKursu.Name = "labelStudenataNaKursu";
            this.labelStudenataNaKursu.Size = new System.Drawing.Size(112, 13);
            this.labelStudenataNaKursu.TabIndex = 3;
            this.labelStudenataNaKursu.Text = "Studenata na kursu: 0";
            // 
            // labelUkupnoCasova
            // 
            this.labelUkupnoCasova.AutoSize = true;
            this.labelUkupnoCasova.Location = new System.Drawing.Point(889, 63);
            this.labelUkupnoCasova.Name = "labelUkupnoCasova";
            this.labelUkupnoCasova.Size = new System.Drawing.Size(95, 13);
            this.labelUkupnoCasova.TabIndex = 4;
            this.labelUkupnoCasova.Text = "Ukupno časova: 0";
            // 
            // btnPregledajKlijente
            // 
            this.btnPregledajKlijente.Location = new System.Drawing.Point(894, 118);
            this.btnPregledajKlijente.Name = "btnPregledajKlijente";
            this.btnPregledajKlijente.Size = new System.Drawing.Size(92, 41);
            this.btnPregledajKlijente.TabIndex = 5;
            this.btnPregledajKlijente.Text = "Pregled liste klijenata";
            this.btnPregledajKlijente.UseVisualStyleBackColor = true;
            this.btnPregledajKlijente.Click += new System.EventHandler(this.btnPregledajKlijente_Click);
            // 
            // btnOrganizujIspit
            // 
            this.btnOrganizujIspit.Location = new System.Drawing.Point(319, 119);
            this.btnOrganizujIspit.Name = "btnOrganizujIspit";
            this.btnOrganizujIspit.Size = new System.Drawing.Size(135, 40);
            this.btnOrganizujIspit.TabIndex = 6;
            this.btnOrganizujIspit.Text = "Organizuj ispit za ovaj kurs";
            this.btnOrganizujIspit.UseVisualStyleBackColor = true;
            this.btnOrganizujIspit.Click += new System.EventHandler(this.btnOrganizujIspit_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(316, 100);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(189, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "Status: Prijave završene - Kurs aktivan";
            // 
            // btnUgovoriCas
            // 
            this.btnUgovoriCas.Location = new System.Drawing.Point(12, 228);
            this.btnUgovoriCas.Name = "btnUgovoriCas";
            this.btnUgovoriCas.Size = new System.Drawing.Size(84, 30);
            this.btnUgovoriCas.TabIndex = 8;
            this.btnUgovoriCas.Text = "Ugovori čas";
            this.btnUgovoriCas.UseVisualStyleBackColor = true;
            this.btnUgovoriCas.Click += new System.EventHandler(this.btnUgovoriCas_Click);
            // 
            // gridCasovi
            // 
            this.gridCasovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCasovi.Location = new System.Drawing.Point(12, 264);
            this.gridCasovi.Name = "gridCasovi";
            this.gridCasovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCasovi.Size = new System.Drawing.Size(972, 340);
            this.gridCasovi.TabIndex = 9;
            this.gridCasovi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridCasovi_MouseDoubleClick);
            // 
            // btnZavrsiKurs
            // 
            this.btnZavrsiKurs.Location = new System.Drawing.Point(319, 165);
            this.btnZavrsiKurs.Name = "btnZavrsiKurs";
            this.btnZavrsiKurs.Size = new System.Drawing.Size(135, 23);
            this.btnZavrsiKurs.TabIndex = 10;
            this.btnZavrsiKurs.Text = "Završi kurs";
            this.btnZavrsiKurs.UseVisualStyleBackColor = true;
            this.btnZavrsiKurs.Click += new System.EventHandler(this.btnZavrsiKurs_Click);
            // 
            // btnPostavke
            // 
            this.btnPostavke.Location = new System.Drawing.Point(909, 4);
            this.btnPostavke.Name = "btnPostavke";
            this.btnPostavke.Size = new System.Drawing.Size(75, 23);
            this.btnPostavke.TabIndex = 11;
            this.btnPostavke.Text = "Postavke";
            this.btnPostavke.UseVisualStyleBackColor = true;
            this.btnPostavke.Click += new System.EventHandler(this.btnPostavke_Click);
            // 
            // labelZavrsio
            // 
            this.labelZavrsio.AutoSize = true;
            this.labelZavrsio.Location = new System.Drawing.Point(12, 63);
            this.labelZavrsio.Name = "labelZavrsio";
            this.labelZavrsio.Size = new System.Drawing.Size(90, 13);
            this.labelZavrsio.TabIndex = 12;
            this.labelZavrsio.Text = "Završio: 1-1-2000";
            // 
            // labelPrijaveDo
            // 
            this.labelPrijaveDo.AutoSize = true;
            this.labelPrijaveDo.Location = new System.Drawing.Point(9, 38);
            this.labelPrijaveDo.Name = "labelPrijaveDo";
            this.labelPrijaveDo.Size = new System.Drawing.Size(102, 13);
            this.labelPrijaveDo.TabIndex = 13;
            this.labelPrijaveDo.Text = "Prijave do: 1-1-2000";
            // 
            // frmInstanca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 616);
            this.Controls.Add(this.labelPrijaveDo);
            this.Controls.Add(this.labelZavrsio);
            this.Controls.Add(this.btnPostavke);
            this.Controls.Add(this.btnZavrsiKurs);
            this.Controls.Add(this.gridCasovi);
            this.Controls.Add(this.btnUgovoriCas);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.btnOrganizujIspit);
            this.Controls.Add(this.btnPregledajKlijente);
            this.Controls.Add(this.labelUkupnoCasova);
            this.Controls.Add(this.labelStudenataNaKursu);
            this.Controls.Add(this.labelOdrzanoCasova);
            this.Controls.Add(this.labelDatumPocetka);
            this.Controls.Add(this.labelNazivKursa);
            this.Name = "frmInstanca";
            this.Text = "Instanca kursa";
            this.Load += new System.EventHandler(this.frmInstanca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCasovi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNazivKursa;
        private System.Windows.Forms.Label labelDatumPocetka;
        private System.Windows.Forms.Label labelOdrzanoCasova;
        private System.Windows.Forms.Label labelStudenataNaKursu;
        private System.Windows.Forms.Label labelUkupnoCasova;
        private System.Windows.Forms.Button btnPregledajKlijente;
        private System.Windows.Forms.Button btnOrganizujIspit;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button btnUgovoriCas;
        private System.Windows.Forms.DataGridView gridCasovi;
        private System.Windows.Forms.Button btnZavrsiKurs;
        private System.Windows.Forms.Button btnPostavke;
        private System.Windows.Forms.Label labelZavrsio;
        private System.Windows.Forms.Label labelPrijaveDo;
    }
}