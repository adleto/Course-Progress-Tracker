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
    public partial class frmTagovi : Form
    {
        private readonly ApiService _tagService = new ApiService("Tag");
        public frmTagovi()
        {
            InitializeComponent();
        }

        private async void frmTagovi_Load(object sender, EventArgs e)
        {
            var result = await _tagService.Get<List<TagModel>>(null);
            gridTagovi.DataSource = result;
            gridTagovi.Columns[nameof(TagModel.Id)].Visible = false;
        }

        private void gridTagovi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var idSelected = gridTagovi.SelectedRows[0].Cells[0].Value;
            var frm = new frmDetaljiTaga(int.Parse(idSelected.ToString()));
            frm.Show();
        }
    }
}
