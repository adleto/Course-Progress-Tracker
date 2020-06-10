using AutoMapper;
using eCourse.Database.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace eCourse.Services.Repository
{
    public class BaseCrudService<TModel, TSearch, TEntity, TInsert, TUpdate> : BaseService<TModel, TSearch, TEntity>, ICrudService<TModel, TSearch, TInsert, TUpdate>
            where TEntity : class
    {
        public BaseCrudService(CourseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual async Task<TModel> Insert(TInsert obj)
        {
            var entity = _mapper.Map<TEntity>(obj);
            _context.Set<TEntity>().Add(entity);

            await _context.SaveChangesAsync();

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task<TModel> Update(int id, TUpdate obj)
        {
            var entity = _context.Set<TEntity>().Find(id);

            _context.Set<TEntity>().Attach(entity);
            _context.Set<TEntity>().Update(entity);

            _mapper.Map(obj, entity);
            //_context.Entry(entity).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return _mapper.Map<TModel>(entity);
        }
    }
}
