using eCourse.Models.Kurs;
using eCourse.Models.KursInstanca;
using eCourse.Models.Tag;
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
    public partial class frmAddInstancaKursa : Form
    {
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca");
        private readonly ApiService _kursService = new ApiService("Kurs/GetKursevi");
        int? id = null;
        public frmAddInstancaKursa(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            txtCijena.Visible = false;
            txtKapacitet.Visible = false;
            labelCijena.Visible = false;
            labelKapacitet.Visible = false;
            checkImaCijenu.CheckStateChanged += CheckImaCijenu_CheckStateChanged;
            checkImaKapacitet.CheckStateChanged += CheckImaKapacitet_CheckStateChanged;
        }

        private void CheckImaKapacitet_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkImaKapacitet.Checked)
            {
                txtKapacitet.Visible = true;
                labelKapacitet.Visible = true;
            }
            else
            {
                txtKapacitet.Visible = false;
                labelKapacitet.Visible = false;
            }
        }

        private void CheckImaCijenu_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkImaCijenu.Checked)
            {
                txtCijena.Visible = true;
                labelCijena.Visible = true;
            }
            else
            {
                txtCijena.Visible = false;
                labelCijena.Visible = false;
            }
        }

        private void comboKurs_Validating(object sender, CancelEventArgs e)
        {
            try {
                var item = comboKurs.SelectedItem as KursModel;
                if(!int.TryParse(item.Id.ToString(), out int result))
                {
                    throw new Exception();
                }
                else
                {
                    errorProvider1.SetError(comboKurs, null);
                }
            }
            catch
            {
                errorProvider1.SetError(comboKurs, "Kurs mora biti odabran.");
                e.Cancel = true;
            }
        }

        private void datePocetak_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var item = datePocetak.Value;
                if (item.Date<DateTime.Now.Date)
                {
                    throw new Exception();
                }
                else
                {
                    errorProvider1.SetError(datePocetak, null);
                }
            }
            catch
            {
                errorProvider1.SetError(datePocetak, "Datum mora biti noviji ili jednak današnjem.");
                e.Cancel = true;
            }
        }

        private void datePrijave_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                var item = datePrijave.Value;
                var pocetak = datePocetak.Value;
                if (item.Date < DateTime.Now.Date || item.Date > pocetak.Date)
                {
                    throw new Exception();
                }
                else
                {
                    errorProvider1.SetError(datePrijave, null);
                }
            }
            catch
            {
                errorProvider1.SetError(datePrijave, "Datum mora biti noviji ili jednak današnjem i stariji od datuma početka.");
                e.Cancel = true;
            }
        }

        private void txtBrojCasova_Validating(object sender, CancelEventArgs e)
        {
            if (!int.TryParse(txtBrojCasova.Text, out int result) || result<=0)
            {
                errorProvider1.SetError(txtBrojCasova, "Broj časova mora biti unesen i veći od 0");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtBrojCasova, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (checkImaCijenu.CheckState == CheckState.Checked && (!decimal.TryParse(txtCijena.Text, out decimal result) || result <= 0))
            {
                errorProvider1.SetError(txtCijena, "Cijena mora biti unesena i veća od 0.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private void txtKapacitet_Validating(object sender, CancelEventArgs e)
        {
            if (checkImaKapacitet.CheckState == CheckState.Checked && (!int.TryParse(txtKapacitet.Text, out int result) || result <= 0))
            {
                errorProvider1.SetError(txtKapacitet, "Kapacitet mora biti unesen i veći od 0.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKapacitet, null);
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var selectedId = (comboKurs.SelectedItem as KursModel).Id;
                    var insertModel = new KursInstancaInsertModel
                    {
                        BrojCasova = int.Parse(txtBrojCasova.Text),
                        DatumPocetka = datePocetak.Value,
                        DatumPrijaveDo = datePrijave.Value,
                        KursId = selectedId
                    };
                    if (checkImaCijenu.Checked) insertModel.Cijena = int.Parse(txtCijena.Text);
                    if (checkImaKapacitet.Checked) insertModel.Kapacitet = int.Parse(txtKapacitet.Text);
                    var result = await _kursInstancaService.Insert<KursInstancaSimpleModel>(insertModel);
                    if (result != null)
                    {
                        MessageBox.Show("Operacija uspješna");
                        this.Close();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private async void frmAddInstancaKursa_Load(object sender, EventArgs e)
        {
            try {
                await LoadKursevi();
                if (id.HasValue)
                {
                    for(int index = 0; index < comboKurs.Items.Count; index++)
                    {
                        var item = comboKurs.Items[index] as KursModel;
                        if(item.Id == id)
                        {
                            comboKurs.SelectedIndex = index;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadKursevi()
        {
            try
            {
                var result = await _kursService.Insert<List<KursModel>>(new List<TagModel>());
                comboKurs.DisplayMember = nameof(KursModel.Naziv);
                comboKurs.ValueMember = nameof(KursModel.Id);
                comboKurs.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
