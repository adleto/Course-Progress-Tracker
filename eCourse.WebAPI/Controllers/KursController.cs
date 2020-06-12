using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.Kurs;
using eCourse.Models.Tag;
using eCourse.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KursController : ControllerBase
    {
        private readonly IKurs _kursService;

        public KursController(IKurs kursService)
        {
            _kursService = kursService;
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<ActionResult> GetKursevi(List<TagModel> tags)
        {
            try
            {
                return Ok(await _kursService.Get(tags));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_kursService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] KursProsireniModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _kursService.Add(model);
                    return Ok(item);
                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOsoblje(int id, [FromBody] KursProsireniModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _kursService.Update(id, model);
                    return Ok(item);
                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
