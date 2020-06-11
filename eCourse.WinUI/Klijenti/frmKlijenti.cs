using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
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

namespace eCourse.WinUI.Klijenti
{
    public partial class frmKlijenti : Form
    {
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca");
        private readonly ApiService _klijentService = new ApiService("Klijent");
        public frmKlijenti()
        {
            InitializeComponent();
        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            await LoadKursInstance();
            await LoadKlijents();
        }
        private async Task LoadKursInstance()
        {
            try {
                var result = await _kursInstancaService.Get<List<KursInstancaModel>>(null);
                result.Insert(0, new KursInstancaModel
                {
                    Id = 0,
                    KursNaziv = "",
                    PocetakDatum = DateTime.Now
                });
                comboKursInstanca.DisplayMember = nameof(KursInstancaModel.InstancaGivenName);
                comboKursInstanca.ValueMember = "Id";
                comboKursInstanca.DataSource = result;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadKlijents(KlijentSearchRequestModel model = null)
        {
            try
            {
                gridKlijenti.RowTemplate.Height = 100;
                var result = await _klijentService.Get<List<KlijentModel>>(model);
                gridKlijenti.DataSource = result;

                gridKlijenti.Columns[nameof(KlijentModel.Id)].Visible = false;
                gridKlijenti.Columns[nameof(KlijentModel.KlijentId)].Visible = false;
                gridKlijenti.Columns[nameof(KlijentModel.OpcinaId)].Visible = false;
                gridKlijenti.Columns[nameof(KlijentModel.UkupnoUplaceno)].HeaderText = "Ukupno uplaćeno";
                gridKlijenti.Columns[nameof(KlijentModel.OpcinaNaziv)].HeaderText = "Općina";
                gridKlijenti.Columns[nameof(KlijentModel.DatumRodjenja)].HeaderText = "Datum Rodjenja";
                gridKlijenti.Columns[nameof(KlijentModel.UkupnoUplaceno)].DisplayIndex = 8;
                gridKlijenti.Columns[nameof(KlijentModel.ClanarinaAktivna)].HeaderText = "Članarina aktivna";
                gridKlijenti.Columns[nameof(KlijentModel.ClanarinaAktivna)].DisplayIndex = 9;
                gridKlijenti.Columns[nameof(KlijentModel.DatumIstekaClanarine)].HeaderText = "Datum isteka članarine";
                gridKlijenti.Columns[nameof(KlijentModel.DatumIstekaClanarine)].DisplayIndex = 10;

                if (gridKlijenti.Columns["UplataColumn"] == null)
                {
                    DataGridViewButtonColumn uplataButton = new DataGridViewButtonColumn()
                    {
                        Name = "UplataColumn",
                        HeaderText = "Akcija",
                        Text = "Dodaj uplatu",
                        UseColumnTextForButtonValue = true
                    };
                    gridKlijenti.CellClick += gridKlijenti_CellClick;
                    gridKlijenti.Columns.Add(uplataButton);
                }
                gridKlijenti.Columns["UplataColumn"].DisplayIndex = 13;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void gridKlijenti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridKlijenti.Columns["UplataColumn"].Index)
            {
                var idSelected = gridKlijenti.SelectedRows[0].Cells[0].Value;
                var frm = new frmUplataDetalji(int.Parse(idSelected.ToString()));
                frm.Show();
            }
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var request = new KlijentSearchRequestModel
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text
            };
            var kursInstancaId = int.Parse(comboKursInstanca.SelectedValue.ToString());
            if (kursInstancaId != 0)
            {
                request.KursInstancaId = kursInstancaId;
            }
            await LoadKlijents(request);
        }

        private void gridKlijenti_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var idSelected = gridKlijenti.SelectedRows[0].Cells[0].Value;
            var frm = new frmUplate(int.Parse(idSelected.ToString()));
            frm.Show();
        }
    }
}
