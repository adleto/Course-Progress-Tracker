using eCourse.Models.Kurs;
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

namespace eCourse.WinUI.Kursevi.KurseviOpcenito
{
    public partial class frmKursevi : Form
    {
        private readonly ApiService _tagService = new ApiService("Tag");
        private readonly ApiService _kursService = new ApiService("Kurs/GetKursevi");
        public frmKursevi()
        {
            InitializeComponent();
            listTagovi.CheckOnClick = true;
        }

        private async void frmKursevi_Load(object sender, EventArgs e)
        {
            await LoadTags();
            await LoadKursevi();
        }
        private async Task LoadTags()
        {
            try {
                var result = await _tagService.Get<List<TagModel>>(null);
                result.ForEach(r => listTagovi.Items.Add(r));
                listTagovi.DisplayMember = nameof(TagModel.Naziv);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadKursevi()
        {
            try
            {
                var listTags = new List<TagModel>();
                foreach(var tag in listTagovi.CheckedItems)
                {
                    var t = tag as TagModel;
                    listTags.Add(t);
                }
                // This below is not an insert. It's safer send big requests via body rather then in url
                // Maybe this one is not big but anyway
                var result = await _kursService.Insert<List<KursModel>>(listTags);

                gridKursevi.DataSource = result;
                gridKursevi.Columns[nameof(KursModel.Naziv)].Width = 400;
                gridKursevi.Columns[nameof(KursModel.SkraceniNaziv)].HeaderText = "Skraćeni naziv";
                gridKursevi.Columns[nameof(KursModel.Id)].Visible = false;
                gridKursevi.Columns[nameof(KursModel.Opis)].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void butonFiltriraj_Click(object sender, EventArgs e)
        {
            await LoadKursevi();
        }

        private void gridKursevi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var idSelected = gridKursevi.SelectedRows[0].Cells[0].Value;
            var frm = new frmKursDetalji(int.Parse(idSelected.ToString()));
            frm.Show();
        }
    }
}
