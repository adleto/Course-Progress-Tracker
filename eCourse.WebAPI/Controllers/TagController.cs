using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Database.Entities;
using eCourse.Models.Tag;
using eCourse.Services.Repository;
using eCourse.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : BaseCrudController<TagModel, object, TagUpsertModel, TagUpsertModel>
    {
        public TagController(ICrudService<TagModel, object, TagUpsertModel, TagUpsertModel> service) : base(service)
        { }
        [Authorize(Roles ="AdministrativnoOsoblje, Predavač")]
        [HttpPost]
        public override async Task<TagModel> Insert(TagUpsertModel obj)
        {
            return await base._service.Insert(obj);
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpPut("{id}")]
        public override async Task<TagModel> Update(int id, [FromBody] TagUpsertModel obj)
        {
            return await base._service.Update(id, obj);
        }
    }
}
