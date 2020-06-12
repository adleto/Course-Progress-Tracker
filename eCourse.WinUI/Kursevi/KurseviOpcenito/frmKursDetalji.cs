using eCourse.Models.Kurs;
using eCourse.Models.Tag;
using eCourse.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Kursevi.KurseviOpcenito
{
    public partial class frmKursDetalji : Form
    {
        private int? id = null;
        private readonly ApiService _kursService = new ApiService("Kurs");
        private readonly ApiService _tagService = new ApiService("Tag");
        public frmKursDetalji(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            listTagovi.CheckOnClick = true;
        }

        private async void frmKursDetalji_Load(object sender, EventArgs e)
        {
            await LoadTagovi();
            if (id != null) await LoadKurs((int)id);
        }
        private void popuniTagove(List<TagModel> checkaniTagovi)
        {
            checkaniTagovi.ForEach(t =>
            {
                for (int index = 0; index < listTagovi.Items.Count; index++)
                {
                    var itemAtIndex = listTagovi.Items[index] as TagModel;
                    if (t.Id == itemAtIndex.Id)
                    {
                        listTagovi.SetItemChecked(index, true);
                        break;
                    }
                }
            });
        }
        private async Task LoadKurs(int id)
        {
            try {
                var result = await _kursService.GetById<KursProsireniModel>(id);
                txtNaziv.Text = result.Naziv;
                txtOpis.Text = result.Opis;
                txtSkraceniNaziv.Text = result.SkraceniNaziv;
                popuniTagove(result.Tagovi);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadTagovi()
        {
            try
            {
                var result = await _tagService.Get<List<TagModel>>(null);
                result.ForEach(r => listTagovi.Items.Add(r));
                listTagovi.DisplayMember = nameof(TagModel.Naziv);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren())
                {
                    var insertModel = new KursProsireniModel
                    {
                        Naziv = txtNaziv.Text,
                        Opis = txtOpis.Text,
                        SkraceniNaziv = txtSkraceniNaziv.Text,
                        Tagovi = new List<TagModel>()
                    };
                    foreach(var selectedItem in listTagovi.CheckedItems)
                    {
                        var item = selectedItem as TagModel;
                        insertModel.Tagovi.Add(item);
                    }
                    KursProsireniModel result = null;
                    if (id != null)
                    {
                        result = await _kursService.Update<KursProsireniModel>(id, insertModel);
                    }
                    else
                    {
                        result = await _kursService.Insert<KursProsireniModel>(insertModel);
                        id = result.Id;
                    }
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

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                errorProvider1.SetError(txtNaziv, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtNaziv, null);
            }
        }

        private void txtSkraceniNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSkraceniNaziv.Text))
            {
                errorProvider1.SetError(txtSkraceniNaziv, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtSkraceniNaziv, null);
            }
        }

        private void txtOpis_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOpis.Text))
            {
                errorProvider1.SetError(txtOpis, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtOpis, null);
            }
        }
    }
}
