using AutoMapper;
using eCourse.Database.Context;
using eCourse.Database.Entities;
using eCourse.Models.Cas;
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
    public class CasService : BaseCrudService<CasModel, object, Cas, CasUpsertModel, CasUpsertModel>, ICas 
    {
        public CasService(CourseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<List<CasModel>> GetCasoviInstanca(int instancaId)
        {
            try {
                var result = await _context.Cas
                    .Where(c => c.KursInstancaId == instancaId)
                    .ToListAsync();
                return _mapper.Map<List<CasModel>>(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
