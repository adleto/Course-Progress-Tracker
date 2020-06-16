using eCourse.Models.KursInstanca;
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
    public partial class frmKursRpt : Form
    {
        private readonly ApiService _kursInstancaService = new ApiService("KursInstanca/GetReport");
        public frmKursRpt()
        {
            InitializeComponent();
            this.dateDo.Value = DateTime.Now.AddYears(10);
            this.dateOd.Value = DateTime.Now.AddYears(-20);
            var list = new List<int> { 5, 10, 15, 20, 30, 50, 100 };
            comboBroj.DataSource = list;
        }

        private async void frmKursRpt_Load(object sender, EventArgs e)
        {
            await LoadReport();
        }

        private async Task LoadReport()
        {
            try
            {
                List<MojaKursInstancaForReport> result = await LoadKursevi();
                ReportDataSource rds = new ReportDataSource("dataSetKursDetails", result);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                if (result.Count > 0)
                {
                    this.reportViewer1.LocalReport.SetParameters(new Microsoft.Reporting.WinForms.ReportParameter("Total", result.Sum(r => r.BrojKlijenata).ToString()));
                }

                this.reportViewer1.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task<List<MojaKursInstancaForReport>> LoadKursevi()
        {
            var queryModel = new KursInstancaFilter
            {
                DateDo = dateDo.Value,
                DateOd = dateOd.Value,
                
            };
            if(comboBroj.SelectedValue != null)
            {
                queryModel.TakeThisMany = (int)comboBroj.SelectedValue;
            }
            else
            {
                var isBroj = int.TryParse(comboBroj.Text.ToString(), out int broj);
                if (isBroj) queryModel.TakeThisMany = broj;
                else queryModel.TakeThisMany = 5;
            }
            var result = await _kursInstancaService.Insert<List<MojaKursInstancaForReport>>(queryModel);
            return result;
        }

        private async void btnFiltriraj_Click(object sender, EventArgs e)
        {
            await LoadReport();
        }
    }
}
