using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Helpers;
using eCourse.Models.IspitKlijent;
using eCourse.Services.Interface;
using eCourse.WebAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles ="AdministrativnoOsoblje, Predavač")]
    [ApiController]
    public class IspitKlijentController : ControllerBase
    {
        private readonly IIspitKlijent _ispitKlijentService;

        public IspitKlijentController(IIspitKlijent ispitKlijentService)
        {
            _ispitKlijentService = ispitKlijentService;
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> UpdateKlijentScores([FromBody] KlijentScoresModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _ispitKlijentService.UpdateKlijentScores(UserResolver.GetUposlenikId(HttpContext.User) ,model);
                    return Ok(result);
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
