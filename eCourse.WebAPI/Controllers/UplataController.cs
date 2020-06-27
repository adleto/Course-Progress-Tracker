using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.Uplata;
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
    public class UplataController : ControllerBase
    {
        private readonly IUplata _uplataService;
        public UplataController(IUplata uplataService)
        {
            _uplataService = uplataService;
        }
        [HttpPost]
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [Route("[action]")]
        public async Task<ActionResult> GetReport([FromBody] UplataFilterModel model)
        {
            try
            {
                return Ok(await _uplataService.GetReport(UserResolver.GetUserRoles(HttpContext.User), UserResolver.GetUserId(HttpContext.User) ,model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] int? id = null)
        {
            try
            {
                return Ok(await _uplataService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpPost]
        public async Task<ActionResult> Insert([FromBody] UplataInsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _uplataService.Add(model));
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
        [Authorize(Roles = "Klijent")]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetForKlijent([FromQuery] DateTime? datumOd = null, [FromQuery] DateTime? datumDo = null)
        {
            try
            {
                return Ok(await _uplataService.Get(UserResolver.GetKlijentId(HttpContext.User), datumOd, datumDo));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
