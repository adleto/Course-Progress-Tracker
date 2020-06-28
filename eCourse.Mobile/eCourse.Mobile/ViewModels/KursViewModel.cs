using eCourse.Mobile.Service;
using eCourse.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class KursViewModel : BaseViewModel
    {
        private readonly ApiService _prijavaService = new ApiService("KursInstancaData/PrijaviSeZaKurs");
        private readonly ApiService _kursService = new ApiService("KursInstancaData/GetKursData");
        public INavigation Navigation { get; set; }
    }
}
