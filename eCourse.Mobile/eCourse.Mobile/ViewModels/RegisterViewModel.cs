using eCourse.Mobile.Service;
using eCourse.Mobile.Views;
using eCourse.Models.ApplicationUser;
using eCourse.Models.Opcina;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly ApiService _userService = new ApiService("Auth");
        private readonly ApiService _opcinaService = new ApiService("Opcina");
        public ObservableCollection<OpcinaModel> OpcinaList = null;
        public INavigation Navigation;
        public RegisterViewModel()
        {
            RegisterCommand = new Command(async () => {
                try
                {
                    if (FormNotValid()) return;
                    var noviKorisnik = new ApplicationUserInsertModel
                    {
                        DatumRodjenja = DatumRodjenja,
                        Email = Email,
                        Ime = Ime,
                        JMBG = JMBG,
                        OpcinaId = Opcina.Id,
                        Password = Password,
                        PasswordConfirm = PasswordConfirm,
                        Prezime = Prezime,
                        Spol = Spol,
                        Username = Username
                    };
                    var korisnik = await _userService.Insert<KlijentModel>(noviKorisnik);
                    if (korisnik != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("", "Uspješno ste izvršili registraciju, sada se možete logirati.", "OK");
                        Application.Current.MainPage = new LoginPage();
                    }
                }
                catch(Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "OK");
                }
            });
        }

        private bool FormNotValid()
        {
            bool errorsFound = false;
            if(string.IsNullOrEmpty(Username) || Username.Length < 4)
            {
                errorsFound = true;
                ErrorKorisnickoIme_IsVisible = true;
            }
            else
            {
                ErrorKorisnickoIme_IsVisible = false;
            }
            if (string.IsNullOrEmpty(Ime))
            {
                errorsFound = true;
                ErrorIme_IsVisible = true;
            }
            else
            {
                ErrorIme_IsVisible = false;
            }
            if (string.IsNullOrEmpty(Prezime))
            {
                errorsFound = true;
                ErrorPrezime_IsVisible = true;
            }
            else
            {
                ErrorPrezime_IsVisible = false;
            }
            if (string.IsNullOrEmpty(Email) || !IsValidEmail(Email))
            {
                errorsFound = true;
                ErrorEmail_IsVisible = true;
            }
            else
            {
                ErrorEmail_IsVisible = false;
            }
            if (DatumRodjenja.Date>=DateTime.Now.Date)
            {
                errorsFound = true;
                ErrorDatum_IsVisible = true;
            }
            else
            {
                ErrorDatum_IsVisible = false;
            }
            if (string.IsNullOrEmpty(JMBG) || JMBG.Length>13 || JMBG.Length<13 || !JMBG.All(Char.IsDigit))
            {
                errorsFound = true;
                ErrorJMBG_IsVisible = true;
            }
            else
            {
                ErrorJMBG_IsVisible = false;
            }
            if (string.IsNullOrEmpty(Password) || Password.Length < 4)
            {
                errorsFound = true;
                ErrorLozinka_IsVisible = true;
            }
            else
            {
                ErrorLozinka_IsVisible = false;
            }
            if (string.IsNullOrEmpty(PasswordConfirm) || PasswordConfirm != Password)
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
        internal async Task GetOpcine()
        {
            try
            {
                var result = await _opcinaService.Get<List<OpcinaModel>>(null);
                OpcinaList = new ObservableCollection<OpcinaModel>(result);
            }
            catch
            { }
        }

        public ICommand RegisterCommand { get; set; }
        string username = string.Empty;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }
        string ime = string.Empty;
        public string Ime
        {
            get { return ime; }
            set { SetProperty(ref ime, value); }
        }
        string prezime = string.Empty;
        public string Prezime
        {
            get { return prezime; }
            set { SetProperty(ref prezime, value); }
        }
        string email = string.Empty;
        public string Email
        {
            get { return email; }
            set { SetProperty(ref email, value); }
        }
        DateTime datumRodjenja = DateTime.Now.Date;
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { SetProperty(ref datumRodjenja, value); }
        }
        OpcinaModel opcina = null;
        public OpcinaModel Opcina
        {
            get { return opcina; }
            set { SetProperty(ref opcina, value); }
        }
        string jmbg = string.Empty;
        public string JMBG
        {
            get { return jmbg; }
            set { SetProperty(ref jmbg, value); }
        }
        string spol = string.Empty;
        public string Spol
        {
            get { return spol; }
            set { SetProperty(ref spol, value); }
        }
        string password = string.Empty;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }
        string passwordConfirm = string.Empty;
        public string PasswordConfirm
        {
            get { return passwordConfirm; }
            set { SetProperty(ref passwordConfirm, value); }
        }
        bool errorKorisnickoIme_IsVisible = false;
        public bool ErrorKorisnickoIme_IsVisible
        {
            get { return errorKorisnickoIme_IsVisible; }
            set { SetProperty(ref errorKorisnickoIme_IsVisible, value); }
        }
        bool errorIme_IsVisible = false;
        public bool ErrorIme_IsVisible
        {
            get { return errorIme_IsVisible; }
            set { SetProperty(ref errorIme_IsVisible, value); }
        }
        bool errorPrezime_IsVisible = false;
        public bool ErrorPrezime_IsVisible
        {
            get { return errorPrezime_IsVisible; }
            set { SetProperty(ref errorPrezime_IsVisible, value); }
        }
        bool errorEmail_IsVisible = false;
        public bool ErrorEmail_IsVisible
        {
            get { return errorEmail_IsVisible; }
            set { SetProperty(ref errorEmail_IsVisible, value); }
        }
        bool errorDatum_IsVisible = false;
        public bool ErrorDatum_IsVisible
        {
            get { return errorDatum_IsVisible; }
            set { SetProperty(ref errorDatum_IsVisible, value); }
        }
        bool errorJMBG_IsVisible = false;
        public bool ErrorJMBG_IsVisible
        {
            get { return errorJMBG_IsVisible; }
            set { SetProperty(ref errorJMBG_IsVisible, value); }
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

        public ObservableCollection<string> SpolList = new ObservableCollection<string> { "M", "Z", "Other" };
    }
}
