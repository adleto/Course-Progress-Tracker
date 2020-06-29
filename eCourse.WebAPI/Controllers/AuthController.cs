using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
using eCourse.Services.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IApplicationUser _userService;

        public AuthController(IApplicationUser userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try {
                var claimRoles = User.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();
                var roleNames = new List<string>();
                claimRoles.ForEach(x => roleNames.Add(x.Value));
                return Ok(roleNames);
            }
            catch
            {
                return BadRequest();
            }
        }
        [Authorize]
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetKlijent()
        {
            try
            {
                var claimClanarina = User.Claims.Where(c => c.Type == "ClanarinaAktivna").First();
                //return Ok(claimClanarina.Value);
                return Ok(new { claimClanarina.Value });
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] ApplicationUserInsertModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(new Exception("Neispravan unos podataka."));
                var returnModel = await _userService.AddKlijent(model);
                return Ok(returnModel);
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, HttpStatusCode.BadRequest));
            }
        }
    }
}
