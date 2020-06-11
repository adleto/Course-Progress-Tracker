using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.Models.Opcina;
using eCourse.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI.Osoblje
{
    public partial class frmUposlenikDetalji : Form
    {
        private int? _id = null;
        private readonly ApiService _osobljeService = new ApiService("Osoblje");
        private readonly ApiService _ulogeService = new ApiService("Role");
        private readonly ApiService _opcinaService = new ApiService("Opcina");
        private byte[] img = null;
        public frmUposlenikDetalji(int? userId = null)
        {
            InitializeComponent();
            _id = userId;
        }

        private async void btnPotvrdi_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateChildren()
                    && int.TryParse(comboUloga.SelectedValue.ToString(), out int idUloga)
                    && int.TryParse(comboOpcina.SelectedValue.ToString(), out int idOpcina))
                {
                    var person = new OsobljeInsertModel
                    {
                        DatumRodjenja = dateRodjenja.Value,
                        Email = txtEmail.Text,
                        DatumZaposlenja = dateZaposlenja.Value,
                        Ime = txtIme.Text,
                        JMBG = txtJMBG.Text,
                        Password = txtLozinka.Text,
                        PasswordConfirm = txtLozinkaPonovo.Text,
                        Prezime = txtPrezime.Text,
                        Username = txtUsername.Text,
                        ApplicationUserRoles = new List<RoleModel>
                        {
                            new RoleModel
                            {
                                Id = idUloga
                            }
                        },
                        OpcinaId = idOpcina
                    };
                    if (img != null)
                    {
                        person.Slika = img;
                    }
                    if (radioDaAktivan.Checked)
                    {
                        person.Active = true;
                    }
                    else
                    {
                        person.Active = false;
                    }
                    if (radioM.Checked)
                    {
                        person.Spol = "M";
                    }
                    else if (radioZ.Checked)
                    {
                        person.Spol = "Z";
                    }
                    else
                    {
                        person.Spol = "Drugi";
                    }
                    OsobljeModel result = null;
                    if(_id == null) {
                        result = await _osobljeService.Insert<OsobljeModel>(person);
                    }
                    else
                    {
                        //map insert to update model
                        var updateModel = new OsobljeUpdateModel
                        {
                            Active = person.Active,
                            ApplicationUserRoles = person.ApplicationUserRoles,
                            DatumRodjenja = person.DatumRodjenja,
                            DatumZaposlenja = person.DatumZaposlenja,
                            Email = person.Email,
                            Ime = person.Ime,
                            JMBG = person.JMBG,
                            OpcinaId = person.OpcinaId,
                            Password = person.Password,
                            PasswordConfirm = person.PasswordConfirm,
                            Prezime = person.Prezime,
                            Slika = person.Slika,
                            Spol = person.Spol,
                            Username = person.Username
                        };
                        result = await _osobljeService.Update<OsobljeModel>(_id, updateModel);
                        txtUsername.Text = result.Username;
                    }
                    if (result != null) {
                        MessageBox.Show("Uspješno obavljena operacija.");
                        _id = result.Id;
                    }
                }
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void frmUposlenikDetalji_Load(object sender, EventArgs e)
        {
            await LoadOpcine();
            await LoadUloge();
            if (_id.HasValue)
            {
                try
                {
                    var uposlenik = await _osobljeService.GetById<OsobljeModel>(_id);

                    dateRodjenja.Value = uposlenik.DatumRodjenja;
                    txtEmail.Text = uposlenik.Email;
                    dateZaposlenja.Value = uposlenik.DatumZaposlenja;
                    txtIme.Text = uposlenik.Ime;
                    txtPrezime.Text = uposlenik.Prezime;
                    txtUsername.Text = uposlenik.Username;
                    txtJMBG.Text = uposlenik.JMBG;
                    if(uposlenik.Slika != null && uposlenik.Slika.Length > 0)
                    {
                        Image i = null;
                        using (var ms = new MemoryStream(uposlenik.Slika))
                        {
                            i = Image.FromStream(ms);
                        }
                        if (i != null)
                        {
                            pictureSlika.Image = i;
                        }
                    }
                    if (uposlenik.Active) radioDaAktivan.Checked = true;
                    else radioNeAktivan.Checked = true;
                    if (uposlenik.Spol == "M") radioM.Checked = true;
                    else if (uposlenik.Spol == "Z") radioZ.Checked = true;
                    else radioDrugi.Checked = true;

                    comboOpcina.SelectedValue = uposlenik.OpcinaId;
                    comboUloga.SelectedValue = uposlenik.Role[0].Id;
                }
                catch(ApiException ex)
                {
                    if(ex.HttpStatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        MessageBox.Show("Error: Uposlenik nije pronađen u bazi podataka.");
                    }
                }
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || txtUsername.Text.Length < 4)
            {
                errorProvider.SetError(txtUsername, "Username mora imati najmanje 4 karaktera.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtIme.Text))
            {
                errorProvider.SetError(txtIme, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrezime.Text))
            {
                errorProvider.SetError(txtPrezime, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                new System.Net.Mail.MailAddress(txtEmail.Text);
                errorProvider.SetError(txtEmail, null);
            }
            catch
            {
                errorProvider.SetError(txtEmail, "Polje mora biti ispravno popunjeno.");
                e.Cancel = true;
            }
        }

        private void txtJMBG_Validating(object sender, CancelEventArgs e)
        {
            if (
                    string.IsNullOrEmpty(txtJMBG.Text) || 
                    txtJMBG.Text.Length != 13 || 
                    !(new System.Text.RegularExpressions.Regex(@"^[0-9]+$")).IsMatch(txtJMBG.Text)
                )
            {
                errorProvider.SetError(txtJMBG, "Polje mora biti ispravno popunjeno. (13 cifara)");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtJMBG, null);
            }
        }

        private void txtLozinka_Validating(object sender, CancelEventArgs e)
        {
            if(_id != null)
            {
                errorProvider.SetError(txtLozinka, null);
            }
            else if (string.IsNullOrEmpty(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinka, "Polje mora biti popunjeno.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLozinka, null);
            }
        }

        private void txtLozinkaPonovo_Validating(object sender, CancelEventArgs e)
        {
            if (_id != null && string.IsNullOrEmpty(txtLozinka.Text))
            {
                errorProvider.SetError(txtLozinkaPonovo, null);
            }
            else if (txtLozinka.Text != txtLozinkaPonovo.Text)
            {
                errorProvider.SetError(txtLozinkaPonovo, "Polje mora biti popunjeno i jednako lozinci.");
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(txtLozinkaPonovo, null);
            }
        }

        private async Task LoadUloge()
        {
            try {
                var result = await _ulogeService.Get<List<RoleModel>>(null);
                result.Remove(result[2]);
                comboUloga.DisplayMember = "Naziv";
                comboUloga.ValueMember = "Id";
                comboUloga.DataSource = result;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async Task LoadOpcine()
        {
            try {
                var result = await _opcinaService.Get<List<OpcinaModel>>(null);
            
                comboOpcina.DisplayMember = "Naziv";
                comboOpcina.ValueMember = "Id";
                comboOpcina.DataSource = result;
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOdaberiSliku_Click(object sender, EventArgs e)
        {
            try { 
                var result = openFileDialog1.ShowDialog();
                if(result == DialogResult.OK)
                {
                    var fileName = openFileDialog1.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        var file = File.ReadAllBytes(fileName);
                        txtSlikaPath.Text = fileName;

                        Image image = Image.FromFile(fileName);
                        Image thumb = image.GetThumbnailImage(100, 100, null, new System.IntPtr());
                        pictureSlika.Image = thumb;

                        //convert thumb to byte so you upload thumbs only
                        ImageConverter _imageConverter = new ImageConverter();
                        byte[] xByte = (byte[])_imageConverter.ConvertTo(thumb, typeof(byte[]));

                        img = xByte;
                    }
                }
            }
            catch 
            {
                MessageBox.Show("Neispravna slika odabrana.");
            }
        }
    }
}
