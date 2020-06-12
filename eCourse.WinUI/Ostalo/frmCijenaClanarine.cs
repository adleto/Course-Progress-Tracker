using eCourse.Models.TipUplate;
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

namespace eCourse.WinUI.Ostalo
{
    public partial class frmCijenaClanarine : Form
    {
        private readonly ApiService _tipUplateService = new ApiService("TipUplate");
        private readonly ApiService _clanarinaService = new ApiService("TipUplate/SetCijenaClanarine");
        private int? id = null;
        public frmCijenaClanarine()
        {
            InitializeComponent();
        }

        private async void frmCijenaClanarine_Load(object sender, EventArgs e)
        {
            await LoadCijena();
        }
        private async Task LoadCijena()
        {
            try
            {
                var result = await _tipUplateService.Get<List<TipUplateModel>>(null);
                foreach(var r in result)
                {
                    if(r.Naziv == "Članarina")
                    {
                        txtCijena.Text = r.Cijena.ToString();
                        id = r.TipUplateId;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCijena.Text) || !decimal.TryParse(txtCijena.Text, out decimal result) || result <= 0)
            {
                errorProvider1.SetError(txtCijena, "Polje mora biti popunjeno i ne smije biti manje ili jednako nula.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtCijena, null);
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren() && id != null)
                {
                    var result = await _clanarinaService.Update<TipUplateModel>(id, decimal.Parse(txtCijena.Text));
                    if (result != null)
                    {
                        MessageBox.Show("Operacija uspješna.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
