using eCourse.Mobile.Service;
using eCourse.Models.Uplata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eCourse.Mobile.ViewModels
{
    public class UplateViewModel : BaseViewModel
    {
        public UplateViewModel()
        {
            DatumOd = DateTime.Now.AddYears(-10);
            DatumDo = DateTime.Now.AddDays(1);
            FiltrirajUplateCommand = new Command(async () => {
                await GetUplate();
            });
            FiltrirajUplateCommand.Execute(null);
        }
        public ICommand FiltrirajUplateCommand { get; set; }
        private readonly ApiService _uplataService = new ApiService("Uplata/GetForKlijent");
        private ObservableCollection<UplataModel> uplateList = new ObservableCollection<UplataModel>();
        public ObservableCollection<UplataModel> UplateList
        {
            get
            {
                return uplateList;
            }
            set
            {
                if (uplateList != value)
                {
                    SetProperty(ref uplateList, value);
                }
            }
        }
        private DateTime datumOd;

        public DateTime DatumOd
        {
            get { return datumOd; }
            set { SetProperty(ref datumOd, value); }
        }
        private DateTime datumDo;

        public DateTime DatumDo
        {
            get { return datumDo; }
            set { SetProperty(ref datumDo, value); }
        }


        public async Task GetUplate()
        {
            try
            {
                var result = await _uplataService.Get<List<UplataModel>>(new { datumOd = DatumOd, datumDo = DatumDo });
                if (result != null) {
                    result = result.OrderByDescending(r => r.DatumUplate).ToList();
                    UplateList = new ObservableCollection<UplataModel>(result);
                }
            }
            catch { }
        }
    }
}
