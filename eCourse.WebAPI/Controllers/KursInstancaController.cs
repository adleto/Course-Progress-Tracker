using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
    public class KursInstancaController : ControllerBase
    {
        private readonly IKursInstanca _kursInstancaService;

        public KursInstancaController(IKursInstanca kursInstancaService)
        {
            _kursInstancaService = kursInstancaService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok(await _kursInstancaService.Get(UserResolver.GetUserRoles(HttpContext.User), UserResolver.GetUserId(HttpContext.User)));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
