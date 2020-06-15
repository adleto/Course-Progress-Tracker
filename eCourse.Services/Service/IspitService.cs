using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Ispit;
using eCourse.Services.Interface;
using eCourse.Services.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class IspitService : BaseCrudService<IspitModel, object, Ispit, IspitUpsertModel, IspitUpsertModel>, IIspit
    {
        public IspitService(CourseContext context, IMapper mapper) : base(context, mapper)
        {
        }
        public override async Task<IspitModel> Insert(IspitUpsertModel obj)
        {
            var result = await base.Insert(obj);

            var studentiNaKursu = await _context.KlijentKursInstanca
                .Where(k => k.KursInstancaId == result.KursInstancaId)
                .ToListAsync();
            foreach(var student in studentiNaKursu)
            {
                _context.IspitKlijentKursInstanca.Add(new IspitKlijentKursInstanca
                {
                    IspitId = result.Id,
                    Prisustvovao = false,
                    KlijentKursInstancaId = student.Id
                });
            }
            await _context.SaveChangesAsync();

            return result;
        }

        public IspitProsireniModel GetFull(int instancaId)
        {
            try
            {
                var ispit = _context.Ispit
                    .Include(i => i.KlijentiNaIspitu)
                        .ThenInclude(k => k.KlijentKursInstanca)
                            .ThenInclude(kk => kk.Klijent)
                                .ThenInclude(kl => kl.ApplicationUser)
                    .Include(i => i.KursInstanca)
                        .ThenInclude(k => k.Kurs)
                    .Where(i => i.KursInstancaId == instancaId)
                    .FirstOrDefault();
                var returnModel = _mapper.Map<IspitProsireniModel>(ispit);
                returnModel.NazivKursa = ispit.KursInstanca.Kurs.Naziv;
                returnModel.IspitKlijentLista = new List<IspitKlijentModel>();
                foreach(var klijentNaIspitu in ispit.KlijentiNaIspitu)
                {
                    returnModel.IspitKlijentLista.Add(new IspitKlijentModel
                    {
                        Bodovi = klijentNaIspitu.Bodovi,
                        Id = klijentNaIspitu.Id,
                        IspitId = klijentNaIspitu.IspitId,
                        KlijentKursInstancaId = klijentNaIspitu.KlijentKursInstancaId,
                        Prisustvovao = klijentNaIspitu.Prisustvovao,
                        ImeIPrezime = klijentNaIspitu.KlijentKursInstanca.Klijent.ApplicationUser.Ime + " " + klijentNaIspitu.KlijentKursInstanca.Klijent.ApplicationUser.Prezime
                    });
                }
                return returnModel;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
