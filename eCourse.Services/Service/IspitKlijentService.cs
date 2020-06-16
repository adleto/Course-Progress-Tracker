using eCourse.Database.Context;
using eCourse.Models.IspitKlijent;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class IspitKlijentService : IIspitKlijent
    {
        private readonly CourseContext _context;

        public IspitKlijentService(CourseContext context)
        {
            _context = context;
        }

        public async Task<KlijentScoresModel> UpdateKlijentScores(int uposlenikId, KlijentScoresModel model)
        {
            try
            {
                var ispit = _context.Ispit
                    .Include(i => i.KlijentiNaIspitu)
                    .Include(i => i.KursInstanca)
                    .Where(i => i.Id == model.IspitId)
                    .FirstOrDefault();
                if(ispit.KursInstanca.UposlenikId != uposlenikId)
                {
                    throw new Exception("Ispit nije organizovao ovaj predavač");
                }
                var returnModel = new KlijentScoresModel
                {
                    IspitId = ispit.Id,
                    KlijentPrisustvoScoreList = new List<KlijentIspitScore>()
                };
                foreach (var entry in model.KlijentPrisustvoScoreList)
                {
                    var entryInDb = ispit.KlijentiNaIspitu.Where(e => e.Id == entry.Id).FirstOrDefault();
                    if (entryInDb != null)
                    {
                        entryInDb.Prisustvovao = entry.Prisustvo;
                        entryInDb.Bodovi = entry.Bodovi;
                        returnModel.KlijentPrisustvoScoreList
                            .Add(new KlijentIspitScore { 
                                Bodovi = entryInDb.Bodovi,
                                Id = entryInDb.Id,
                                Prisustvo = entryInDb.Prisustvovao
                            });
                    }
                }
                await _context.SaveChangesAsync();
                return returnModel;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
