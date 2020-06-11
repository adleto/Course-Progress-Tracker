namespace eCourse.WinUI.Kursevi.Tagovi
{
    partial class frmTagovi
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
            this.gridTagovi = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridTagovi)).BeginInit();
            this.SuspendLayout();
            // 
            // gridTagovi
            // 
            this.gridTagovi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTagovi.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridTagovi.Location = new System.Drawing.Point(12, 12);
            this.gridTagovi.Name = "gridTagovi";
            this.gridTagovi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridTagovi.Size = new System.Drawing.Size(215, 413);
            this.gridTagovi.TabIndex = 0;
            this.gridTagovi.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gridTagovi_CellMouseDoubleClick);
            // 
            // frmTagovi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 434);
            this.Controls.Add(this.gridTagovi);
            this.Name = "frmTagovi";
            this.Text = "Pregled tagova";
            this.Load += new System.EventHandler(this.frmTagovi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridTagovi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridTagovi;
    }
}