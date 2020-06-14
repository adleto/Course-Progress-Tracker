using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    public partial class frmInstanca : Form
    {
        int id;
        public frmInstanca(int id)
        {
            this.id = id;
            InitializeComponent();
        }
    }
}
