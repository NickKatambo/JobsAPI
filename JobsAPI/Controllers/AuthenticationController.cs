using JobsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Post ([FromBody]ApplicationUser appUser)
        {
            var user = _authenticationService.Authenticate(appUser.UserName, appUser.Password);

            if (user == null)
                return BadRequest(new { message = "Username or Password is incorrect!!!" });

            return Ok(user);
        }
    }
}
