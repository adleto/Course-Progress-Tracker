using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Kurs;
using eCourse.Models.Tag;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class KursService : IKurs
    {
        private readonly CourseContext _context;
        private readonly IMapper _mapper;

        public KursService(CourseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<KursProsireniModel> Add(KursProsireniModel model)
        {
            try
            { // Warnign: ne radi se provjera da li tagovi stvarno postoje već ukoliko su lažni dodje do exceptiona
                var noviKurs = _mapper.Map<Kurs>(model);
                _context.Kurs.Add(noviKurs);
                foreach(var tag in model.Tagovi)
                {
                    _context.KursTag.Add(new KursTag
                    {
                        Kurs = noviKurs,
                        TagId = tag.Id
                    });
                }
                await _context.SaveChangesAsync();
                var returnModel = _mapper.Map<KursProsireniModel>(noviKurs);
                model.Tagovi.ForEach(t => returnModel.Tagovi.Add(new TagModel
                {
                    Id = t.Id,
                    Naziv = t.Naziv
                }));
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<KursModel>> Get(List<TagModel> tagovi)
        {
            try
            {
                var kursevi = await _context.Kurs
                .Include(k => k.TagoviKursa)
                .ToListAsync();
                if (tagovi.Count == 0) return _mapper.Map<List<KursModel>>(kursevi);
                var returnModel = new List<KursModel>();
                kursevi.ForEach(k =>
                {
                    if (ImaSveTagoveSaListe(tagovi, k)) returnModel.Add(_mapper.Map<KursModel>(k));
                });
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public KursProsireniModel Get(int id)
        {
            try
            {
                var kurs = _context.Kurs
                    .Include(k => k.TagoviKursa)
                        .ThenInclude(tk => tk.Tag)
                    .Where(k => k.Id == id)
                    .FirstOrDefault();
                var returnModel = _mapper.Map<KursProsireniModel>(kurs);
                returnModel.Tagovi = new List<TagModel>();
                kurs.TagoviKursa.ForEach(t => returnModel.Tagovi.Add(new TagModel {
                    Id = t.TagId,
                    Naziv = t.Tag.Naziv
                }));
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<KursProsireniModel> Update(int id, KursProsireniModel model)
        {
            try
            { 
                var kurs = _context.Kurs
                    .Include(k => k.TagoviKursa)
                        .ThenInclude(tk => tk.Tag)
                    .Where(k => k.Id == id)
                    .FirstOrDefault();
                _context.Set<Kurs>().Attach(kurs);
                _context.Set<Kurs>().Update(kurs);

                //_mapper.Map(model, kurs); ne prolazi zbog id-a pa cu manual
                kurs.Naziv = model.Naziv;
                kurs.SkraceniNaziv = model.SkraceniNaziv;
                kurs.Opis = model.SkraceniNaziv;

                foreach(var postojeciKurs in kurs.TagoviKursa)
                {
                    _context.KursTag.Remove(postojeciKurs);
                }
                foreach(var noviTag in model.Tagovi)
                {
                    _context.KursTag.Add(new KursTag
                    {
                        Kurs = kurs,
                        TagId = noviTag.Id
                    });
                }

                await _context.SaveChangesAsync();
                var returnModel = _mapper.Map<KursProsireniModel>(kurs);
                returnModel.Tagovi = new List<TagModel>();
                model.Tagovi.ForEach(t => returnModel.Tagovi.Add(new TagModel
                {
                    Id = t.Id,
                    Naziv = t.Naziv
                }));
                return returnModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private bool ImaSveTagoveSaListe(List<TagModel> tagovi, Kurs k)
        {
            foreach(var tag in tagovi)
            {
                if (!ImaTag(tag, k)) return false;
            }
            return true;
        }

        private bool ImaTag(TagModel tag, Kurs k)
        {
            foreach(var tagKursa in k.TagoviKursa)
            {
                if (tagKursa.TagId == tag.Id) return true;
            }
            return false;
        }
    }
}
