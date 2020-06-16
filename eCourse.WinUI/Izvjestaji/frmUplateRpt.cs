using eCourse.Models.ApplicationUser;
using eCourse.Models.Uplata;
using eCourse.WinUI.Service;
using Microsoft.Reporting.WinForms;
using Microsoft.Reporting.WinForms.Internal.Soap.ReportingServices2005.Execution;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Izvjestaji
{
    public partial class frmUplateRpt : Form
    {
        private readonly ApiService _uplataService = new ApiService("Uplata/GetReport");
        private readonly ApiService _klijentService = new ApiService("Klijent/GetKlijentiSimple");
        public frmUplateRpt()
        {
            InitializeComponent();
            dateOd.Value = DateTime.Today.AddYears(-20);
            dateDo.Value = DateTime.Now.AddDays(1);
        }

        private async void frmUplateRpt_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadKlijenti();
                await LoadReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task LoadReport()
        {
            List<UplataModel> result = await LoadUplate();
            ReportDataSource rds = new ReportDataSource("dataSetUplataDetails", result);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            if (result.Count > 0)
            {
                this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Total", result.Sum(r=>r.Iznos).ToString()));
            }
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DateOd", dateOd.Value.ToString("dd/MM/yyyy")));
            this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("DateDo", dateDo.Value.ToString("dd/MM/yyyy")));

            this.reportViewer1.RefreshReport();
        }

        private async Task LoadKlijenti()
        {
            var result = await _klijentService.Get<List<KlijentSimpleModel>>(null);
            result.Insert(0, new KlijentSimpleModel
            {
                ImeIPrezime = "",
                KlijentId = 0
            });
            comboKlijent.ValueMember = nameof(KlijentSimpleModel.KlijentId);
            comboKlijent.DisplayMember = nameof(KlijentSimpleModel.ImeIPrezime);
            comboKlijent.DataSource = result;
        }

        private async Task<List<UplataModel>> LoadUplate()
        {
            var queryModel = new UplataFilterModel
            {
                Do = dateDo.Value,
                Od = dateOd.Value
            };
            if (comboKlijent.SelectedIndex != 0)
            {
                queryModel.KlijentId = int.Parse(comboKlijent.SelectedValue.ToString());
            }
            var result = await _uplataService.Insert<List<UplataModel>>(queryModel);
            return result;
        }

        private async void btnFiltriraj_Click(object sender, EventArgs e)
        {
            await LoadReport();
        }
    }
}
