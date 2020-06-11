using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.Models.KlijentKursInstanca;
using eCourse.Models.TipUplate;
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
    public partial class frmUplataDetalji : Form
    {
        private int? Id = null;
        private readonly ApiService _tipUplateService = new ApiService("TipUplate");
        private readonly ApiService _klijentService = new ApiService("Klijent/GetKlijentiSimple");
        private readonly ApiService _klijentKursInstancaService = new ApiService("KlijentKursInstanca/GetForUplata");
        private readonly ApiService _uplataService = new ApiService("Uplata");
        public frmUplataDetalji(int? id = null)
        {
            InitializeComponent();
            this.Id = id;

            labelForKursInstance.Visible = false;
            comboKursInstancaKlijenta.Visible = false;
            labelCijenaKursa.Visible = false;
        }

        private void textIznos_Validating(object sender, CancelEventArgs e)
        {
            var tip = comboTip.SelectedItem as TipUplateModel;
            var iznos = decimal.TryParse(textIznos.Text, out decimal result);
            var selectedKurs = comboKursInstancaKlijenta.SelectedItem as KlijentKursInstancaForUplataModel;

            if (!iznos)
            {
                errorProvider1.SetError(textIznos, "Iznos nije pravilno unesen.");
                e.Cancel = true;
            }
            else if (tip.Cijena != null && result < tip.Cijena)
            {
                errorProvider1.SetError(textIznos, "Iznos ne može biti manji od cijene članarine.");
                e.Cancel = true;
            }
            else if (selectedKurs !=null && result != selectedKurs.Cijena)
            {
                errorProvider1.SetError(textIznos, "Uplata za kurs mora biti jednaka cijeni kursa.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textIznos, null);
            }
        }

        private async void frmUplataDetalji_Load(object sender, EventArgs e)
        {
            await LoadTipUplate();
            await LoadKlijenti();
            if (Id != null)
            {
                comboKlijent.SelectedValue = Id;
            }
        }
        private async Task LoadKlijenti()
        {
            try
            {
                var result = await _klijentService.Get<List<KlijentSimpleModel>>(null);
                comboKlijent.DisplayMember = nameof(KlijentSimpleModel.NazivSaDatumom);
                comboKlijent.ValueMember = nameof(KlijentSimpleModel.KlijentId);
                comboKlijent.DataSource = result;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadTipUplate()
        {
            try
            {
                var result = await _tipUplateService.Get<List<TipUplateModel>>(null);
                result.Insert(0, new TipUplateModel
                {
                    Naziv = "",
                    TipUplateId = -1
                });
                comboTip.DisplayMember = nameof(TipUplateModel.PuniNaziv);
                comboTip.ValueMember = nameof(TipUplateModel.TipUplateId);
                comboTip.DataSource = result;

                var m = comboTip.SelectedItem as TipUplateModel;
                await InitKursInstancaCombo(m);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboTip_Validating(object sender, CancelEventArgs e)
        {
            if (comboTip.SelectedValue == null || comboTip.SelectedValue.ToString() == "-1")
            {
                errorProvider1.SetError(comboTip, "Tip uplate mora biti odabran.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboTip, null);
            }
        }
        private async Task LoadKlijentKursInstance()
        {
            try
            {
                var id = comboKlijent.SelectedValue.ToString();
                var result = await _klijentKursInstancaService.GetById<List<KlijentKursInstancaForUplataModel>>(id);
                if (result.Count == 0) MessageBox.Show("Klijent nije prijavio niti jedan kurs koji zahtjeva uplatu.");
                result.Add(new KlijentKursInstancaForUplataModel
                {
                    NazivInstance = "",
                    Cijena = -1,
                    KlijentKursInstancaId = -1
                });
                comboKursInstancaKlijenta.DisplayMember = nameof(KlijentKursInstancaForUplataModel.NazivInstance);
                comboKursInstancaKlijenta.ValueMember = nameof(KlijentKursInstancaForUplataModel.KlijentKursInstancaId);
                comboKursInstancaKlijenta.DataSource = result;

                if(comboKursInstancaKlijenta.SelectedValue.ToString() == "-1")
                {
                    SetCijenaLabel();
                }
                else
                {
                    var item = comboKursInstancaKlijenta.SelectedItem as KlijentKursInstancaForUplataModel;
                    SetCijenaLabel(item.Cijena.ToString());
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetCijenaLabel(string cijena = null)
        {
            if (string.IsNullOrEmpty(cijena) || cijena == "-1")
            {
                labelCijenaKursa.Text = "";
            }
            else
            {
                labelCijenaKursa.Visible = true;
                labelCijenaKursa.Text = "Cijena ovog kursa je: " + cijena + "KM";
            }
        }
        private async Task InitKursInstancaCombo(TipUplateModel m)
        {
            if (m.TipUplateId == 1)
            {
                comboKursInstancaKlijenta.Visible = true;
                labelForKursInstance.Visible = true;
                await LoadKlijentKursInstance();
            }
            else
            {
                SetCijenaLabel();
                comboKursInstancaKlijenta.Visible = false;
                labelForKursInstance.Visible = false;
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    var uplataInsertModel = new UplataInsertModel
                    {
                        Iznos = decimal.Parse(textIznos.Text),
                        KlijentId = int.Parse(comboKlijent.SelectedValue.ToString()),
                        TipUplate = int.Parse(comboTip.SelectedValue.ToString())
                    };
                    var m = comboKursInstancaKlijenta.SelectedItem as KlijentKursInstancaForUplataModel;
                    if(m != null && m.KlijentKursInstancaId != -1)
                    {
                        uplataInsertModel.KursInstancaKlijentId = m.KlijentKursInstancaId;
                    }
                    var uplata = await _uplataService.Insert<UplataSimpleModel>(uplataInsertModel);
                    if (uplata != null)
                    {
                        MessageBox.Show("Uplata dodata.");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void comboTip_SelectedValueChanged(object sender, EventArgs e)
        {
            var m = comboTip.SelectedItem as TipUplateModel;
            if(m!=null)
                await InitKursInstancaCombo(m);
        }

        private void comboKursInstancaKlijenta_SelectedValueChanged(object sender, EventArgs e)
        {
            var m = comboKursInstancaKlijenta.SelectedItem as KlijentKursInstancaForUplataModel;
            if(m!=null)
                SetCijenaLabel(m.Cijena.ToString());
        }

        private void comboKursInstancaKlijenta_Validating(object sender, CancelEventArgs e)
        {
            if (comboTip.SelectedValue.ToString() == "1")
            {
                var selectedKurs = comboKursInstancaKlijenta.SelectedItem as KlijentKursInstancaForUplataModel;
                if(selectedKurs == null || selectedKurs.KlijentKursInstancaId == -1)
                {
                    errorProvider1.SetError(comboKursInstancaKlijenta, "Kurs mora biti odabran.");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(comboKursInstancaKlijenta, null);
                }
            }
            else
            {
                errorProvider1.SetError(comboKursInstancaKlijenta, null);
            }
        }
    }
}
