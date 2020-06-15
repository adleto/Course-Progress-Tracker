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
    public partial class frmPostavkeInstance : Form
    {
        DateTime pocetak;
        DateTime prijaveDo;
        int? kapacitet;
        int minKapacitet;
        int kursInstancaId;
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca");

        public frmPostavkeInstance(int minKapacitet, DateTime pocetak, DateTime prijaveDo, int kursInstancaId, int? kapacitet=null)
        {
            InitializeComponent();
            this.pocetak = pocetak;
            this.prijaveDo = prijaveDo;
            this.kapacitet = kapacitet;
            this.kursInstancaId = kursInstancaId;
            this.minKapacitet = minKapacitet;

            datePocetak.Value = pocetak;
            datePrijaveDo.Value = prijaveDo;
            if (kapacitet != null) txtKapacitet.Text = kapacitet.ToString();
        }

        private void frmPostavkeInstance_Load(object sender, EventArgs e)
        {

        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    var updateModel = new KursInstancaUpdateModel
                    {
                        PocetakDatum = datePocetak.Value,
                        PrijaveDoDatum = datePrijaveDo.Value
                    };
                    if (int.TryParse(txtKapacitet.Text, out int kapacitet))
                    {
                        updateModel.Kapacitet = kapacitet;
                    }
                    var result = await _kursInstancaService.Update<KursInstancaSimpleModel>(kursInstancaId, updateModel);
                    if (result != null)
                    {
                        MessageBox.Show("Operacija upsješna");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void datePocetak_Validating(object sender, CancelEventArgs e)
        {
            if(datePocetak.Value.Date < DateTime.Now.Date)
            {
                errorProvider1.SetError(datePocetak, "Datum ne može biti u prošlosti.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(datePocetak, null);
            }
        }

        private void datePrijaveDo_Validating(object sender, CancelEventArgs e)
        {
            if (datePrijaveDo.Value.Date < DateTime.Now.Date)
            {
                errorProvider1.SetError(datePrijaveDo, "Datum ne može biti u prošlosti.");
                e.Cancel = true;
            }
            else if (datePrijaveDo.Value.Date > datePocetak.Value.Date)
            {
                errorProvider1.SetError(datePrijaveDo, "Rok ne može biti poslije početka kursa.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(datePrijaveDo, null);
            }
        }

        private void txtKapacitet_Validating(object sender, CancelEventArgs e)
        {
            var kapacitetUpisan = int.TryParse(txtKapacitet.Text, out int noviKapacitet);
            if (kapacitetUpisan && noviKapacitet<minKapacitet)
            {
                errorProvider1.SetError(txtKapacitet, $"Ne može biti manji od trenutnog broja upisanih studenata. ({minKapacitet})");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtKapacitet, null);
            }
        }
    }
}
