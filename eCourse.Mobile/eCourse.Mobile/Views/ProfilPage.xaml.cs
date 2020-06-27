using eCourse.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eCourse.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        ProfilViewModel viewModel;
        public ProfilPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ProfilViewModel();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await viewModel.LoadData();
        }
    }
}