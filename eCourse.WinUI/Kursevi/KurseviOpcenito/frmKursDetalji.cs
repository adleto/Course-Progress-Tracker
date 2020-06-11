using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Kursevi.KurseviOpcenito
{
    public partial class frmKursDetalji : Form
    {
        private int? id = null;
        public frmKursDetalji(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }
    }
}
