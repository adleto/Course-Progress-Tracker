using eCourse.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Klijenti
{
    public partial class frmUplataDetalji : Form
    {
        private int? Id = null;
        private readonly ApiService _tipUplateService = new ApiService("TipUplate");
        private readonly ApiService _klijentService = new ApiService("Klijent");
        private readonly ApiService _klijentKursInstancaService = new ApiService("KlijentKursInstanca/GetForUplata");
        public frmUplataDetalji(int? id = null)
        {
            InitializeComponent();
            this.Id = id;
        }
    }
}
