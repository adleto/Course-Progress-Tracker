using eCourse.Models.Cas;
using eCourse.Models.KursInstanca;
using eCourse.WinUI.Helpers;
using eCourse.WinUI.Klijenti;
using eCourse.WinUI.Kursevi.MojiKursevi.Ispit;
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
    public partial class frmInstanca : Form
    {
        readonly int id;
        MojaKursInstancaProsireniModel instanca = null;
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca");
        private readonly ApiService _casService = new ApiService("Cas");
        public frmInstanca(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private async void frmInstanca_Load(object sender, EventArgs e)
        {
            await LoadKurs();
        }

        private async Task LoadKurs()
        {
            try
            {
                var result = await _kursInstancaService.GetById<MojaKursInstancaProsireniModel>(id);
                instanca = result;
                labelNazivKursa.Text = $"Kurs: { result.KursNaziv}";
                if (result.Pocetak.Date > DateTime.Now.Date)
                {
                    labelDatumPocetka.Text = $"Počinje: {result.Pocetak.Date.ToString("dd/MM/yyyy")}";
                }
                else
                {
                    labelDatumPocetka.Text = $"Započeo: {result.Pocetak.Date.ToString("dd/MM/yyyy")}";
                }
                if (result.PrijaveDo > DateTime.Now.Date)
                {
                    labelPrijaveDo.Text = $"Rok za prijave: {result.Pocetak.Date.ToString("dd/MM/yyyy")}";
                }
                else
                {
                    labelPrijaveDo.Text = $"Prijave: Završene";
                }
                if(result.KrajDate != null)
                {
                    btnPostavke.Enabled = false;
                    labelZavrsio.Visible = true;
                    labelZavrsio.Text = $"Završio: {result.KrajDate}";
                    btnUgovoriCas.Visible = false;
                    btnZavrsiKurs.Visible = false;
                    if (result.IspitOrganizovan)
                    {
                        btnOrganizujIspit.Visible = true;
                        btnOrganizujIspit.Text = "Pregled ispita";
                    }
                    else
                    {
                        btnOrganizujIspit.Visible = false;
                    }
                    labelStatus.Text = "Kurs završen";
                }
                else
                {
                    if (instanca.Pocetak.Date <= DateTime.Now)
                    {
                        btnPostavke.Enabled = false;
                    }
                    else
                    {
                        btnPostavke.Enabled = true;
                    }
                    labelZavrsio.Visible = false;
                    if(instanca.BrojCasova == instanca.Casovi.Count())
                    {
                        btnUgovoriCas.Visible = false;
                    }
                    else
                    {
                        btnUgovoriCas.Visible = true;
                    }
                    btnZavrsiKurs.Visible = true;
                    btnOrganizujIspit.Visible = true;
                    if (result.IspitOrganizovan)
                    {
                        
                        btnOrganizujIspit.Text = "Pregled ispita";
                    }
                    else
                    {
                        btnOrganizujIspit.Text = "Organizuj ispit iz ovog kursa";
                    }
                    if(result.PrijaveDo.Date > DateTime.Now.Date)
                    {
                        labelStatus.Text = "Prijave u toku";
                    }
                    else
                    {
                        labelStatus.Text = "Prijave završene - Kurs aktivan";
                    }
                }
                if(result.BrojCasova <= result.Casovi.Count)
                {
                    btnUgovoriCas.Enabled = false;
                }
                else
                {
                    btnUgovoriCas.Enabled = true;
                }
                labelStudenataNaKursu.Text = $"Broj klijenta na kursu: {result.BrojKlijenata}";
                labelOdrzanoCasova.Text = $"Održano časova: {result.Casovi.Count}";
                labelUkupnoCasova.Text = $"Ukupno časova: {result.BrojCasova}";

                LoadCasovi(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCasovi(MojaKursInstancaProsireniModel result)
        {
            gridCasovi.DataSource = result.Casovi;
            gridCasovi.Columns[nameof(CasModel.Id)].Visible = false;
            gridCasovi.Columns[nameof(CasModel.Opis)].Visible = false;
            gridCasovi.Columns[nameof(CasModel.Odrzan)].Visible = false;
            gridCasovi.Columns[nameof(CasModel.DatumVrijemeOdrzavanja)].HeaderText = "Vrijeme održavanja";
            gridCasovi.Columns[nameof(CasModel.DatumVrijemeOdrzavanja)].DisplayIndex = 1;
            gridCasovi.Columns[nameof(CasModel.Lokacija)].DisplayIndex = 2;

            //below is header cell for each row with count number
            if (gridCasovi.Columns["Number"] == null)
            {
                DataGridViewTextBoxColumn numberCell = new DataGridViewTextBoxColumn()
                {
                    Name = "Number",
                    HeaderText = "",
                    DisplayIndex = 0
                };
                gridCasovi.Columns.Add(numberCell);
            }

            if (gridCasovi.Columns["Akcija"] == null)
            {
                MyDataGridViewButtonColumn buttonColumn = new MyDataGridViewButtonColumn()
                {
                    Name = "Akcija",
                    HeaderText = "Akcija",
                    Text = "Označi kao održan",
                    UseColumnTextForButtonValue = true
                };
                gridCasovi.CellClick += gridCasovi_OdrzanButton_CellClick;
                gridCasovi.Columns.Add(buttonColumn);
            }
            gridCasovi.Columns["Akcija"].DisplayIndex = 3;

            foreach (DataGridViewRow row in gridCasovi.Rows)
            {
                row.Cells[gridCasovi.Columns["Number"].Index].Value = gridCasovi.Rows.Count - row.Index - 1;

                MyDataGridViewButtonCell buttonCell = (MyDataGridViewButtonCell)row.Cells[gridCasovi.Columns["Akcija"].Index];
                bool odrzan = bool.Parse((row.Cells[gridCasovi.Columns[nameof(CasModel.Odrzan)].Index].Value).ToString());
                if (odrzan)
                {
                    buttonCell.Enabled = false;
                }
                else
                {
                    buttonCell.Enabled = true;
                }
            }
        }

        private async void gridCasovi_OdrzanButton_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            {
                if (e.ColumnIndex == gridCasovi.Columns["Akcija"].Index)
                {
                    var selectedCasRow = gridCasovi.Rows[e.RowIndex];
                    DateTime dateOdrzavanja = (DateTime)selectedCasRow.Cells[gridCasovi.Columns[nameof(CasModel.DatumVrijemeOdrzavanja)].Index].Value;
                    var model = new CasUpsertModel
                    {
                        DatumVrijemeOdrzavanja = dateOdrzavanja,
                        KursInstancaId = id,
                        Lokacija = selectedCasRow.Cells[gridCasovi.Columns[nameof(CasModel.Lokacija)].Index].Value.ToString(),
                        Opis = selectedCasRow.Cells[gridCasovi.Columns[nameof(CasModel.Opis)].Index].Value.ToString(),
                        Odrzan = true
                    };
                    int casId = (int)selectedCasRow.Cells[gridCasovi.Columns[nameof(CasModel.Id)].Index].Value;
                    var result = await _casService.Update<CasModel>(casId, model);
                    if (result != null)
                    {
                        await LoadKurs();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnPostavke_Click(object sender, EventArgs e)
        {
            var frm = new frmPostavkeInstance(instanca.BrojKlijenata, instanca.Pocetak, instanca.PrijaveDo, instanca.KursInstancaId, instanca.Kapacitet);
            DialogResult dialog = frm.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                await LoadKurs();
            }
        }

        private void btnPregledajKlijente_Click(object sender, EventArgs e)
        {
            var frm = new frmKlijenti(id);
            frm.Show();
        }

        private async void btnZavrsiKurs_Click(object sender, EventArgs e)
        {
            bool poloziliSvi = false;
            if(instanca.BrojCasova > instanca.Casovi.Where(c => c.Odrzan == true).Count())
            {
                var confirmResult = MessageBox.Show("Svi časovi nisu održani. Da li i dalje želite završiti ovaj kurs?",
                    "Upozorenje",
                    MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    var confirmResult2 = MessageBox.Show("Da li želite označiti kurs kao položen za sve klijente iako je završen ranije?",
                    "Upozorenje",
                    MessageBoxButtons.YesNo);
                    if(confirmResult2 == DialogResult.Yes)
                    {
                        poloziliSvi = true;
                    }
                }
                else
                {
                    return;
                }
            }
            var result = await _kursInstancaService.UpdatePatch<KursInstancaSimpleModel>(id, poloziliSvi);
            if (result != null)
            {
                await LoadKurs();
                MessageBox.Show("Operacija uspješna.");
            }
        }

        private async void btnUgovoriCas_Click(object sender, EventArgs e)
        {
            var frmNoviCas = new frmCasDetalji(id);
            var dialog = frmNoviCas.ShowDialog();
            if(dialog == DialogResult.OK)
            {
                await LoadKurs();
            }
        }

        private async void gridCasovi_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int casId = (int)gridCasovi.SelectedRows[0].Cells[gridCasovi.Columns[nameof(CasModel.Id)].Index].Value;
            var frmCasEdit = new frmCasDetalji(id, casId);
            var dialog = frmCasEdit.ShowDialog();
            if (dialog == DialogResult.OK)
            {
                await LoadKurs();
            }
        }

        private async void btnOrganizujIspit_Click(object sender, EventArgs e)
        {
            if (instanca.IspitOrganizovan)
            {
                var frm = new frmIspitView(id);
                frm.Show();
            }
            else
            {
                var frm = new frmIspitDetail(id);
                var dialog = frm.ShowDialog();
                if(dialog == DialogResult.OK)
                {
                    await LoadKurs();
                }
            }
        }
    }
}
