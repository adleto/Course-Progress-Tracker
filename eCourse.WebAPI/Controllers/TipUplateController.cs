using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
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
    }
}
