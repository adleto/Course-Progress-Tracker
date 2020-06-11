using eCourse.WinUI.Klijenti;
using eCourse.WinUI.Kursevi.KurseviOpcenito;
using eCourse.WinUI.Kursevi.Tagovi;
using eCourse.WinUI.Osoblje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI
{
    public partial class frmIndexAdmin : Form
    {
        private int childFormNumber = 0;

        public frmIndexAdmin()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }


        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void dodajUposlenikaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUposlenikDetalji();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pregledOsobljaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmOsoblje();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void pregledKlijenataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKlijenti();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void uplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUplate();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void dodajUplatuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUplataDetalji();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pregledTagovaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmTagovi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void dodajTagToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmDetaljiTaga();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void pregledKursevaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKursevi();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }

        private void dodajKursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKursDetalji();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Normal;
            frm.Show();
        }
    }
}
