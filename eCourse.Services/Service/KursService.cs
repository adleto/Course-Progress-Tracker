using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Kurs;
using eCourse.Models.Tag;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task<List<KursModel>> Get(List<TagModel> tagovi)
        {
            var kursevi = await _context.Kurs
                .Include(k => k.TagoviKursa)
                .ToListAsync();
            if (tagovi.Count == 0) return _mapper.Map<List<KursModel>>(kursevi);
            var returnModel = new List<KursModel>();
            kursevi.ForEach(k =>
            {
                if(ImaSveTagoveSaListe(tagovi, k)) returnModel.Add(_mapper.Map<KursModel>(k));
            });
            return returnModel;
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
