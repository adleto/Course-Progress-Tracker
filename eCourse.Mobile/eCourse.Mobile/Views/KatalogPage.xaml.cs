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
    public partial class KatalogPage : ContentPage
    {
        KatalogViewModel viewModel;
        public KatalogPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new KatalogViewModel();
            viewModel.Navigation = Navigation;
        }
    }
}