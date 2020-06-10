using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.Uplata;
using eCourse.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
    public class UplataController : ControllerBase
    {
        private readonly IUplata _uplataService;
        public UplataController(IUplata uplataService)
        {
            _uplataService = uplataService;
        }
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
    }
}
