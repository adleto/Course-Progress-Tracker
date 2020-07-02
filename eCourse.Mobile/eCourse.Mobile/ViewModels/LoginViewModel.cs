using eCourse.Mobile.Service;
using eCourse.Mobile.Views;
using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private readonly ApiService _service = new ApiService("Auth/GetKlijent");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());
            RegisterPageCommand = new Command(async () => {
                //Application.Current.MainPage = new RegisterPage();
                await Navigation.PushModalAsync(new NavigationPage(new RegisterPage()));
            });
        }
        string _username = /*"mobile2";//*/string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = /*"mobile";//*/string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterPageCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Polja username i password moraju biti popunjena.", "OK");
                return;
            }
            ApiService.Username = Username;
            ApiService.Password = Password;

            try
            {
                var clanarinaAktivna = await _service.Get<ClanarinaModel>(null);
                Preferences.Set("ClanarinaAktivna", clanarinaAktivna.ClanarinaAktivna);
                Application.Current.MainPage = new MainPage();
            }
            catch
            {
            }
            IsBusy = false;
        }
    }
}
