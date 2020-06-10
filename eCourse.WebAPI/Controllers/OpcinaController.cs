using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCourse.Models.Opcina;
using eCourse.Services.Repository;
using eCourse.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCourse.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpcinaController : BaseController<OpcinaModel, object>
    {
        public OpcinaController(IBaseService<OpcinaModel, object> service) : base(service)
        { }
    }
}
