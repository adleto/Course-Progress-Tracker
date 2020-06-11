using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.KlijentKursInstanca;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class KlijentKursInstancaService : IKlijentKursInstanca
    {
        private readonly CourseContext _context;

        public KlijentKursInstancaService(CourseContext context)
        {
            _context = context;
        }

        public async Task<List<KlijentKursInstancaForUplataModel>> GetForUplata(int klijentId)
        {
            try 
            {
                var instance = await _context.KlijentKursInstanca
                    .Include(k => k.KursInstanca)
                        .ThenInclude(ki => ki.Kurs)
                    .Where(k => k.KlijentId == klijentId &&
                        k.UplataIzvrsena != null &&
                        k.UplataIzvrsena == false)
                    .ToListAsync();
                var returnModel = new List<KlijentKursInstancaForUplataModel>();
                instance.ForEach(i => returnModel.Add(MapToKlijentKursInstancaModel(i)));
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KlijentKursInstancaForUplataModel MapToKlijentKursInstancaModel(KlijentKursInstanca k)
        {
            return new KlijentKursInstancaForUplataModel
            {
                Cijena = (decimal)k.KursInstanca.Cijena,
                KlijentKursInstancaId = k.Id,
                NazivInstance = k.KursInstanca.Kurs.Naziv + " " + k.KursInstanca.PocetakDatum.ToString("yyyy/MM/dd")
            };
        }
    }
}
