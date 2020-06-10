using eCourse.Models.Uplata;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IUplata
    {
        Task<List<UplataModel>> Get(int? klijentId = null);
        Task<UplataModel> Add(UplataInsertModel model);
    }
}
