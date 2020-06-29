using eCourse.Mobile.Service;
using eCourse.Mobile.ViewModels;
using eCourse.Models.Cas;
using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
        private readonly ApiService _rejtingService = new ApiService("KursInstancaData/OstaviRejting");
        public INavigation Navigation { get; set; }
        public ICommand InitCommand { get; set; }
        public ICommand PrijavaCommand { get; set; }
        public ICommand OstaviRejtingCommand { get; set; }
        private int _instancaId;
        public KursViewModel(int instancaId)
        {
            _instancaId = instancaId;
            InitCommand = new Command(async () => await Init());
            PrijavaCommand = new Command(async () => await PrijaviSe());
            OstaviRejtingCommand = new Command(async () =>
            {
                try
                {
                    if (Ocjena == null) return;
                    int? i = await _rejtingService.Insert<int?>(new RejtingModel
                    {
                        InstancaId = _instancaId,
                        Rejting = (int)Ocjena
                    });
                    if (i != null) Ocjena = i;
                }
                catch { }
            });
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
                Ocjena = model.Ocjena;

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
                DatumPocetka = model.DatumPocetka;
                DatumKraja = model.DatumKraja;
                Zavrsen = model.Zavrsen;

                LokacijaIspit = model.LokacijaIspit;
                VrijemeIspit = model.VrijemeIspit;
                IspitPoeni = model.IspitPoeni;
                PrisustvovoIspitu = model.PrisustvovoIspitu;

                PrikaziNadolazeciIspit = false;
                PrikaziZavrsenIspit = false;
                PrikaziNadolazeciIspit = false;
                ImaPrisustvoNaIspitu = false;
                NemaPrisustvoNaIspitu = false;
                if (VrijemeIspit != null)
                {
                    if(PrisustvovoIspitu != null)
                    {
                        if ((bool)PrisustvovoIspitu) ImaPrisustvoNaIspitu = true;
                        else NemaPrisustvoNaIspitu = true;
                        PrikaziZavrsenIspit = true;
                    }
                    else
                    {
                        PrikaziNadolazeciIspit = true;
                    }
                }

                Polozen = model.Polozen;

                var zavrseniCasovi = model.Casovi
                    .Where(c => c.Odrzan == true)
                    .OrderByDescending(c => c.DatumVrijemeOdrzavanja)
                    .ToList();
                var neodrzaniCasovi = model.Casovi
                    .Where(c => c.Odrzan == false)
                    .OrderByDescending(c => c.DatumVrijemeOdrzavanja)
                    .ToList();
                Progres = zavrseniCasovi.Count / BrojCasova;
                NadolazeciList = new ObservableCollection<CasModel>(neodrzaniCasovi);
                OdrzaniList = new ObservableCollection<CasModel>(zavrseniCasovi);

                MozeOstavitOcjenu = false;
                if (PrijavljenIAktivan || Zavrsen) MozeOstavitOcjenu = true;
            }
            catch { }
        }
        //PROPS ARE HERE
        private ObservableCollection<CasModel> nadolazeciList = null;
        public ObservableCollection<CasModel> NadolazeciList { get { return nadolazeciList; } set { SetProperty(ref nadolazeciList, value); } }
        private ObservableCollection<CasModel> odrzaniList = null;
        public ObservableCollection<CasModel> OdrzaniList { get { return odrzaniList; } set { SetProperty(ref odrzaniList, value); } }
        private string naziv;
        public string Naziv { get { return naziv;  } set { SetProperty(ref naziv, value); } }
        private string predavac;
        public string Predavac { get { return predavac; } set { SetProperty(ref predavac, value); } }
        private string opis;
        public string Opis { get { return opis; } set { SetProperty(ref opis, value); } }
        private string lokacijaIspit;
        public string LokacijaIspit { get { return lokacijaIspit; } set { SetProperty(ref lokacijaIspit, value); } }
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
        private decimal? ispitPoeni;
        public decimal? IspitPoeni { get { return ispitPoeni; } set { SetProperty(ref ispitPoeni, value); } }
        private bool prikaziCijenu;
        public bool PrikaziCijenu { get { return prikaziCijenu; } set { SetProperty(ref prikaziCijenu, value); } }
        private DateTime datumPrijaveDo;
        public DateTime DatumPrijaveDo { get { return datumPrijaveDo; } set { SetProperty(ref datumPrijaveDo, value); } }
        private DateTime datumPocetka;
        public DateTime DatumPocetka { get { return datumPocetka; } set { SetProperty(ref datumPocetka, value); } }
        private DateTime? datumKraja;
        public DateTime? DatumKraja { get { return datumKraja; } set { SetProperty(ref datumKraja, value); } }
        private DateTime? vrijemeIspit;
        public DateTime? VrijemeIspit { get { return vrijemeIspit; } set { SetProperty(ref vrijemeIspit, value); } }
        private bool error_PrijavaNijeMoguca;
        public bool Error_PrijavaNijeMoguca { get { return error_PrijavaNijeMoguca; } set { SetProperty(ref error_PrijavaNijeMoguca, value); } }
        private bool zavrsen;
        public bool Zavrsen { get { return zavrsen; } set { SetProperty(ref zavrsen, value); } }
        private bool prikaziNadolazeciIspit;
        public bool PrikaziNadolazeciIspit { get { return prikaziNadolazeciIspit; } set { SetProperty(ref prikaziNadolazeciIspit, value); } }
        private bool prikaziZavrsenIspit;
        public bool PrikaziZavrsenIspit { get { return prikaziZavrsenIspit; } set { SetProperty(ref prikaziZavrsenIspit, value); } }
        private bool nemaPrisustvoNaIspitu;
        public bool NemaPrisustvoNaIspitu { get { return nemaPrisustvoNaIspitu; } set { SetProperty(ref nemaPrisustvoNaIspitu, value); } }
        private bool imaPrisustvoNaIspitu;
        public bool ImaPrisustvoNaIspitu { get { return imaPrisustvoNaIspitu; } set { SetProperty(ref imaPrisustvoNaIspitu, value); } }
        private bool? prisustvovoIspitu;
        public bool? PrisustvovoIspitu { get { return prisustvovoIspitu; } set { SetProperty(ref prisustvovoIspitu, value); } }
        private bool? polozen;
        public bool? Polozen { get { return polozen; } set { SetProperty(ref polozen, value); } }
        public bool? NijePolozen { get { return !polozen; } }
        private float progres;
        public float Progres { get { return progres; } set { SetProperty(ref progres, value); } }
        public string Progres_Value { get { return (progres * 100).ToString("F0"); }  }
        private int? ocjena;
        public int? Ocjena { get { return ocjena; } set { SetProperty(ref ocjena, value); } }
        private bool mozeOstavitOcjenu;
        public bool MozeOstavitOcjenu { get { return mozeOstavitOcjenu; } set { SetProperty(ref mozeOstavitOcjenu, value); } }
        //PROPS END
    }
}
