using Dating.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly DatingAppContext _context;

        public BuggyController(DatingAppContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "Secret text";
        }
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = _context.AppUsers.Find(-1);
            if (thing == null) return NotFound();
            return Ok(thing);
        }
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = _context.AppUsers.Find(-1);
            var thingToReturn = thing.ToString();
            return thingToReturn;
        }
        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}
