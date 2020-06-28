﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using eCourse.Mobile.Views;
using eCourse.Mobile.Service;

namespace eCourse.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            ApiService.Username = "mobile2";
            ApiService.Password = "mobile";
            MainPage = new MainPage();
            //MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
