using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Klijent;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class KursInstancaDataService : IKursInstancaData
    {
        private readonly CourseContext _context;
        public KursInstancaDataService(CourseContext context)
        {
            _context = context;
        }
        public async Task<List<KursInstancaForKlijentListViewModel>> GetInstance(int klijentId, KursInstancaDataFilter model)
        {
            var query = _context.KursInstanca
                .Include(k => k.Kurs)
                    .ThenInclude(kk => kk.TagoviKursa)
                .AsQueryable();
            if (!string.IsNullOrEmpty(model.Pretraga))
            {
                query = query
                    .Where(k => k.Kurs.Naziv.StartsWith(model.Pretraga) ||
                    k.Kurs.SkraceniNaziv.StartsWith(model.Pretraga));
            }
            if (model.GetSve)
            {
                query = query.Where(k => k.PrijaveDoDatum.Date > DateTime.Now.Date);
            }

            var result = await query.ToListAsync();
            if (model.TagId != null)
            {
                result = FiltrirajPoTagu((int)model.TagId, result);
            }
            if (model.GetSve == false)
            {
                var instanceKlijenta = await _context.KlijentKursInstanca
                    .Where(k => k.KlijentId == klijentId)
                    .ToListAsync();
                if (model.GetMojiAktivni)
                {
                    result = FiltrirajPoMojiAktivni(instanceKlijenta, result);
                }
                else if (model.GetMojiUspjesnoZavrseni)
                {
                    result = FiltrirajMojiUspjesnoZavrseni(instanceKlijenta, result);
                }
                else if (model.GetMojiZavrseni)
                {
                    result = FiltrirajPoMojiZavrseni(instanceKlijenta, result);
                }
            }
            
            var returnModel = new List<KursInstancaForKlijentListViewModel>();
            foreach (var r in result)
            {
                returnModel.Add(MapToKursInstancaForKlijentListViewModel(r));
            }
            return returnModel;
        }

        private List<KursInstanca> FiltrirajPoMojiZavrseni(List<KlijentKursInstanca> instanceKlijenta, List<KursInstanca> result)
        {
            result = result
                .Where(r => r.KrajDatum != null)
                .ToList();
            return Filtriraj(instanceKlijenta, result);
        }

        private List<KursInstanca> FiltrirajMojiUspjesnoZavrseni(List<KlijentKursInstanca> instanceKlijenta, List<KursInstanca> result)
        {
            result = result
                .Where(r => r.KrajDatum != null)
                .ToList();
            instanceKlijenta = instanceKlijenta
                .Where(i => i.Polozen != null && i.Polozen == true)
                .ToList();
            return Filtriraj(instanceKlijenta, result);
        }

        private List<KursInstanca> FiltrirajPoMojiAktivni(List<KlijentKursInstanca> instanceKlijenta, List<KursInstanca> result)
        {
            result = result
                .Where(r => r.KrajDatum == null)
                .ToList();
            return Filtriraj(instanceKlijenta, result);
        }
        private List<KursInstanca> Filtriraj(List<KlijentKursInstanca> instanceKlijenta, List<KursInstanca> result)
        {
            var list = new List<KursInstanca>();
            foreach (var ik in instanceKlijenta)
            {
                foreach (var instanca in result)
                {
                    if (ik.KursInstancaId == instanca.Id)
                    {
                        list.Add(instanca);
                        break;
                    }
                }
            }
            return list;
        }

        private List<KursInstanca> FiltrirajPoTagu(int tagId, List<KursInstanca> result)
        {
            var list = new List<KursInstanca>();
            foreach (var r in result)
            {
                foreach (var tag in r.Kurs.TagoviKursa)
                {
                    if (tag.TagId == tagId)
                    {
                        list.Add(r);
                        break;
                    }
                }
            }
            return list;
        }

        public async Task<List<KursInstancaForKlijentListViewModel>> GetRecommendedInstance(int klijentId)
        {
            //Recommender napravit
            var result = await _context.KursInstanca
                .Include(k => k.Kurs)
                .Where(k => k.PrijaveDoDatum.Date > DateTime.Now.Date)
                .ToListAsync();
            var returnModel = new List<KursInstancaForKlijentListViewModel>();
            foreach(var r in result)
            {
                returnModel.Add(MapToKursInstancaForKlijentListViewModel(r));
            }
            return returnModel;
        }
        private KursInstancaForKlijentListViewModel MapToKursInstancaForKlijentListViewModel(KursInstanca k)
        {
            var returnModel = new KursInstancaForKlijentListViewModel
            {
                InstancaId = k.Id,
                Naziv = k.Kurs.Naziv
            };
            return returnModel;
        }
    }
}
