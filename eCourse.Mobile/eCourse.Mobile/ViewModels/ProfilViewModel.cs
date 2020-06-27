using eCourse.Mobile.Helpers;
using eCourse.Mobile.Service;
using eCourse.Models.Klijent;
using eCourse.Models.Opcina;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class ProfilViewModel : BaseViewModel
    {
        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        string lozinka = string.Empty;
        public string Lozinka
        {
            get { return lozinka; }
            set { SetProperty(ref lozinka, value); }
        }
        string lozinkaPotvrda = string.Empty;
        public string LozinkaPotvrda
        {
            get { return lozinkaPotvrda; }
            set { SetProperty(ref lozinkaPotvrda, value); }
        }
        OpcinaModel opcina = null;
        public OpcinaModel Opcina
        {
            get { return opcina; }
            set { SetProperty(ref opcina, value); }
        }
        bool errorLozinka_IsVisible = false;
        public bool ErrorLozinka_IsVisible
        {
            get { return errorLozinka_IsVisible; }
            set { SetProperty(ref errorLozinka_IsVisible, value); }
        }
        bool errorLozinkaPotvrda_IsVisible = false;
        public bool ErrorLozinkaPotvrda_IsVisible
        {
            get { return errorLozinkaPotvrda_IsVisible; }
            set { SetProperty(ref errorLozinkaPotvrda_IsVisible, value); }
        }
        bool errorEmail_IsVisible = false;
        public bool ErrorEmail_IsVisible
        {
            get { return errorEmail_IsVisible; }
            set { SetProperty(ref errorEmail_IsVisible, value); }
        }
        bool slikaDodataLabel = false;
        public bool SlikaDodataLabel
        {
            get { return slikaDodataLabel; }
            set { SetProperty(ref slikaDodataLabel, value); }
        }
        private byte[] slika = null;
        public byte[] Slika { 
            get { return slika; }
            set { SetProperty(ref slika, value);  }
        }
        private bool clanarinaAktivna = false;
        public bool ClanarinaAktivna
        {
            get { return clanarinaAktivna; }
            set { SetProperty(ref clanarinaAktivna, value); }
        }
        private string podaciOClanarini = "";
        public string PodaciOClanarini
        {
            get { 
                if (ClanarinaAktivna) return "Članarina: Aktivna";
                else return "Članarina: Neaktivna";
            }
            set
            {
                SetProperty(ref podaciOClanarini, value);
            }
        }
        private string clanarinaAktivnaDo = string.Empty;
        public string ClanarinaAktivnaDo
        {
            get { return clanarinaAktivnaDo; }
            set
            {
                SetProperty(ref clanarinaAktivnaDo, value);
            }
        }
        public ICommand AzurirajCommand;
        public ICommand DodajSlikuCommand;
        private readonly ApiService _opcinaService = new ApiService("Opcina");
        private readonly ApiService _korisnikService = new ApiService("KlijentData");
        public List<OpcinaModel> OpcinaList { get; set; }
        public ProfilViewModel()
        {
            AzurirajCommand = new Command(async () =>
            {
                try
                {
                    if (FormNotValid()) return;
                    var noviKorisnik = new KlijentDataUpdateModel
                    {
                        Email = Email,
                        OpcinaId = Opcina.Id
                    };
                    if (!string.IsNullOrEmpty(Lozinka))
                    {
                        noviKorisnik.Password = Lozinka;
                    }
                    if(Slika != null && Slika.Length > 0)
                    {
                        noviKorisnik.Slika = Slika;
                    }
                    var updatedKorisnik = await _korisnikService.Insert<KlijentDataDisplayModel>(noviKorisnik);
                    if (updatedKorisnik != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Ažuriranje podataka uspješno.", "OK");
                    }
                    else
                    {
                        throw new Exception("Došlo je do greške.");
                    }
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                }
            });
            DodajSlikuCommand = new Command(async () =>
            {
                try
                {
                    if (await AddImage())
                    {
                        SlikaDodataLabel = true;
                    }
                }
                catch
                {}
            });
        }

        private async Task<bool> AddImage()
        {
            Stream stream = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
            if (stream != null)
            {
                //image.Source = ImageSource.FromStream(() => stream);
                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    var byteSlika = ms.ToArray();
                    byte[] resizedImage = await DependencyService.Get<IMediaService>().ResizeImage(byteSlika, 100, 100);
                    Slika = resizedImage;
                }
                return true;
            }
            return false;
        }

        public async Task LoadData()
        {
            try
            {
                var korisnikData = await _korisnikService.Get<KlijentDataDisplayModel>(null);
                if (korisnikData == null) throw new Exception();
                Email = korisnikData.Email;
                Opcina = OpcinaList.Where(o => o.Id == korisnikData.OpcinaId).FirstOrDefault();
                if(korisnikData.Slika!=null && korisnikData.Slika.Length > 0)
                {
                    Slika = korisnikData.Slika;
                }
                ClanarinaAktivna = korisnikData.ClanarinaAktivna;
                if (ClanarinaAktivna)
                {
                    ClanarinaAktivnaDo = korisnikData.ClanarinaAktivnaDo;
                    PodaciOClanarini = "Refresh";
                }
            }
            catch { }
        }

        private bool FormNotValid()
        {
            bool errorsFound = false;
            if (string.IsNullOrEmpty(Email) || !IsValidEmail(Email))
            {
                errorsFound = true;
                ErrorEmail_IsVisible = true;
            }
            else
            {
                ErrorEmail_IsVisible = false;
            }
            if (!string.IsNullOrEmpty(Lozinka) && Lozinka.Length < 4)
            {
                errorsFound = true;
                ErrorLozinka_IsVisible = true;
            }
            else
            {
                ErrorLozinka_IsVisible = false;
            }
            if (!string.IsNullOrEmpty(Lozinka) && LozinkaPotvrda != Lozinka)
            {
                errorsFound = true;
                ErrorLozinkaPotvrda_IsVisible = true;
            }
            else
            {
                ErrorLozinkaPotvrda_IsVisible = false;
            }
            return errorsFound;
        }

        internal async Task GetOpcine()
        {
            try
            {
                OpcinaList = await _opcinaService.Get<List<OpcinaModel>>(null);
            }
            catch
            { }
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

}
