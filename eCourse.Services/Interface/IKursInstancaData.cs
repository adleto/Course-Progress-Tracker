using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKursInstancaData
    {
        Task<List<KursInstancaForKlijentListViewModel>> GetInstance(int klijentId, KursInstancaDataFilter model);
        Task<List<KursInstancaForKlijentListViewModel>> GetRecommendedInstance(int klijentId);
        Task<KursDataModel> GetKursData(int instancaId, int klijentId);
        Task<KursDataModel> PrijaviSeZaKurs(int instancaId, int klijentId);
    }
}
