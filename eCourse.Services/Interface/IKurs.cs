using eCourse.Models.Kurs;
using eCourse.Models.Tag;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IKurs
    {
        Task<List<KursModel>> Get(List<TagModel> tagovi);
        KursProsireniModel Get(int id);
        Task<KursProsireniModel> Add(KursProsireniModel model);
        Task<KursProsireniModel> Update(int id, KursProsireniModel model);
    }
}
