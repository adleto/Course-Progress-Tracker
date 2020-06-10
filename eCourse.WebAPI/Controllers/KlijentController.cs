using System;
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
    [Authorize(Roles = "AdministrativnoOsoblje, Predavač")]
    public class KlijentController : ControllerBase
    {
        private readonly IApplicationUser _userService;

        public KlijentController(IApplicationUser userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] KlijentSearchRequestModel model = null)
        {
            try
            {
                return Ok(await _userService.GetKlijenti(UserResolver.GetUserId(HttpContext.User), UserResolver.GetUserRoles(HttpContext.User), model));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
