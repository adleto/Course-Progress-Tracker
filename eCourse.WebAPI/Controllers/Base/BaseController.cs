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
    public abstract class BaseController<T, TSearch> : ControllerBase
    {
        private readonly IBaseService<T, TSearch> _service;

        public BaseController(IBaseService<T, TSearch> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<T>> Get([FromQuery] TSearch search)
        {
            return await _service.Get(search);
        }
        [HttpGet("{id}")]
        public T Get(int id)
        {
            return _service.Get(id);
        }
    }
}
