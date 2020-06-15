using eCourse.Models.Ispit;
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
    public partial class frmIspitDetail : Form
    {
        private readonly int instancaId;
        int? ispitId = null;
        private readonly ApiService _ispitService = new ApiService("Ispit");
        public frmIspitDetail(int instancaId, int? ispitId = null)
        {
            InitializeComponent();
            this.instancaId = instancaId;
            this.ispitId = ispitId;
        }

        private async void frmIspitDetail_Load(object sender, EventArgs e)
        {
            if (ispitId.HasValue)
            {
                await LoadIspit();
            }
        }

        private async Task LoadIspit()
        {
            try
            {
                var result = await _ispitService.GetById<IspitModel>(ispitId);
                txtLokacija.Text = result.Lokacija;
                dateVrijeme.Value = result.DatumVrijemeIspita;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dateVrijeme_Validating(object sender, CancelEventArgs e)
        {
            if(dateVrijeme.Value < DateTime.Now.Date)
            {
                errorProvider1.SetError(dateVrijeme, "Ne može biti u prošlosti.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateVrijeme, null);
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

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try
                {
                    IspitModel result = null;
                    var request = new IspitUpsertModel
                    {
                        DatumVrijemeIspita = dateVrijeme.Value,
                        KursInstancaId = instancaId,
                        Lokacija = txtLokacija.Text
                    };
                    if(ispitId != null)
                    {
                        result = await _ispitService.Update<IspitModel>(ispitId, request);
                    }
                    else
                    {
                        result = await _ispitService.Insert<IspitModel>(request);
                    }
                    if (result != null)
                    {
                        MessageBox.Show("Operacija uspješna.");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
