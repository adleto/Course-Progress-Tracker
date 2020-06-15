using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.KursInstanca;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
    public class KursInstancaController : ControllerBase
    {
        private readonly IKursInstanca _kursInstancaService;

        public KursInstancaController(IKursInstanca kursInstancaService)
        {
            _kursInstancaService = kursInstancaService;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetSveInstance()
        {
            try
            {
                return Ok(await _kursInstancaService.Get(UserResolver.GetUserRoles(HttpContext.User), UserResolver.GetUposlenikId(HttpContext.User)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet]
        public async Task<ActionResult> GetMojeInstance([FromQuery] MojaKursInstancaFilter model)
        {
            try
            {
                return Ok(await _kursInstancaService.GetMojiKursevi(UserResolver.GetUposlenikId(HttpContext.User), model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpPost]
        public async Task<ActionResult> DodajInstancu(KursInstancaInsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _kursInstancaService.DodajInstancu(UserResolver.GetUposlenikId(HttpContext.User), model));
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
        [HttpGet("{id}")]
        public ActionResult GetInstanca(int id)
        {
            try
            {
                return Ok(_kursInstancaService.GetInstanca(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateInstanca(int id, KursInstancaUpdateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _kursInstancaService.UpdateInstanca(UserResolver.GetUposlenikId(HttpContext.User), id, model));
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
        [HttpPatch("{id}")]
        public async Task<ActionResult> ZavrsiInstancu(int id, [FromBody] bool postaviZaKlijenteKaoPolozili = true)
        {
            try
            {
                return Ok(await _kursInstancaService.ZavrsiInstancu(UserResolver.GetUposlenikId(HttpContext.User), id, postaviZaKlijenteKaoPolozili));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
