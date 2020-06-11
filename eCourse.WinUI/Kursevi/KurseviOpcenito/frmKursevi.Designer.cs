namespace eCourse.WinUI.Kursevi.KurseviOpcenito
{
    partial class frmKursevi
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
            this.gridKursevi = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.listTagovi = new System.Windows.Forms.CheckedListBox();
            this.butonFiltriraj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridKursevi)).BeginInit();
            this.SuspendLayout();
            // 
            // gridKursevi
            // 
            this.gridKursevi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridKursevi.Location = new System.Drawing.Point(12, 40);
            this.gridKursevi.Name = "gridKursevi";
            this.gridKursevi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridKursevi.Size = new System.Drawing.Size(584, 423);
            this.gridKursevi.TabIndex = 0;
            this.gridKursevi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridKursevi_CellMouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(629, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filtriranje po tagovima";
            // 
            // listTagovi
            // 
            this.listTagovi.FormattingEnabled = true;
            this.listTagovi.Location = new System.Drawing.Point(622, 40);
            this.listTagovi.Name = "listTagovi";
            this.listTagovi.Size = new System.Drawing.Size(130, 394);
            this.listTagovi.TabIndex = 2;
            // 
            // butonFiltriraj
            // 
            this.butonFiltriraj.Location = new System.Drawing.Point(650, 440);
            this.butonFiltriraj.Name = "butonFiltriraj";
            this.butonFiltriraj.Size = new System.Drawing.Size(75, 23);
            this.butonFiltriraj.TabIndex = 3;
            this.butonFiltriraj.Text = "Filtriraj";
            this.butonFiltriraj.UseVisualStyleBackColor = true;
            this.butonFiltriraj.Click += new System.EventHandler(this.butonFiltriraj_Click);
            // 
            // frmKursevi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 475);
            this.Controls.Add(this.butonFiltriraj);
            this.Controls.Add(this.listTagovi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridKursevi);
            this.Name = "frmKursevi";
            this.Text = "Pregled kataloga kurseva";
            this.Load += new System.EventHandler(this.frmKursevi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridKursevi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridKursevi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listTagovi;
        private System.Windows.Forms.Button butonFiltriraj;
    }
}