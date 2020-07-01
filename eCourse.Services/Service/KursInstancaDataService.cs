using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Cas;
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
        private readonly IMapper _mapper;
        public KursInstancaDataService(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<KursInstancaForKlijentListViewModel>> GetInstance(int klijentId, KursInstancaDataFilter model)
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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
            try
            {
                var result = RecommenderService.GetRecommended(_context, klijentId);
                //var result = await _context.KursInstanca
                //    .Include(k => k.Kurs)
                //    .Where(k => k.PrijaveDoDatum.Date > DateTime.Now.Date)
                //    .Take(3)
                //    .ToListAsync();
                var returnModel = new List<KursInstancaForKlijentListViewModel>();
                foreach (var r in result)
                {
                    returnModel.Add(MapToKursInstancaForKlijentListViewModel(r));
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private KursInstancaForKlijentListViewModel MapToKursInstancaForKlijentListViewModel(KursInstanca k)
        {
            var returnModel = new KursInstancaForKlijentListViewModel
            {
                InstancaId = k.Id,
            };
            if (k.PocetakDatum.Date > DateTime.Now.Date)
            {
                returnModel.Naziv = k.Kurs.Naziv + " (Počinje: " + k.PocetakDatum.ToString("dd/MM/yyyy") + ")";
            }
            else
            {
                returnModel.Naziv = k.Kurs.Naziv + " (Počeo: " + k.PocetakDatum.ToString("dd/MM/yyyy") + ")";
            }
            return returnModel;
        }

        public async Task<KursDataModel> GetKursData(int instancaId, int klijentId)
        {
            try
            {
                var instanca = _context.KursInstanca
                    .Include(k => k.Kurs)
                    .Include(k => k.Uposlenik)
                        .ThenInclude(u => u.ApplicationUser)
                    .Where(k => k.Id == instancaId)
                    .FirstOrDefault();
                var klijentInstanca = _context.KlijentKursInstanca
                    .Where(k => k.KursInstancaId == instancaId && k.KlijentId == klijentId)
                    .FirstOrDefault();

                var returnModel = new KursDataModel
                {
                    BrojCasova = instanca.BrojCasova,
                    Cijena = instanca.Cijena,
                    DatumKraja = instanca.KrajDatum,
                    DatumPocetka = instanca.PocetakDatum,
                    DatumPrijaveDo = instanca.PrijaveDoDatum,
                    KursInstancaId = instanca.Id,
                    Naziv = instanca.Kurs.Naziv,
                    Kapacitet = instanca.Kapacitet,
                    Opis = instanca.Kurs.Opis,
                    Predavac = instanca.Uposlenik.ApplicationUser.Ime + " " + instanca.Uposlenik.ApplicationUser.Prezime,
                    Ocijenjen = false,
                    Zavrsen = false,
                    PrijavljenIAktivan = false,
                    PrijavljenAliNeUplacen = false,
                    NijePrijavljen = true
                };
                if (instanca.KrajDatum != null) returnModel.Zavrsen = true;
                if (klijentInstanca != null)
                {
                    returnModel.NijePrijavljen = false;
                    if (klijentInstanca.Active)
                    {
                        returnModel.PrijavljenIAktivan = true;
                    }
                    else if(klijentInstanca.UplataIzvrsena!=null && klijentInstanca.UplataIzvrsena == false)
                    {
                        returnModel.PrijavljenAliNeUplacen = true;
                    }
                    var ispitKlijent = _context.IspitKlijentKursInstanca
                        .Include(i => i.Ispit)
                        .Where(i => i.KlijentKursInstancaId == klijentInstanca.Id)
                        .FirstOrDefault();
                    returnModel.Casovi = _mapper.Map<List<CasModel>>(instanca.Casovi);
                    returnModel.KlijentKursInstancaId = klijentInstanca.Id;
                    returnModel.Ocjena = klijentInstanca.Rejting;
                    if (klijentInstanca.Rejting != null) returnModel.Ocijenjen = true;
                    returnModel.Polozen = klijentInstanca.Polozen;
                    returnModel.UplataIzvrsena = klijentInstanca.UplataIzvrsena;
                    if (ispitKlijent != null)
                    {
                        returnModel.VrijemeIspit = ispitKlijent.Ispit.DatumVrijemeIspita;
                        returnModel.PrisustvovoIspitu = ispitKlijent.Prisustvovao;
                        returnModel.LokacijaIspit = ispitKlijent.Ispit.Lokacija;
                        returnModel.IspitPoeni = ispitKlijent.Bodovi;
                    }
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KursDataModel> PrijaviSeZaKurs(int instancaId, int klijentId)
        {
            try
            {
                var klijentInstanca = _context.KlijentKursInstanca
                    .Where(k => k.KursInstancaId == instancaId && k.KlijentId == klijentId)
                    .FirstOrDefault();
                if (klijentInstanca != null) throw new Exception("Već ste prijavljeni na ovaj kurs.");
                var instanca = _context.KursInstanca.Find(instancaId);
                if (instanca.PrijaveDoDatum.Date < DateTime.Now.Date) throw new Exception("Prijave za ovaj kurs su završene.");
                var klijent = _context.Klijent
                    .Include(k => k.ClanarineKlijenta)
                    .Where(k => k.Id == klijentId)
                    .FirstOrDefault();
                if (instanca.Cijena == null)
                {
                    if (klijent.ClanarineKlijenta == null ||
                        klijent.ClanarineKlijenta.Count == 0 ||
                        klijent.ClanarineKlijenta.Max(c => c.DatumIsteka) < DateTime.Now.Date)
                    {

                        throw new Exception("Članarina vam je istekla, ne možete se prijaviti na ovaj kurs.");
                    }
                }

                var novaKlijentInstanca = new KlijentKursInstanca
                {
                    Active = false,
                    KlijentId = klijentId,
                    KursInstancaId = instanca.Id,
                    Polozen = false,
                    Rejting = null,
                    UplataIzvrsena = null
                };
                if (instanca.Cijena == null) novaKlijentInstanca.Active = true;
                else novaKlijentInstanca.UplataIzvrsena = false;
                _context.KlijentKursInstanca.Add(novaKlijentInstanca);
                await _context.SaveChangesAsync();
                return await GetKursData(instancaId, klijentId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int?> OstaviRejting(RejtingModel model, int klijentId)
        {
            try
            {
                var klijentInstanca = _context.KlijentKursInstanca
                    .Where(k => k.KlijentId == klijentId && k.KursInstancaId == model.InstancaId)
                    .FirstOrDefault();
                if (klijentInstanca == null) throw new Exception("Ne možete ostaviti rejting na ovaj kurs.");
                klijentInstanca.Rejting = model.Rejting;
                await _context.SaveChangesAsync();
                return model.Rejting;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
