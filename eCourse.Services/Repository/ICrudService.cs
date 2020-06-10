using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Repository
{
    public interface ICrudService<T, TSearch, TInsert, TUpdate> : IBaseService<T, TSearch>
    {
        Task<T> Insert(TInsert obj);
        Task<T> Update(int id, TUpdate obj);
    }
}
