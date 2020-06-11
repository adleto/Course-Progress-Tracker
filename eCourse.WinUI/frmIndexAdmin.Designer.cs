namespace eCourse.WinUI
{
    partial class frmIndexAdmin
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.osobljeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledOsobljaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajUposlenikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.klijentiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKlijenataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajUplatuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurseviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledTagovaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajTagToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kurseviToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKursevaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojiKurseviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.osobljeToolStripMenuItem,
            this.klijentiToolStripMenuItem,
            this.kurseviToolStripMenuItem,
            this.mojiKurseviToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1194, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // osobljeToolStripMenuItem
            // 
            this.osobljeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledOsobljaToolStripMenuItem,
            this.dodajUposlenikaToolStripMenuItem});
            this.osobljeToolStripMenuItem.Name = "osobljeToolStripMenuItem";
            this.osobljeToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.osobljeToolStripMenuItem.Text = "Osoblje";
            // 
            // pregledOsobljaToolStripMenuItem
            // 
            this.pregledOsobljaToolStripMenuItem.Name = "pregledOsobljaToolStripMenuItem";
            this.pregledOsobljaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.pregledOsobljaToolStripMenuItem.Text = "Pregled osoblja";
            this.pregledOsobljaToolStripMenuItem.Click += new System.EventHandler(this.pregledOsobljaToolStripMenuItem_Click);
            // 
            // dodajUposlenikaToolStripMenuItem
            // 
            this.dodajUposlenikaToolStripMenuItem.Name = "dodajUposlenikaToolStripMenuItem";
            this.dodajUposlenikaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.dodajUposlenikaToolStripMenuItem.Text = "Dodaj uposlenika";
            this.dodajUposlenikaToolStripMenuItem.Click += new System.EventHandler(this.dodajUposlenikaToolStripMenuItem_Click);
            // 
            // klijentiToolStripMenuItem
            // 
            this.klijentiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKlijenataToolStripMenuItem,
            this.uplateToolStripMenuItem,
            this.dodajUplatuToolStripMenuItem});
            this.klijentiToolStripMenuItem.Name = "klijentiToolStripMenuItem";
            this.klijentiToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.klijentiToolStripMenuItem.Text = "Klijenti";
            // 
            // pregledKlijenataToolStripMenuItem
            // 
            this.pregledKlijenataToolStripMenuItem.Name = "pregledKlijenataToolStripMenuItem";
            this.pregledKlijenataToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.pregledKlijenataToolStripMenuItem.Text = "Pregled klijenata";
            this.pregledKlijenataToolStripMenuItem.Click += new System.EventHandler(this.pregledKlijenataToolStripMenuItem_Click);
            // 
            // uplateToolStripMenuItem
            // 
            this.uplateToolStripMenuItem.Name = "uplateToolStripMenuItem";
            this.uplateToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.uplateToolStripMenuItem.Text = "Uplate";
            this.uplateToolStripMenuItem.Click += new System.EventHandler(this.uplateToolStripMenuItem_Click);
            // 
            // dodajUplatuToolStripMenuItem
            // 
            this.dodajUplatuToolStripMenuItem.Name = "dodajUplatuToolStripMenuItem";
            this.dodajUplatuToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.dodajUplatuToolStripMenuItem.Text = "Dodaj uplatu";
            this.dodajUplatuToolStripMenuItem.Click += new System.EventHandler(this.dodajUplatuToolStripMenuItem_Click);
            // 
            // kurseviToolStripMenuItem
            // 
            this.kurseviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagoviToolStripMenuItem,
            this.kurseviToolStripMenuItem1});
            this.kurseviToolStripMenuItem.Name = "kurseviToolStripMenuItem";
            this.kurseviToolStripMenuItem.Size = new System.Drawing.Size(102, 20);
            this.kurseviToolStripMenuItem.Text = "Katalog kurseva";
            // 
            // tagoviToolStripMenuItem
            // 
            this.tagoviToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledTagovaToolStripMenuItem,
            this.dodajTagToolStripMenuItem});
            this.tagoviToolStripMenuItem.Name = "tagoviToolStripMenuItem";
            this.tagoviToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tagoviToolStripMenuItem.Text = "Tagovi";
            // 
            // pregledTagovaToolStripMenuItem
            // 
            this.pregledTagovaToolStripMenuItem.Name = "pregledTagovaToolStripMenuItem";
            this.pregledTagovaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.pregledTagovaToolStripMenuItem.Text = "Pregled tagova";
            this.pregledTagovaToolStripMenuItem.Click += new System.EventHandler(this.pregledTagovaToolStripMenuItem_Click);
            // 
            // dodajTagToolStripMenuItem
            // 
            this.dodajTagToolStripMenuItem.Name = "dodajTagToolStripMenuItem";
            this.dodajTagToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.dodajTagToolStripMenuItem.Text = "Dodaj tag";
            this.dodajTagToolStripMenuItem.Click += new System.EventHandler(this.dodajTagToolStripMenuItem_Click);
            // 
            // kurseviToolStripMenuItem1
            // 
            this.kurseviToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKursevaToolStripMenuItem,
            this.dodajKursToolStripMenuItem});
            this.kurseviToolStripMenuItem1.Name = "kurseviToolStripMenuItem1";
            this.kurseviToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.kurseviToolStripMenuItem1.Text = "Kursevi";
            // 
            // pregledKursevaToolStripMenuItem
            // 
            this.pregledKursevaToolStripMenuItem.Name = "pregledKursevaToolStripMenuItem";
            this.pregledKursevaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pregledKursevaToolStripMenuItem.Text = "Pregled kurseva";
            this.pregledKursevaToolStripMenuItem.Click += new System.EventHandler(this.pregledKursevaToolStripMenuItem_Click);
            // 
            // dodajKursToolStripMenuItem
            // 
            this.dodajKursToolStripMenuItem.Name = "dodajKursToolStripMenuItem";
            this.dodajKursToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dodajKursToolStripMenuItem.Text = "Dodaj kurs";
            this.dodajKursToolStripMenuItem.Click += new System.EventHandler(this.dodajKursToolStripMenuItem_Click);
            // 
            // mojiKurseviToolStripMenuItem
            // 
            this.mojiKurseviToolStripMenuItem.Name = "mojiKurseviToolStripMenuItem";
            this.mojiKurseviToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.mojiKurseviToolStripMenuItem.Text = "Moji kursevi";
            // 
            // frmIndexAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 604);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmIndexAdmin";
            this.Text = "Course Progress Tracker - Modul za osoblje";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem klijentiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajUplatuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem osobljeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledOsobljaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajUposlenikaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledKlijenataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kurseviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tagoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pregledTagovaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajTagToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kurseviToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pregledKursevaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mojiKurseviToolStripMenuItem;
    }
}



