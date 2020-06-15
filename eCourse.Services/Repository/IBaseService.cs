using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Repository
{
    public interface IBaseService<T, TSearch>
    {
        Task<List<T>> Get(TSearch search);
        T Get(int id);
    }
}
