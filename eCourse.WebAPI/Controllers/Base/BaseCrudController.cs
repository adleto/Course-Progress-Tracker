using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Services.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCrudController<T, TSearch, TInsert, TUpdate> : BaseController<T, TSearch>
    {
        private readonly ICrudService<T, TSearch, TInsert, TUpdate> _service;
        public BaseCrudController(ICrudService<T, TSearch, TInsert, TUpdate> service) : base(service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<T> Insert(TInsert obj)
        {
            return await _service.Insert(obj);
        }
        [HttpPut("{id}")]
        public async Task<T> Update(int id, [FromBody] TUpdate obj)
        {
            return await _service.Update(id, obj);
        }
    }
}
