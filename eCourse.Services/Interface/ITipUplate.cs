using eCourse.Models.TipUplate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface ITipUplate
    {
        Task<List<TipUplateModel>> Get();
    }
}
