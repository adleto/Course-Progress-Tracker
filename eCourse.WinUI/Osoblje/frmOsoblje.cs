using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Osoblje
{
    public partial class frmOsoblje : Form
    {
        private readonly ApiService _osobljeService = new ApiService("Osoblje");
        public frmOsoblje()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await LoadOsoblje(txtIme.Text, txtPrezime.Text);
        }

        private async void frmOsoblje_Load(object sender, EventArgs e)
        {
            await LoadOsoblje();
        }
        private async Task LoadOsoblje(string ime = null, string prezime = null)
        {
            try 
            {
                UserSearchRequestModel searchRequest = null;
                if (ime != null || prezime != null)
                {
                    searchRequest = new UserSearchRequestModel
                    {
                        Ime = ime,
                        Prezime = prezime
                    };
                }
                gridOsoblje.RowTemplate.Height = 100;
                var result = await _osobljeService.Get<List<OsobljeModel>>(searchRequest);
                gridOsoblje.DataSource = result;
                gridOsoblje.Columns[nameof(OsobljeModel.Id)].Visible = false;
                gridOsoblje.Columns[nameof(OsobljeModel.OpcinaId)].Visible = false;
                gridOsoblje.Columns[nameof(OsobljeModel.UposlenikId)].Visible = false;
                gridOsoblje.Columns[nameof(OsobljeModel.OpcinaNaziv)].HeaderText = "Općina";
                gridOsoblje.Columns[nameof(OsobljeModel.DatumRodjenja)].HeaderText = "Datum Rodjenja";
                gridOsoblje.Columns[nameof(OsobljeModel.DatumZaposlenja)].HeaderText = "Datum Zaposlenja";

                gridOsoblje.Columns[nameof(OsobljeModel.Id)].DisplayIndex = 0;
                gridOsoblje.Columns[nameof(OsobljeModel.Ime)].DisplayIndex = 1;
                gridOsoblje.Columns[nameof(OsobljeModel.Prezime)].DisplayIndex = 2;
                gridOsoblje.Columns[nameof(OsobljeModel.Username)].DisplayIndex = 3;
                gridOsoblje.Columns[nameof(OsobljeModel.Email)].DisplayIndex = 4;
                gridOsoblje.Columns[nameof(OsobljeModel.DatumRodjenja)].DisplayIndex = 5;
                gridOsoblje.Columns[nameof(OsobljeModel.OpcinaNaziv)].DisplayIndex = 6;
                gridOsoblje.Columns[nameof(OsobljeModel.Spol)].DisplayIndex = 7;
                gridOsoblje.Columns[nameof(OsobljeModel.JMBG)].DisplayIndex = 8;
                gridOsoblje.Columns[nameof(OsobljeModel.DatumZaposlenja)].DisplayIndex = 9;
                gridOsoblje.Columns[nameof(OsobljeModel.Active)].DisplayIndex = 10;
                gridOsoblje.Columns[nameof(OsobljeModel.Slika)].DisplayIndex = 11;
                gridOsoblje.Columns[nameof(OsobljeModel.UposlenikId)].DisplayIndex = 12;
                gridOsoblje.Columns[nameof(OsobljeModel.OpcinaId)].DisplayIndex = 13;
                //gridOsoblje.Columns[nameof(OsobljeModel.Role)].DisplayIndex = 1;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridOsoblje_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //3 is index of cell with id
            var idSelected = gridOsoblje.SelectedRows[0].Cells[3].Value;
            var frm = new frmUposlenikDetalji(int.Parse(idSelected.ToString()));
            frm.Show();
        }
    }
}
