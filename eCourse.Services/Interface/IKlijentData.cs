using eCourse.Models.Klijent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKlijentData
    {
        Task<KlijentDataDisplayModel> GetKlijentData(int klijentId);
        Task<KlijentDataDisplayModel> UpdateKlijentData(int klijentId, KlijentDataUpdateModel model);
    }
}
