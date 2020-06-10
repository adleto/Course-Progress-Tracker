using eCourse.Models.KursInstanca;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKursInstanca
    {
        Task<List<KursInstancaModel>> Get(List<string> roles, int userId);
    }
}
