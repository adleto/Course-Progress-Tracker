using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.Klijent;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers.KlijentSpecific
{
    [Authorize(Roles = "Klijent")]
    [Route("api/[controller]")]
    [ApiController]
    public class KursInstancaDataController : ControllerBase
    {
        private readonly IKursInstancaData _kursInstancaDataService;

        public KursInstancaDataController(IKursInstancaData kursInstancaDataService)
        {
            _kursInstancaDataService = kursInstancaDataService;
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] KursInstancaDataFilter model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception("Neispravna pretraga.");
                return Ok(await _kursInstancaDataService.GetInstance(UserResolver.GetKlijentId(HttpContext.User), model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet]
        [Route("[action")]
        public async Task<ActionResult> GetRecommended()
        {
            try
            {
                return Ok(await _kursInstancaDataService.GetRecommendedInstance(UserResolver.GetKlijentId(HttpContext.User)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
