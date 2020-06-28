using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using eCourse.Mobile.Models;

namespace eCourse.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Katalog, (NavigationPage)Detail); //bio samo browse znaci ovdje samo first page?
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Katalog:
                        MenuPages.Add(id, new NavigationPage(new KatalogPage()));
                        break;
                    case (int)MenuItemType.MojiKursevi:
                        MenuPages.Add(id, new NavigationPage(new MojiKurseviPage()));
                        break;
                    case (int)MenuItemType.Uplate:
                        MenuPages.Add(id, new NavigationPage(new UplatePage()));
                        break;
                    case (int)MenuItemType.Profil:
                        MenuPages.Add(id, new NavigationPage(new ProfilPage()));
                        break;
                    case (int)MenuItemType.Logout:
                        MenuPages.Add(id, new NavigationPage(new LogoutRedirectPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}