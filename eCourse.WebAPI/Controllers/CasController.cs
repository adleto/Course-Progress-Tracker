using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Cas;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CasController : ControllerBase
    {
        private readonly ICas _casService;
        private readonly IKursInstanca _kursInstancaService;

        public CasController(ICas casService, IKursInstanca kursInstancaService)
        {
            _casService = casService;
            _kursInstancaService = kursInstancaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCasovi(int instancaId)
        {
            try
            {
                return Ok(await _casService.GetCasoviInstanca(instancaId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet]
        public ActionResult GetCas([FromQuery] int casId)
        {
            try
            {
                return Ok(_casService.Get(casId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpPost]
        public async Task<ActionResult> InsertCas([FromBody] CasUpsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(UserResolver.GetUposlenikId(HttpContext.User) != _kursInstancaService.GetInstancaSimple(model.KursInstancaId).UposlenikId)
                    {
                        return Unauthorized(new ApiException("Instanca ne pripada uposleniku.", System.Net.HttpStatusCode.BadRequest));
                    }
                    return Ok(await _casService.Insert(model));
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
        public async Task<ActionResult> UpdateCas(int id, [FromBody]CasUpsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (UserResolver.GetUposlenikId(HttpContext.User) != _kursInstancaService.GetInstancaSimple(model.KursInstancaId).UposlenikId)
                    {
                        return Unauthorized(new ApiException("Instanca ne pripada uposleniku.", System.Net.HttpStatusCode.BadRequest));
                    }
                    return Ok(await _casService.Update(id, model));
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
