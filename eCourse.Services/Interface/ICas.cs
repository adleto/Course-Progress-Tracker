using eCourse.Database.Entities;
using eCourse.Models.Cas;
using eCourse.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface ICas : ICrudService<CasModel, object, CasUpsertModel, CasUpsertModel>
    {
        Task<List<CasModel>> GetCasoviInstanca(int instancaId);
    }
}
