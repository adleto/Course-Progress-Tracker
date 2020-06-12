using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.TipUplate;
using eCourse.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Service
{
    public class TipUplateService : ITipUplate
    {
        private readonly CourseContext _context;

        public TipUplateService(CourseContext context)
        {
            _context = context;
        }

        public async Task<List<TipUplateModel>> Get()
        {
            var result = await _context.TipUplate.ToListAsync();
            var returnModel = new List<TipUplateModel>();
            result.ForEach(r => returnModel.Add(MapTipToModel(r)));
            return returnModel;
        }

        public async Task<TipUplateModel> SetCijenaClanarine(int id, decimal cijena)
        {
            try
            {
                var clanarina = _context.TipUplate
                .Find(id);
                clanarina.Cijena = cijena;
                await _context.SaveChangesAsync();
                return MapTipToModel(clanarina);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private TipUplateModel MapTipToModel(TipUplate tip)
        {
            return new TipUplateModel
            {
                Cijena = tip.Cijena,
                Naziv = tip.Naziv,
                TipUplateId = tip.Id
            };
        }
    }
}
