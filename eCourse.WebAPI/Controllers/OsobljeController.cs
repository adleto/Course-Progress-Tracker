using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.ApplicationUser;
using eCourse.Models.Helpers;
using eCourse.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Authorize(Roles = "AdministrativnoOsoblje")]
    [Route("api/[controller]")]
    [ApiController]
    public class OsobljeController : ControllerBase
    {
        private readonly IApplicationUser _userService;
        public OsobljeController(IApplicationUser userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<ActionResult> AddOsoblje([FromBody] OsobljeInsertModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _userService.AddOsoblje(model);
                    return Ok(item);
                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                return Ok(_userService.GetOsoblje(id));
            }
            catch
            {
                return NotFound(new ApiException("Ne postoji objekat sa tim ID-om.", System.Net.HttpStatusCode.NotFound));
            }
        }
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery] UserSearchRequestModel model = null)
        {
            try
            {
                return Ok(await _userService.GetOsoblje(model));
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOsoblje(int id, [FromBody] OsobljeUpdateModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var item = await _userService.UpdateOsoblje(id, model);
                    return Ok(item);
                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiException(ex.Message, System.Net.HttpStatusCode.BadRequest));
            }
        }
    }
}
