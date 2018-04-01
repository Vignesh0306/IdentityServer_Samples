using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/Identity")]
    [Authorize]
    public class IdentityController : Controller
    {
        [Route("GetUserInfo")]
        [HttpGet]
        public IActionResult GetUserInfo() {

            return new JsonResult(from c in User.Claims select new { c.Type, c.Value, c.Issuer });
        }
    }
}