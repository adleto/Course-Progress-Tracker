using eCourse.Models.Cas;
using eCourse.Models.Ispit;
using eCourse.Models.Kurs;
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

namespace eCourse.WinUI.Kursevi.MojiKursevi.Ispit
{
    public partial class frmIspitView : Form
    {
        readonly int instancaId;
        private IspitProsireniModel model;
        private readonly ApiService _ispitService = new ApiService("Ispit");
        public frmIspitView(int instancaId)
        {
            InitializeComponent();
            this.instancaId = instancaId;
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
                        HeaderText = "",
                        DisplayIndex = 0
                    };
                    gridPolaznici.Columns.Add(numberCell);
                }

                if (gridPolaznici.Columns["BodoviColumn"] == null)
                {
                    DataGridViewTextBoxColumn bodoviColumn = new DataGridViewTextBoxColumn
                    {
                        HeaderText = "Bodovi (%)",
                        DisplayIndex = 3,
                        Name = "BodoviColumn",
                        ValueType = typeof(int)
                    };
                    gridPolaznici.Columns.Add(bodoviColumn);
                    //gridPolaznici.Validating += GridPolaznici_CellValidating;
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

        //private void GridPolaznici_CellValidating(object sender, CancelEventArgs e)
        //{
        //    if (e.ColumnIndex == gridPolaznici.Columns[nameof(IspitKlijentModel.Bodovi)].Index)
        //    {
        //        var value = e.FormattedValue.ToString();
        //        var parsed = !decimal.TryParse(value, out decimal resultBodovi);
        //        if (!string.IsNullOrEmpty(value) && !parsed)
        //        {
        //            errorProvider1.SetError(gridPolaznici, "Nepravilan unos u ćeliji sa bodovima.");
        //            e.Cancel = true;
        //        }
        //        else if (!string.IsNullOrEmpty(value) && (resultBodovi < 0 || resultBodovi > 100))
        //        {
        //            errorProvider1.SetError(gridPolaznici, "Bodovi u postotcima se kreću od minimalno 0 do maksimalno 100.");
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider1.SetError(gridPolaznici, null);
        //        }
        //    }
        //}

        //private void GridPolaznici_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        //{
        //    if(e.ColumnIndex == gridPolaznici.Columns[nameof(IspitKlijentModel.Bodovi)].Index)
        //    {
        //        var value = e.FormattedValue.ToString();
        //        var parsed = !decimal.TryParse(value, out decimal resultBodovi);
        //        if (!string.IsNullOrEmpty(value) && !parsed)
        //        {
        //            errorProvider1.SetError(gridPolaznici, "Nepravilan unos u ćeliji sa bodovima.");
        //            e.Cancel = true;
        //        }
        //        else if(!string.IsNullOrEmpty(value) && (resultBodovi <0 || resultBodovi > 100))
        //        {
        //            errorProvider1.SetError(gridPolaznici, "Bodovi u postotcima se kreću od minimalno 0 do maksimalno 100.");
        //            e.Cancel = true;
        //        }
        //        else
        //        {
        //            errorProvider1.SetError(gridPolaznici, null);
        //        }
        //    }
        //}

        private void btnSpremi_Click(object sender, EventArgs e)
        {
            //api patch request sa sviom datom, treba novi model class
        }

        private async void btnPostavke_Click(object sender, EventArgs e)
        {
            var frmPostavke = new frmIspitDetail(instancaId, model.Id);
            var dialog = frmPostavke.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                await LoadIspit();
            }
        }
    }
}
