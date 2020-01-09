using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YPS.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ExampleController : Controller
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<object> Get()
        {
            return Ok(new object());
        }
    }
}