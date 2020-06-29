using eCourse.Mobile.Service;
using eCourse.Mobile.ViewModels;
using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class KursViewModel : BaseViewModel
    {
        private readonly ApiService _prijavaService = new ApiService("KursInstancaData/PrijaviSeZaKurs");
        private readonly ApiService _kursService = new ApiService("KursInstancaData/GetKursData");
        public INavigation Navigation { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand PrijavaCommand { get; set; }
        private int _instancaId;
        public KursViewModel(int instancaId)
        {
            _instancaId = instancaId;
            InitCommand = new Command(async () => await Init());
            PrijavaCommand = new Command(async () => await PrijaviSe());
            InitCommand.Execute(null);
        }
        private async Task Init()
        {
            try
            {
                var result = await _kursService.Get<KursDataModel>(new { instancaId = _instancaId });
                Setup(result);
            }
            catch { }
        }
        private async Task PrijaviSe()
        {
            try
            {
                if (Cijena == null)
                {
                    var clanarinaAktivna = Preferences.Get("ClanarinaAktivna", false);
                    if (!clanarinaAktivna)
                    {
                        Error_PrijavaNijeMoguca = true;
                        return;
                    }
                }
                var result = await _prijavaService.Insert<KursDataModel>(_instancaId);
                Setup(result);
            }
            catch { }
        }
        private void Setup(KursDataModel model)
        {
            try
            {
                Naziv = model.Naziv;
                Predavac = model.Predavac;
                Opis = model.Opis;
                Kapacitet = model.Kapacitet;
                BrojCasova = model.BrojCasova;
                ImaKapacitet = (Kapacitet!=null);
                PrikaziKapacitet = false;
                PrikaziCijenu = false;
                Cijena = model.Cijena;

                PrijavljenAliNeUplacen = model.PrijavljenAliNeUplacen;
                NijePrijavljen = model.NijePrijavljen;
                PrijavljenIAktivan = model.PrijavljenIAktivan;

                if(ImaKapacitet && NijePrijavljen)
                {
                    PrikaziKapacitet = true;
                }
                if(Cijena!=null && (NijePrijavljen || PrijavljenAliNeUplacen))
                {
                    PrikaziCijenu = true;
                }
                DatumPrijaveDo = model.DatumPrijaveDo;
            }
            catch { }
        }
        //PROPS ARE HERE
        private string naziv;
        public string Naziv { get { return naziv;  } set { SetProperty(ref naziv, value); } }
        private string predavac;
        public string Predavac { get { return predavac; } set { SetProperty(ref predavac, value); } }
        private string opis;
        public string Opis { get { return opis; } set { SetProperty(ref opis, value); } }
        private int? kapacitet;
        public int? Kapacitet { get { return kapacitet; } set { SetProperty(ref kapacitet, value); } }
        private bool imaKapacitet;
        public bool ImaKapacitet { get { return imaKapacitet; } set { SetProperty(ref imaKapacitet, value); } }
        private bool prikaziKapacitet;
        public bool PrikaziKapacitet { get { return prikaziKapacitet; } set { SetProperty(ref prikaziKapacitet, value); } }
        private bool nijePrijavljen;
        public bool NijePrijavljen { get { return nijePrijavljen; } set { SetProperty(ref nijePrijavljen, value); } }
        private bool prijavljenIAktivan;
        public bool PrijavljenIAktivan { get { return prijavljenIAktivan; } set { SetProperty(ref prijavljenIAktivan, value); } }
        private bool prijavljenAliNeUplacen;
        public bool PrijavljenAliNeUplacen { get { return prijavljenAliNeUplacen; } set { SetProperty(ref prijavljenAliNeUplacen, value); } }
        private int brojCasova;
        public int BrojCasova { get { return brojCasova; } set { SetProperty(ref brojCasova, value); } }
        private decimal? cijena;
        public decimal? Cijena { get { return cijena; } set { SetProperty(ref cijena, value); } }
        private bool prikaziCijenu;
        public bool PrikaziCijenu { get { return prikaziCijenu; } set { SetProperty(ref prikaziCijenu, value); } }
        private DateTime datumPrijaveDo;
        public DateTime DatumPrijaveDo { get { return datumPrijaveDo; } set { SetProperty(ref datumPrijaveDo, value); } }
        private bool error_PrijavaNijeMoguca;
        public bool Error_PrijavaNijeMoguca { get { return error_PrijavaNijeMoguca; } set { SetProperty(ref error_PrijavaNijeMoguca, value); } }
        //PROPS END
    }
}
