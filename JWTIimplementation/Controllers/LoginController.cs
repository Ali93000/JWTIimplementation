using JWTIimplementation.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JWTIimplementation.Controllers
{
    public class LoginController : ApiController
    {
        [HttpGet]
        public IHttpActionResult ValidLogin(string username, string userPassword)
        {
            if (username == "admin" && userPassword == "admin")
            {
                var generateToken = TokenManager.GenerateToken(username);
                return Ok(generateToken);
            }
            else
            {
                return BadRequest("Invalid Username and Password");
            }
        }
    }
}
