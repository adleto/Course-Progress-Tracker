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
    public partial class KursPage : ContentPage
    {
        KursViewModel viewModel;
        public KursPage(int instancaId)
        {
            InitializeComponent();
            BindingContext = viewModel = new KursViewModel(instancaId);
            viewModel.Navigation = Navigation;
        }
    }
}