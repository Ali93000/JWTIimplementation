using JWTIimplementation.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace JWTIimplementation.Controllers
{
    [AuthenticatioFilter]
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            // To Read Claims on Api Controller
            var jwt = Request.Headers.Authorization.Parameter;
            var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            System.IdentityModel.Tokens.Jwt.JwtSecurityToken token = handler.ReadJwtToken(jwt);
            
            IEnumerable<Claim> claims = token.Claims.ToList();
            
            string id = token.Claims.FirstOrDefault(x => x.Type == "id").Value;
            string role = token.Claims.FirstOrDefault(x => x.Type == "role").Value;
            string Compcode = token.Claims.FirstOrDefault(x => x.Type == "Compcode").Value;
            string Bracode = token.Claims.FirstOrDefault(x => x.Type == "Bracode").Value;

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
