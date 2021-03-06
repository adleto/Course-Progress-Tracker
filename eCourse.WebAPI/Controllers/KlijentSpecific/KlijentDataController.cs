﻿using System;
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
    public class KlijentDataController : ControllerBase
    {
        private readonly IKlijentData _klijentDataService;

        public KlijentDataController(IKlijentData klijentDataService)
        {
            _klijentDataService = klijentDataService;
        }

        [HttpGet]
        public async Task<ActionResult> GetKlijentData()
        {
            try
            {
                return Ok(await _klijentDataService.GetKlijentData(UserResolver.GetKlijentId(HttpContext.User)));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpPost]
        public async Task<ActionResult> UpdateKlijentData([FromBody] KlijentDataUpdateModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(model);
                return Ok(await _klijentDataService.UpdateKlijentData(UserResolver.GetKlijentId(HttpContext.User), model));
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
