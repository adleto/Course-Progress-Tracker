﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class KlijentController : ControllerBase
    {
        private readonly IApplicationUser _userService;

        public KlijentController(IApplicationUser userService)
        {
            _userService = userService;
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] KlijentSearchRequestModel model = null)
        {
            try
            {
                return Ok(await _userService.GetKlijenti(UserResolver.GetUposlenikId(HttpContext.User), UserResolver.GetUserRoles(HttpContext.User), model));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
        [HttpGet]
        [Route("[action]")]
        public async Task<ActionResult> GetKlijentiSimple()
        {
            try
            {
                return Ok(await _userService.GetKlijentiSimple());
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
