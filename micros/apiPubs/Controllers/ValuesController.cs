using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiPubs.Controllers
{
    [Route("api/values")]
    [ApiController]
    
    public class ValuesController : ControllerBase
    {
        [HttpGet("auth")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
        {
            var username = HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return new string[] { role, username };
        }

        [HttpGet("auth2")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<IEnumerable<string>> Get2()
        {
            return new string[] { "admin", "value2" };
        }

        [HttpGet("auth3")]
        [Authorize(Roles = "Root")]
        public ActionResult<IEnumerable<string>> Get3()
        {
            return new string[] { "root", "value2" };
        }
    }
}
