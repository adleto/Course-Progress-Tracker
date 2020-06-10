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
    [Authorize]
    [ApiController]
    public class KlijentKursInstancaController : ControllerBase
    {
        private readonly IKlijentKursInstanca _klijentKursInstancaService;

        public KlijentKursInstancaController(IKlijentKursInstanca klijentKursInstancaService)
        {
            _klijentKursInstancaService = klijentKursInstancaService;
        }

        [HttpGet]
        [Route("[action]/{klijentId}")]
        public async Task<IActionResult> GetForUplata(int klijentId)
        {
            try
            {
                return Ok(await _klijentKursInstancaService.GetForUplata(klijentId));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
