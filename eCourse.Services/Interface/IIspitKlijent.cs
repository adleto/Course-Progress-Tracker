using eCourse.Models.IspitKlijent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Interface
{
    public interface IIspitKlijent
    {
        Task<KlijentScoresModel> UpdateKlijentScores(int uposlenikId, KlijentScoresModel model);
    }
}
