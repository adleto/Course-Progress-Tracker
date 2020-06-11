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

namespace eCourse.WinUI.Kursevi.Tagovi
{
    public partial class frmDetaljiTaga : Form
    {
        private int? id = null;
        private readonly ApiService _tagService = new ApiService("Tag");
        public frmDetaljiTaga(int? id = null)
        {
            InitializeComponent();
            this.id = id;
        }
        private async Task LoadTag()
        {
            try {
                var tag = await _tagService.GetById<TagModel>(id);
                textNaziv.Text = tag.Naziv;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textNaziv.Text))
            {
                errorProvider1.SetError(textNaziv, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textNaziv, null);
            }
        }

        private async void frmDetaljiTaga_Load(object sender, EventArgs e)
        {
            if (id != null)
            {
                await LoadTag();
            }
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                try {
                    TagModel result = null;
                    var model = new TagUpsertModel
                    {
                        Naziv = textNaziv.Text
                    };
                    if (id != null)
                    {
                        result = await _tagService.Update<TagModel>(id, model);
                    }
                    else
                    {
                        result = await _tagService.Insert<TagModel>(model);
                    }
                    if (result != null)
                    {
                        id = result.Id;
                        MessageBox.Show("Operacija uspješna.");
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
