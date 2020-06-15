using eCourse.Models.Ispit;
using eCourse.Services.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IIspit : ICrudService<IspitModel, object, IspitUpsertModel, IspitUpsertModel>
    {
        IspitProsireniModel GetFull(int instancaId);
    }
}
