using eCourse.Models.KlijentKursInstanca;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKlijentKursInstanca
    {
        Task<List<KlijentKursInstancaForUplataModel>> GetForUplata(int klijentId);
    }
}
