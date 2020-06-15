using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.Ispit;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="AdministrativnoOsoblje, Predavač")]
    public class IspitController : ControllerBase
    {
        private readonly IIspit _ispitService;
        private readonly IKursInstanca _kursInstancaService;

        public IspitController(IIspit ispitService, IKursInstanca kursInstancaService)
        {
            _ispitService = ispitService;
            _kursInstancaService = kursInstancaService;
        }
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] IspitUpsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UserResolver.GetUposlenikId(HttpContext.User) != _kursInstancaService.GetInstancaSimple(model.KursInstancaId).UposlenikId)
                    {
                        return Unauthorized("Ova instanca ne pripada predavaču.");
                    }
                    return Ok(await _ispitService.Insert(model));
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
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] IspitUpsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(UserResolver.GetUposlenikId(HttpContext.User) != _kursInstancaService.GetInstancaSimple(model.KursInstancaId).UposlenikId){
                        return Unauthorized("Ova instanca ne pripada predavaču.");
                    }
                    return Ok(await _ispitService.Update(id, model));
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
        [HttpGet]
        public ActionResult GetFull([FromQuery] int instancaId)
        {
            try
            {
                return Ok(_ispitService.GetFull(instancaId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet("{id}")]
        public ActionResult GetSimple(int id)
        {
            try
            {
                return Ok(_ispitService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
