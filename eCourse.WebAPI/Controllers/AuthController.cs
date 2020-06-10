using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using eCourse.Models.ApplicationUser;
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
    }
}
