using eCourse.Mobile.Service;
using eCourse.Models.Klijent;
using eCourse.Models.Tag;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class KatalogViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        private ObservableCollection<KursInstancaForKlijentListViewModel> preporuceniList = new ObservableCollection<KursInstancaForKlijentListViewModel>();
        public ObservableCollection<KursInstancaForKlijentListViewModel> PreporuceniList
        {
            get { return preporuceniList; }
            set { SetProperty(ref preporuceniList, value); }
        }
        private ObservableCollection<KursInstancaForKlijentListViewModel> ponudaList = new ObservableCollection<KursInstancaForKlijentListViewModel>();
        public ObservableCollection<KursInstancaForKlijentListViewModel> PonudaList
        {
            get { return ponudaList; }
            set { SetProperty(ref ponudaList, value); }
        }
        private ObservableCollection<TagModel> tagList = new ObservableCollection<TagModel>();
        public ObservableCollection<TagModel> TagList
        {
            get { return tagList; }
            set { SetProperty(ref tagList, value); }
        }
        public ICommand FiltrirajCommand { get; set; }
        public ICommand LoadTagsCommand { get; set; }
        public ICommand LoadPreporuceniCommand { get; set; }
        private string pretraga = string.Empty;
        public string Pretraga
        {
            get { return pretraga; }
            set { SetProperty(ref pretraga, value); }
        }
        private TagModel tag = new TagModel
        {
            Id = 0,
            Naziv = "Bez filtera"
        };
        public TagModel Tag
        {
            get { return tag; }
            set { SetProperty(ref tag, value); }
        }
        private int katalogHeight = 14;
        public int KatalogHeight
        {
            get { return katalogHeight; }
            set { SetProperty(ref katalogHeight, value); }
        }
        private readonly ApiService _tagService = new ApiService("Tag");
        private readonly ApiService _instancaService = new ApiService("KursInstancaData");
        private readonly ApiService _recommenderService = new ApiService("KursInstancaData/GetRecommended");
        public KatalogViewModel()
        {
            LoadTagsCommand = new Command(async () =>
            {
                await LoadTags();
            });
            FiltrirajCommand = new Command(async () =>
            {
                await LoadData();
            });
            LoadPreporuceniCommand = new Command(async () =>
            {
                await LoadPreporuceni();
            });
            LoadTagsCommand.Execute(null);
            FiltrirajCommand.Execute(null);
            LoadPreporuceniCommand.Execute(null);
        }

        private async Task LoadPreporuceni()
        {
            try
            {
                var result = await _recommenderService.Get<List<KursInstancaForKlijentListViewModel>>(null);
                PreporuceniList = new ObservableCollection<KursInstancaForKlijentListViewModel>(result);
            }
            catch { }
        }

        private async Task LoadTags()
        {
            try
            {
                var result = await _tagService.Get<List<TagModel>>(null);
                TagList = new ObservableCollection<TagModel>(result);
                TagList.Insert(0, new TagModel
                {
                    Id = 0,
                    Naziv = "Filter po tagu"
                });
            }
            catch { }
        }
        private async Task LoadData()
        {
            try
            {
                var filter = new KursInstancaDataFilter
                {
                    GetSve = true,
                    GetMojiAktivni = false,
                    GetMojiUspjesnoZavrseni = false,
                    GetMojiZavrseni = false,
                    Pretraga = null,
                    TagId = null
                };
                if (!string.IsNullOrEmpty(Pretraga))
                {
                    filter.Pretraga = Pretraga;
                }
                if (Tag != null && Tag.Id != 0)
                {
                    filter.TagId = Tag.Id;
                }
                var result = await _instancaService.Get<List<KursInstancaForKlijentListViewModel>>(filter);
                PonudaList = new ObservableCollection<KursInstancaForKlijentListViewModel>(result);
                KatalogHeight = result.Count * 14;
            }
            catch { }
        }
    }
}
