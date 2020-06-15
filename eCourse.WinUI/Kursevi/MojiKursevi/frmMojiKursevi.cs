using eCourse.Models.KursInstanca;
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

namespace eCourse.WinUI.Kursevi.MojiKursevi
{
    public partial class frmMojiKursevi : Form
    {
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca");
        public frmMojiKursevi()
        {
            InitializeComponent();
            checkedFilter.Items.Add("Završeni", true);
            checkedFilter.Items.Add("Nisu završeni", true);
        }

        private async void frmMojiKursevi_Load(object sender, EventArgs e)
        {
            await LoadInstance();
        }

        private async Task LoadInstance()
        {
            try
            {
                var filter = new MojaKursInstancaFilter
                {
                    NisuZavrseni = checkedFilter.GetItemChecked(1),
                    Zavrseni = checkedFilter.GetItemChecked(0)
                };
                var result = await _kursInstancaService.Get<List<MojaKursInstanca>>(filter);
                gridInstance.DataSource = result;
                gridInstance.Columns[nameof(MojaKursInstanca.KursInstancaId)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.UposlenikId)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.UposlenikIme)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.UposlenikPrezime)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.KrajDate)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.Kapacitet)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.BrojCasova)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.IspitOrganizovan)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.IspitId)].Visible = false;
                gridInstance.Columns[nameof(MojaKursInstanca.UposlenikImeIPrezime)].HeaderText = "Predavač";
                gridInstance.Columns[nameof(MojaKursInstanca.Pocetak)].HeaderText = "Datum početka";
                gridInstance.Columns[nameof(MojaKursInstanca.KrajOpis)].HeaderText = "Datum kraja";
                gridInstance.Columns[nameof(MojaKursInstanca.KursNaziv)].HeaderText = "Kurs";
                gridInstance.Columns[nameof(MojaKursInstanca.KursSkraceniNaziv)].HeaderText = "Kurs (Skraćenica)";
                gridInstance.Columns[nameof(MojaKursInstanca.BrojKlijenata)].HeaderText = "Broj klijenata";
                gridInstance.Columns[nameof(MojaKursInstanca.ZavrsenOpis)].HeaderText = "Status";
                gridInstance.Columns[nameof(MojaKursInstanca.PrijaveDo)].HeaderText = "Krajnji rok za prijave";
                gridInstance.Columns[nameof(MojaKursInstanca.KapacitetOpis)].HeaderText = "Kapacitet";
                gridInstance.Columns[nameof(MojaKursInstanca.KursNaziv)].DisplayIndex = 0;
                gridInstance.Columns[nameof(MojaKursInstanca.KursSkraceniNaziv)].DisplayIndex = 1;
                gridInstance.Columns[nameof(MojaKursInstanca.UposlenikImeIPrezime)].DisplayIndex = 2;
                gridInstance.Columns[nameof(MojaKursInstanca.ZavrsenOpis)].DisplayIndex = 3;
                gridInstance.Columns[nameof(MojaKursInstanca.Pocetak)].DisplayIndex = 4;
                gridInstance.Columns[nameof(MojaKursInstanca.KrajOpis)].DisplayIndex = 5;
                gridInstance.Columns[nameof(MojaKursInstanca.PrijaveDo)].DisplayIndex = 6;
                gridInstance.Columns[nameof(MojaKursInstanca.KapacitetOpis)].DisplayIndex = 7;
                gridInstance.Columns[nameof(MojaKursInstanca.BrojKlijenata)].DisplayIndex = 8;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridInstance_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var idSelected = gridInstance.SelectedRows[0].Cells[gridInstance.Columns[nameof(MojaKursInstanca.KursInstancaId)].Index].Value;
            var frm = new frmInstanca(int.Parse(idSelected.ToString()));
            frm.Show();
        }

        private async void btnFiltriraj_Click(object sender, EventArgs e)
        {
            await LoadInstance();
        }
    }
}
