using eCourse.Models.Cas;
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
    public partial class frmCasDetalji : Form
    {
        int? casId = null;
        int kursInstancaId;
        private readonly ApiService _casService = new ApiService("Cas");
        public frmCasDetalji(int kursInstancaId, int? casId = null)
        {
            InitializeComponent();
            this.casId = casId;
            this.kursInstancaId = kursInstancaId;
        }

        private async void frmCasDetalji_Load(object sender, EventArgs e)
        {
            if (casId.HasValue)
            {
                await LoadCas();
            }
        }

        private async Task LoadCas()
        {
            try
            {
                var result = await _casService.GetById<CasModel>(casId);
                dateVrijeme.Value = result.DatumVrijemeOdrzavanja;
                txtLokacija.Text = result.Lokacija;
                txtOpis.Text = result.Opis;
                if (result.Odrzan)
                {
                    checkOdrzan.Checked = true;
                }
                else
                {
                    checkOdrzan.Checked = false;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    var model = new CasUpsertModel
                    {
                        DatumVrijemeOdrzavanja = dateVrijeme.Value,
                        KursInstancaId = kursInstancaId,
                        Lokacija = txtLokacija.Text,
                        Odrzan = checkOdrzan.Checked,
                        Opis = txtOpis.Text
                    };
                    CasModel result = null;
                    if (casId != null)
                    {
                        result = await _casService.Update<CasModel>(casId, model);
                    }
                    else
                    {
                        result = await _casService.Insert<CasModel>(model);
                    }
                    if (result != null)
                    {
                        casId = result.Id; //Ionako ide close ali ukoliko bude promijena trebalo nešto drugo neka ostane
                        MessageBox.Show("Operacija uspješna");
                        this.DialogResult = DialogResult.OK;
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtLokacija_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLokacija.Text))
            {
                errorProvider1.SetError(txtLokacija, "Polje ne može biti prazno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtLokacija, null);
            }
        }

        private void dateVrijeme_Validating(object sender, CancelEventArgs e)
        {
            if (dateVrijeme.Value.Date < DateTime.Now.Date)
            {
                errorProvider1.SetError(dateVrijeme, "Ne može biti prije današnjeg datuma.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateVrijeme, null);
            }
        }
    }
}
