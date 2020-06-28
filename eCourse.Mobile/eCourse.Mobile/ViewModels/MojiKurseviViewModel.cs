using eCourse.Mobile.Service;
using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class MojiKurseviViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<MyType> TypeList { get; } = new ObservableCollection<MyType>
        {
            new MyType
            {
                MyTypeEnum = MyTypeEnum.MojiAktivni,
                Naziv = "Aktivni kursevi"
            },
            new MyType
            {
                MyTypeEnum = MyTypeEnum.MojiZavrseni,
                Naziv = "Završeni kursevi"
            },
            new MyType
            {
                MyTypeEnum = MyTypeEnum.MojiUspjesnoZavrseni,
                Naziv = "Položeni kursevi"
            }
        };

        private ObservableCollection<KursInstancaForKlijentListViewModel> kurseviList = new ObservableCollection<KursInstancaForKlijentListViewModel>();
        public ObservableCollection<KursInstancaForKlijentListViewModel> KurseviList
        {
            get { return kurseviList; }
            set { SetProperty(ref kurseviList, value); }
        }
        public ICommand FiltrirajCommand { get; set; }
        private string pretraga = string.Empty;
        public string Pretraga
        {
            get { return pretraga; }
            set { SetProperty(ref pretraga, value); }
        }
        private MyType myType = new MyType
        {
            MyTypeEnum = MyTypeEnum.MojiAktivni,
            Naziv = "Aktivni kursevi"
        };
        public MyType MyType
        {
            get { return myType; }
            set { SetProperty(ref myType, value); }
        }
        private int katalogHeight = 14;
        public int KatalogHeight
        {
            get { return katalogHeight; }
            set { SetProperty(ref katalogHeight, value); }
        }
        private readonly ApiService _instancaService = new ApiService("KursInstancaData");
        public MojiKurseviViewModel()
        {
            FiltrirajCommand = new Command(async () =>
            {
                await LoadData();
            });
            FiltrirajCommand.Execute(null);
        }
        private async Task LoadData()
        {
            try
            {
                var filter = new KursInstancaDataFilter
                {
                    GetSve = false,
                    GetMojiAktivni = false,
                    GetMojiUspjesnoZavrseni = false,
                    GetMojiZavrseni = false,
                    Pretraga = null,
                    TagId = null
                };
                if (MyType.MyTypeEnum == MyTypeEnum.MojiAktivni) filter.GetMojiAktivni = true;
                else if (MyType.MyTypeEnum == MyTypeEnum.MojiUspjesnoZavrseni) filter.GetMojiUspjesnoZavrseni = true;
                else if (MyType.MyTypeEnum == MyTypeEnum.MojiZavrseni) filter.GetMojiZavrseni = true;
                if (!string.IsNullOrEmpty(Pretraga))
                {
                    filter.Pretraga = Pretraga;
                }
                var result = await _instancaService.Get<List<KursInstancaForKlijentListViewModel>>(filter);
                KurseviList = new ObservableCollection<KursInstancaForKlijentListViewModel>(result);
                KatalogHeight = result.Count * 14;
            }
            catch { }
        }
    }
    public class MyType
    {
        public MyTypeEnum MyTypeEnum { get; set; }
        public string Naziv { get; set; }
    }
    public enum MyTypeEnum
    {
        MojiZavrseni,
        MojiAktivni,
        MojiUspjesnoZavrseni
    }
}
