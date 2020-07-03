using eCourse.Models.Cas;
using eCourse.Models.Ispit;
using eCourse.Models.IspitKlijent;
using eCourse.Models.Kurs;
using eCourse.WinUI.Service;
using Flurl.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Kursevi.MojiKursevi.Ispit
{
    public partial class frmIspitView : Form
    {
        readonly int instancaId;
        private IspitProsireniModel model;
        private readonly ApiService _ispitService = new ApiService("Ispit");
        private readonly ApiService _ispitKlijentService = new ApiService("IspitKlijent/UpdateKlijentScores");
        DateTime datePocetak;
        public frmIspitView(int instancaId, DateTime datePocetak)
        {
            InitializeComponent();
            this.instancaId = instancaId;
            this.datePocetak = datePocetak;
        }

        private async void frmIspitView_Load(object sender, EventArgs e)
        {
            await LoadIspit();
        }

        private async Task LoadIspit()
        {
            try {
                var ispit = await _ispitService.Get<IspitProsireniModel>(new { instancaId = this.instancaId });
                model = ispit;
                labelNaslov.Text = $"Ispit iz kursa: {ispit.NazivKursa}";
                labelVrijeme.Text = $"{ispit.DatumVrijemeIspita.Date.ToString("dd/MM/yyyy")}";
                if(model.DatumVrijemeIspita.Date < DateTime.Now.Date)
                {
                    btnPostavke.Enabled = false;
                }
                else
                {
                    btnPostavke.Enabled = true;
                }
                gridPolaznici.DataSource = ispit.IspitKlijentLista;
                gridPolaznici.Columns[nameof(IspitKlijentModel.Id)].Visible = false;
                gridPolaznici.Columns[nameof(IspitKlijentModel.IspitId)].Visible = false;
                gridPolaznici.Columns[nameof(IspitKlijentModel.KlijentKursInstancaId)].Visible = false;
                gridPolaznici.Columns[nameof(IspitKlijentModel.Bodovi)].Visible = false;
                gridPolaznici.Columns[nameof(IspitKlijentModel.Prisustvovao)].HeaderText = "Prisustvo";
                gridPolaznici.Columns[nameof(IspitKlijentModel.ImeIPrezime)].HeaderText = "Ime i prezime";

                if (gridPolaznici.Columns["Number"] == null)
                {
                    DataGridViewTextBoxColumn numberCell = new DataGridViewTextBoxColumn()
                    {
                        Name = "Number",
                        HeaderText = "#",
                        DisplayIndex = 0,
                        Width = 20
                    };
                    gridPolaznici.Columns.Add(numberCell);
                }

                if (gridPolaznici.Columns["BodoviColumn"] == null)
                {
                    DataGridViewTextBoxColumn bodoviColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Bodovi (%)",
                        DisplayIndex = 3,
                        Name = "BodoviColumn"
                    };
                    gridPolaznici.Columns.Add(bodoviColumn);
                }

                foreach (DataGridViewRow row in gridPolaznici.Rows)
                {
                    row.Cells[gridPolaznici.Columns["Number"].Index].Value = row.Index + 1;

                    DataGridViewTextBoxCell bodoviCell = (DataGridViewTextBoxCell)row.Cells[gridPolaznici.Columns["BodoviColumn"].Index];
                    DataGridViewCell bodoviValue = row.Cells[gridPolaznici.Columns[nameof(IspitKlijentModel.Bodovi)].Index];
                    bodoviCell.Value = bodoviValue.Value;
                }

                gridPolaznici.Columns[nameof(IspitKlijentModel.ImeIPrezime)].DisplayIndex = 1;
                gridPolaznici.Columns[nameof(IspitKlijentModel.Prisustvovao)].DisplayIndex = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var postModel = new KlijentScoresModel
                    {
                        IspitId = this.model.Id,
                        KlijentPrisustvoScoreList = FillKlijentScoresList()
                    };
                    var result = await _ispitKlijentService.Insert<KlijentScoresModel>(postModel);
                    if (result != null)
                    {
                        MessageBox.Show("Operacija usješna.");
                        await LoadIspit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<KlijentIspitScore> FillKlijentScoresList()
        {
            var list = new List<KlijentIspitScore>();
            foreach (DataGridViewRow row in gridPolaznici.Rows)
            {
                int id = int.Parse(row.Cells[gridPolaznici.Columns[nameof(IspitKlijentModel.Id)].Index].Value.ToString());
                bool prisustvo = bool.Parse(row.Cells[gridPolaznici.Columns[nameof(IspitKlijentModel.Prisustvovao)].Index].Value.ToString());
                decimal? bodovi = null;
                var bodoviField = row.Cells[gridPolaznici.Columns["BodoviColumn"].Index].Value;
                if (bodoviField != null && !string.IsNullOrEmpty(bodoviField.ToString()))
                {
                    bodovi = decimal.Parse(bodoviField.ToString());
                }
                list.Add(new KlijentIspitScore { 
                    Bodovi = bodovi,
                    Id = id,
                    Prisustvo = prisustvo
                });
            }
            return list;
        }

        private async void btnPostavke_Click(object sender, EventArgs e)
        {
            var frmPostavke = new frmIspitDetail(instancaId, datePocetak, model.Id);
            var dialog = frmPostavke.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                await LoadIspit();
            }
        }

        private void gridPolaznici_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (gridPolaznici.Columns["BodoviColumn"] != null && e.ColumnIndex == gridPolaznici.Columns["BodoviColumn"].Index)
            {
                var value = e.FormattedValue.ToString();
                var parsed = decimal.TryParse(value, out decimal resultBodovi);
                bool prisustvo = bool.Parse(gridPolaznici.Rows[e.RowIndex].Cells[gridPolaznici.Columns[nameof(IspitKlijentModel.Prisustvovao)].Index].Value.ToString());
                if (!string.IsNullOrEmpty(value) && !parsed)
                {
                    gridPolaznici.Rows[e.RowIndex].ErrorText = "Nepravilan unos.";
                    errorProvider1.SetError(gridPolaznici, "Nepravilan unos u ćeliji sa bodovima.");
                    e.Cancel = true;
                }
                else if (!string.IsNullOrEmpty(value) && (resultBodovi < 0 || resultBodovi > 100))
                {
                    gridPolaznici.Rows[e.RowIndex].ErrorText = "Bodovi se kreću od 0 do 100.";
                    errorProvider1.SetError(gridPolaznici, "Bodovi u postotcima se kreću od minimalno 0 do maksimalno 100.");
                    e.Cancel = true;
                }
                else if (!string.IsNullOrEmpty(value) && !prisustvo)
                {
                    gridPolaznici.Rows[e.RowIndex].ErrorText = "Polje sa bodovima može biti popunjeno samo ako je klijent označen kao prisutan na ispitu.";
                    errorProvider1.SetError(gridPolaznici, "Klijent nije prisutan a ima unesene bodove.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(gridPolaznici, null);
                    gridPolaznici.Rows[e.RowIndex].ErrorText = null;
                }
            }
        }
    }
}
