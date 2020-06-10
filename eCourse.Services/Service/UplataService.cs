using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Uplata;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class UplataService : IUplata
    {
        private readonly CourseContext _context;

        public UplataService(CourseContext context)
        {
            _context = context;
        }

        public async Task<UplataModel> Add(UplataInsertModel model)
        {
            try
            {
                var novaUplata = new Uplata
                {
                    KlijentId = model.KlijentId,
                    DatumUplate = DateTime.Now,
                    Iznos = model.Iznos
                };
                if(model.KursInstancaKlijentId != null)
                {
                    //ima kurs, pronadji postojil prijavljen a ne placen,
                    //vidi jel dovoljan iznos za uplatu, postavi kao placen i linkuj sve sa ideovima
                    var kursInstancaKlijenta = _context.KlijentKursInstanca.Find(model.KursInstancaKlijentId);
                    if (kursInstancaKlijenta == null) throw new Exception("Klijent nije prijavio ovaj kurs.");
                    if (kursInstancaKlijenta.KlijentId != model.KlijentId) throw new Exception("Neispravan klijent odabran.");
                    var kursInstanca = _context.KursInstanca.Find(kursInstancaKlijenta.KursInstancaId);
                    if (kursInstanca.Cijena == null) throw new Exception("Ovaj kurs se ne plaća.");
                    if (kursInstanca.PrijaveDoDatum < DateTime.Now) throw new Exception("Prijave za ovaj kurs su istekle.");
                    if (model.Iznos != kursInstanca.Cijena) throw new Exception("Netačan uplaćeni iznos.");

                    //cool sve obavi poso
                    novaUplata.KursInstancaId = model.KursInstancaKlijentId;
                    novaUplata.TipUplateId = model.TipUplate;
                    kursInstancaKlijenta.UplataIzvrsena = true;
                    kursInstancaKlijenta.Active = true; // Pazi na upotrebu ovog
                    _context.Uplata.Add(novaUplata);
                }
                else
                {
                    //clanarina je, dodaj clanarinu, izracunaj do kad traje po iznos mjesecno iz tabele...
                    novaUplata.TipUplateId = model.TipUplate;
                    var novaClanarina = new Clanarina
                    {
                        KlijentId = model.KlijentId,
                        Uplata = novaUplata
                    };
                    //get zadnju uplatu ako postoji
                    var clanarine = await _context.Clanarina
                        .Where(c => c.KlijentId == model.KlijentId)
                        .OrderByDescending(c => c.Id)
                        .ToListAsync();
                    DateTime? zadnjiDatum = null;
                    if (clanarine.Count > 0)
                    {
                        zadnjiDatum = clanarine[0].DatumIsteka;
                    }
                    var mjesecniIznos = _context.TipUplate.Find(model.TipUplate).Cijena;
                    decimal uplacenoUOdnosuNaMjesecnuCijenu = model.Iznos / (decimal)mjesecniIznos;
                    int brojDanaZaDodat = (int) uplacenoUOdnosuNaMjesecnuCijenu * 31;
                    DateTime? noviDatum = null;
                    //null ili provjera za ako je stari datum vec isteko
                    if (zadnjiDatum == null || zadnjiDatum < DateTime.Now)
                    {
                        noviDatum = DateTime.Now.AddDays(brojDanaZaDodat);
                    }
                    else
                    {
                        noviDatum = ((DateTime)zadnjiDatum).AddDays(brojDanaZaDodat);
                    }
                    novaClanarina.DatumIsteka = (DateTime)noviDatum;
                    _context.Uplata.Add(novaUplata);
                    _context.Clanarina.Add(novaClanarina);
                }
                await _context.SaveChangesAsync();
                return MapUplataToUplataModel(novaUplata);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UplataModel>> Get(int? klijentId = null)
        {
            try {
                var query = _context.Uplata
                    .Include(u => u.TipUplate)
                    .Include(u => u.Klijent.ApplicationUser)
                    .AsQueryable();
                if (klijentId != null)
                {
                    query = query.Where(u => u.KlijentId == klijentId);
                }
                var result = await query.ToListAsync();
                var returnModel = new List<UplataModel>();
                result.ForEach(r => returnModel.Add(MapUplataToUplataModel(r)));
                return returnModel;
            }
            catch
            {
                throw new Exception("Client with that id does not exist.");
            }
        }
        private UplataModel MapUplataToUplataModel(Uplata uplata) 
        {
            var returnModel = new UplataModel
            {
                DatumUplate = uplata.DatumUplate,
                Id = uplata.Id,
                Iznos = uplata.Iznos,
                TipUplate = uplata.TipUplate.Naziv,
                ImeIPrezimeKlijenta = uplata.Klijent.ApplicationUser.Ime + " " + uplata.Klijent.ApplicationUser.Prezime
            };
            if(uplata.KursInstancaId != null)
            {
                var kursInstanca = _context.KursInstanca
                    .Include(ki => ki.Kurs)
                    .Where(ki => ki.Id == uplata.KursInstancaId)
                    .FirstOrDefault();
                returnModel.NamjenaZaKursInstancu = kursInstanca.Kurs.Naziv;
            }
            else
            {
                returnModel.NamjenaZaKursInstancu = "Nema";
            }
            var clanarina = _context.Clanarina
                .Where(c => c.UplataId == uplata.Id)
                .ToList();
            if (clanarina.Count > 0)
            {
                returnModel.ProduzenaClanarinaDo = clanarina[0].DatumIsteka;
            }
            return returnModel;
        }
    }
}
