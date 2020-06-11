using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.KursInstanca;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class KursInstancaService : IKursInstanca
    {
        private readonly CourseContext _context;

        public KursInstancaService(CourseContext context)
        {
            _context = context;
        }

        public async Task<List<KursInstancaModel>> Get(List<string> roles, int userId)
        {
            try
            {
                var query = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .AsQueryable();
                if (!roles.Contains("AdministrativnoOsoblje"))
                {
                    query = query.Where(k => k.UposlenikId == userId);
                }
                var result = await query.ToListAsync();
                var returnModel = new List<KursInstancaModel>();
                foreach (var r in result)
                {
                    returnModel.Add(MapKursInstancaToKursInstancaModel(r));
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KursInstancaModel MapKursInstancaToKursInstancaModel(KursInstanca model)
        {
            var returnModel = new KursInstancaModel
            {
                Id = model.Id,
                KursNaziv = model.Kurs.Naziv,
                KursSkraceniNaziv = model.Kurs.SkraceniNaziv,
                PocetakDatum = model.PocetakDatum
            };
            return returnModel;
        }
    }
}
