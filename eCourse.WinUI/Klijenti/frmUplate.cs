using eCourse.Models.Uplata;
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
    public partial class frmUplate : Form
    {
        private readonly ApiService _uplataService = new ApiService("Uplata");
        private int? id = null;
        public frmUplate(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }

        private async void frmUplate_Load(object sender, EventArgs e)
        {
            await LoadUplate(id);
        }
        private async Task LoadUplate(int? klijentId = null)
        {
            var result = await _uplataService.Get<List<UplataModel>>(id);

            dataUplate.DataSource = result;
            dataUplate.Columns[nameof(UplataModel.Id)].Visible = false;
            dataUplate.Columns[nameof(UplataModel.TipUplate)].HeaderText = "Tip uplate";
            dataUplate.Columns[nameof(UplataModel.NamjenaZaKursInstancu)].HeaderText = "Specifični razlog uplate";
            dataUplate.Columns[nameof(UplataModel.ProduzenaClanarinaDo)].HeaderText = "Datum isteka članarine";
            dataUplate.Columns[nameof(UplataModel.ImeIPrezimeKlijenta)].HeaderText = "Klijent";
            dataUplate.Columns[nameof(UplataModel.ImeIPrezimeKlijenta)].DisplayIndex = 1;
            if (id != null && result.Count>0)
            {
                labelHeading.Text = "Uplate klijenta";
            }
        }
    }
}
