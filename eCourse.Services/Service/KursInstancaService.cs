﻿using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Cas;
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
        private readonly IMapper _mapper;

        public KursInstancaService(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KursInstancaModel>> Get(List<string> roles, int uposlenikId)
        {
            try
            {
                var query = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .AsQueryable();
                if (!roles.Contains("AdministrativnoOsoblje"))
                {
                    query = query.Where(k => k.UposlenikId == uposlenikId);
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

        public async Task<List<MojaKursInstanca>> GetMojiKursevi(int uposlenikId, MojaKursInstancaFilter model)
        {
            try
            {
                var query = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .Include(ki => ki.Uposlenik)
                        .ThenInclude(u => u.ApplicationUser)
                    .Where(ki => ki.UposlenikId == uposlenikId)
                    .OrderByDescending(ki => ki.PocetakDatum)
                    .AsQueryable();
                if (model != null)
                {
                    if (model.Zavrseni && !model.NisuZavrseni)
                    {
                        query = query.Where(r => r.KrajDatum != null);
                    }
                    else if (model.NisuZavrseni && !model.Zavrseni)
                    {
                        query = query.Where(r => r.KrajDatum == null);
                    }
                    else if (!model.Zavrseni && !model.NisuZavrseni)
                    {
                        query = query.Take(0);
                    }
                }
                var result = await query.ToListAsync();
                var returnModel = new List<MojaKursInstanca>();
                foreach (var r in result)
                {
                    returnModel.Add(MapKursInstancaToMojaKursInstanca(r));
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private MojaKursInstanca MapKursInstancaToMojaKursInstanca(KursInstanca model)
        {
            try
            {
                var returnModel = new MojaKursInstanca
                {
                    BrojKlijenata = _context.KlijentKursInstanca
                    .Where(k => k.KursInstancaId == model.Id && (k.UplataIzvrsena == null || k.UplataIzvrsena == true))
                    .Count(),
                    KursInstancaId = model.Id,
                    KursNaziv = model.Kurs.Naziv,
                    KursSkraceniNaziv = model.Kurs.SkraceniNaziv,
                    Pocetak = model.PocetakDatum.Date,
                    UposlenikId = model.UposlenikId,
                    UposlenikIme = model.Uposlenik.ApplicationUser.Ime,
                    UposlenikPrezime = model.Uposlenik.ApplicationUser.Prezime,
                    PrijaveDo = model.PrijaveDoDatum.Date,
                    Kapacitet = model.Kapacitet,
                    KrajDate = model.KrajDatum,
                    BrojCasova = model.BrojCasova
                };
                if (model.KrajDatum != null)
                {
                    DateTime k = (DateTime)model.KrajDatum;
                    returnModel.KrajDate = k.Date;
                }
                var ispit = _context.Ispit
                    .Where(i => i.KursInstancaId == model.Id)
                    .FirstOrDefault();
                if (ispit != null)
                {
                    returnModel.IspitOrganizovan = true;
                    returnModel.IspitId = ispit.Id;
                }
                else
                {
                    returnModel.IspitOrganizovan = false;
                }
                if (model.Kapacitet != null) returnModel.KapacitetOpis = model.Kapacitet.ToString();
                else returnModel.KapacitetOpis = "Neograničen";
                if (model.KrajDatum != null) returnModel.KrajOpis = model.KrajDatum.ToString();
                else returnModel.KrajOpis = "Nije upisan";
                if (model.PocetakDatum < DateTime.Now && model.KrajDatum == null || model.KrajDatum > DateTime.Now) returnModel.ZavrsenOpis = "U toku";
                else if (model.PocetakDatum > DateTime.Now) returnModel.ZavrsenOpis = "Još nije započet";
                else returnModel.ZavrsenOpis = "Završen";
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

        public async Task<KursInstancaSimpleModel> DodajInstancu(int uposlenikId, KursInstancaInsertModel model)
        {
            try
            {
                if (model.DatumPocetka.Date < DateTime.Now.Date) throw new Exception("Datum početka ne može biti manji od današnjeg.");
                if (model.DatumPrijaveDo.Date > model.DatumPocetka.Date) throw new Exception("Krajnji rok za prijave ne može biti noviji od datuma početka.");

                var novaInstanca = new KursInstanca
                {
                    BrojCasova = model.BrojCasova,
                    Cijena = model.Cijena,
                    Kapacitet = model.Kapacitet,
                    KursId = model.KursId,
                    PocetakDatum = model.DatumPocetka,
                    PrijaveDoDatum = model.DatumPrijaveDo,
                    UposlenikId = uposlenikId
                };
                _context.KursInstanca.Add(novaInstanca);
                await _context.SaveChangesAsync();
                return new KursInstancaSimpleModel
                {
                    KursInstancaId = novaInstanca.Id,
                    UposlenikId = novaInstanca.UposlenikId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public KursInstancaSimpleModel GetInstancaSimple(int id)
        {
            try
            {
                var result = _context.KursInstanca
                    .Find(id);
                return new KursInstancaSimpleModel
                {
                    KursInstancaId = result.Id,
                    UposlenikId = result.UposlenikId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MojaKursInstancaProsireniModel GetInstanca(int id)
        {
            try
            {
                var result = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .Include(ki => ki.Uposlenik)
                        .ThenInclude(u => u.ApplicationUser)
                    .Include(ki => ki.Casovi)
                    .Where(ki => ki.Id == id)
                    .FirstOrDefault();
                MojaKursInstancaProsireniModel returnModel = _mapper.Map<MojaKursInstancaProsireniModel>(MapKursInstancaToMojaKursInstanca(result));
                returnModel.Casovi = _mapper.Map<List<CasModel>>(result.Casovi);
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KursInstancaSimpleModel> UpdateInstanca(int uposlenikId, int id, KursInstancaUpdateModel model)
        {
            try
            {
                var instanca = _context.KursInstanca.Find(id);
                if (instanca.UposlenikId != uposlenikId) throw new Exception("Instanca ne pripada uposleniku.");
                if (instanca.KrajDatum?.Date <= DateTime.Now.Date) throw new Exception("Kurs je već završen.");
                if (instanca.PocetakDatum.Date < DateTime.Now.Date) throw new Exception("Kurs je već započeo.");
                if (model.PocetakDatum.Date < DateTime.Now.Date) throw new Exception("Datum početka ne može biti manji od današnjeg.");
                if (model.PrijaveDoDatum.Date > model.PocetakDatum.Date) throw new Exception("Krajnji rok za prijave ne može biti noviji od datuma početka.");
                var brojStudenata = _context.KlijentKursInstanca.Where(k => k.KursInstancaId == instanca.Id).Count();
                if (model.Kapacitet != null && brojStudenata > model.Kapacitet) throw new Exception("Kapacitet ne može biti niži od trenutnog broja upisanih studenata.");
                if (model.Kapacitet != null && model.Kapacitet <= 0) throw new Exception("Kapacitet ne može biti manji ili jednak nuli.");
                instanca.Kapacitet = model.Kapacitet;
                instanca.PocetakDatum = model.PocetakDatum.Date;
                instanca.PrijaveDoDatum = model.PrijaveDoDatum.Date;
                await _context.SaveChangesAsync();
                return new KursInstancaSimpleModel
                {
                    KursInstancaId = instanca.Id,
                    UposlenikId = instanca.UposlenikId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KursInstancaSimpleModel> ZavrsiInstancu(int uposlenikId, int id, bool postaviZaKlijenteKaoPolozili = true)
        {
            try
            {
                var instanca = _context.KursInstanca.Find(id);
                if (instanca.UposlenikId != uposlenikId) throw new Exception("Instanca ne pripada uposleniku.");
                if (instanca.KrajDatum != null) throw new Exception("Kurs je već završen.");
                instanca.KrajDatum = DateTime.Now;

                var klijentiInstance = await _context.KlijentKursInstanca
                    .Where(k => k.KursInstanca == instanca)
                    .ToListAsync();
                klijentiInstance.ForEach(k =>
                {
                    k.Active = false;
                    if (instanca.BrojCasova >= _context.Cas.Where(c => c.KursInstanca == instanca).Count() || postaviZaKlijenteKaoPolozili)
                    {
                        k.Polozen = true;
                    }
                    else
                    {
                        k.Polozen = false;
                    }
                });
                await _context.SaveChangesAsync();
                return new KursInstancaSimpleModel
                {
                    KursInstancaId = instanca.Id,
                    UposlenikId = instanca.UposlenikId
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<MojaKursInstancaForReport>> GetReport(KursInstancaFilter model)
        {
            try
            {
                var query = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .Include(ki => ki.Uposlenik)
                        .ThenInclude(u => u.ApplicationUser)
                    .AsQueryable();
                if (model != null)
                {
                    if (model.DateDo != null)
                    {
                        var doDatum = (DateTime)model.DateDo;
                        query = query.Where(u => u.PocetakDatum.Date <= doDatum.Date);
                    }
                    if (model.DateOd != null)
                    {
                        var odDatum = (DateTime)model.DateOd;
                        query = query.Where(u => u.PocetakDatum.Date >= odDatum.Date);
                    }
                }
                var result = await query.ToListAsync();
                var returnModel = new List<MojaKursInstancaForReport>();
                foreach (var r in result)
                {
                    var item = MapKursInstancaToMojaKursInstanca(r);
                    var insert = _mapper.Map<MojaKursInstancaForReport>(item);
                    insert.DatePocetak = insert.Pocetak.ToString("dd/MM/yyyy");
                    returnModel.Add(insert);
                }
                returnModel = returnModel.OrderByDescending(k => k.BrojKlijenata).ToList();
                if (model.TakeThisMany != null)
                {
                    returnModel = returnModel.Take((int)model.TakeThisMany).ToList();
                }
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
