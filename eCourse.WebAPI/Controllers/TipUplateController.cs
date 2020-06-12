using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipUplateController : ControllerBase
    {
        private readonly ITipUplate _tipUplateService;

        public TipUplateController(ITipUplate tipUplateService)
        {
            _tipUplateService = tipUplateService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _tipUplateService.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles ="AdministrativnoOsoblje")]
        [HttpPut]
        [Route("[action]/{id}")]
        public async Task<ActionResult> SetCijenaClanarine(int id, [FromBody] decimal cijena)
        {
            try
            {
                if (cijena <= 0) return BadRequest(new ApiException("Cijena ne može biti manja od 0.", System.Net.HttpStatusCode.BadRequest));
                return Ok(await _tipUplateService.SetCijenaClanarine(id, cijena));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
